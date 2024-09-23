# Inyeccion de dependencia

Gracias al framework .NET Core, podremos utilizar el patron inyeccion de dependencia gracias a la libreria: `Microsoft.Extensions.DependencyInjection` de forma muy simple. Dicho patron apunta a la gestion y control de las dependencias del sistema. Una de las ganancias de aplicar dicho patron es poder implementar el principio de **inversion de dependencia** de forma clara y sencilla.

## Dependencia

Una dependencia entre clases o paquetes se da cuando una clase o paquete necesita un elemento (funcionalidad, clase, tipo, etc) en particular para poder realizar una operacion en particular y este elemento, se encuentra por fuera de la clase o paquete.

Conceptualmente, la dependencia se trata como `uso`, es decir, cuando existe una dependencia entre clases, es porque una clase `usa` a la otra, lo mismo se puede aplicar a paquetes. Este tipo de relacion lo podemos ver entre clases, paquetes e incluso entre elementos `cliente` y `servidor`, los cuales son mas tangibles y menos logicos.

## Problema que el patron intenta resolver

Sin el uso de la inyeccion de dependencia, el desarrollador debera de instanciar, de forma manual, las dependencias necesarias directamente en las clases o metodos que las necesiten. Este approach puede ser util en etapas inicilaes en un sistema, pero a la larga, genera un fuerte acoplamiento entre componentes, haciendo el codigo rigido y dificil de mantener o modificar. Algunas desventajas de instanciar las dependencias manualmente son:

- Poca flexibilidad: Cuando una clase instancia directamente sus dependencias, se vuelve dificil cambiarlas o remplazarlas por otras. Por ejemplo, si una clase depende de una implementacion especifica sobre el acceso a datos de una base de datos, cambiarla por otra implementacion sobre sobre otra base de datos, se requerira cambiar la clase en si.

- Dificil de probar de forma unitaria: un fuerte acomplamiento a implementaciones hace que realizar pruebas unitarias sea muy dificil o imposible. Cuando una clase instancia directamente sus dependencias, se vuelve desafiante aislar dicha clase para probarla. La realizacion de pruebas es crucial para mantener calidad de codigo y asgurar que cambios emergentes no introducen comportamientos inesperados.

- Dificil escalabilidad: A medida que la aplicacion crece, manejar las dependencias se vuelve una tarea cada vez mas compleja. La intanciacion de dichas dependencias de forma manual en diferentes lugares puede llevar a introducir bugs y un decaimiento de la productividad.

Ejemplo del problema con codigo:
Dado dos clases, `MovieController` y `MovieLogic`. `MovieController` es el controller especifico de gestionar el recurso `movies` y exponer operaciones acorde a dicho recurso. La clase `MovieLogic` es la clase especifica de encapsular toda la logica de negocio sobre el recurso `Movie`, esta expondra de forma publica ciertas operaciones para ser usadas por otras clases.

La dependencia se da desde `MovieController` hacia `MovieLogic`, como se puede ver en el segmento de codigo siguiente:

```C#
[ApiController]
[Route("movies")]
public sealed class MovieController : ControllerBase
{
  private readonly MovieLogic _movieLogic;

  public MovieController()
  {
    _movieLogic = new MovieLogic();
  }

  [HttpGet]
  public List<Movie> GetAll()
  {
    return _movieLogic.GetAll();
  }

  // ... rest of the code
}
```

Podemos observar como `MovieController` necesita de una instancia de `MovieLogic` para realizar ciertas operaciones, es por eso que `MovieLogic` es una dependencia de `MovieController`.

```C#
public sealed class MovieLogic
{
  private readonly IMovieRepository _movieRepository;
  private readonly IUserRepository _userRepository;

  public MovieLogic()
    {
      var dbContext = new DbContext();
      _movieRepository = new MovieRepository(dbContext);
      _userRepository_ = new UserRepository(dbContext);
    }

  // behaviour
}
```

Configurar esta dependencia es muy simple porque `MovieLogic` nos lo permite, pero esto se podria complicar facilmente si `MovieLogic` estuviese definido de la siguiente manera:

```C#
public sealed class MovieLogic
{
  // ...

  public MovieLogic(DbContext context)
    {
      // ...
    }

  // ...
}
```

Haciendo que `MovieController` tuviese que definir sus dependencias y las dependencias de las dependencias.

```C#
[ApiController]
[Route("movies")]
public sealed class MovieController : ControllerBase
{
  private readonly MovieLogic _movieLogic;

  public MovieController()
  {
    // declar MovieLogic dependencies
    _movieLogic = new MovieLogic(/* set MovieLogic dependencies*/);
  }

  [HttpGet]
  public List<Movie> GetAll()
  {
    return _movieLogic.GetAll();
  }

  // ... rest of the code
}
```

Con este sencillo ejemplo logramos ver lo facil que el mantenimiento y calidad de codigo se puede complicar.

## Como el patron resuelve el problema

El patron resuelve estas desventajas al desacoplar los elementos entre ellos y gestionar por ellos las dependencias que utilizaran. Gracias a esto obtenemos las siguientes ventajas.

- Poco acoplamiento: DI promueve que haya poco acoplamiento entre componenets al remover las instanciaciones de las dependencias de forma directa/manual. Las clases solo pueden utilizar abstracciones (interfaces o clases abstractas), permitiendoles una facil modificacion y extension de las mismas.

- Realizacion de pruebas: Con DI, la realizacion de pruebas unitarias es sumamente straightforward el poder replazar las dependencias con mocks o implementaciones dummy para las pruebas. Esta aislacion permite una mayor efectividad a la hora de realizar pruebas unitarias, llevando a tener una mejor calidad de codigo y menos bugs.

- Flexibilidad: DI facilita la modularidad y la extensibilidad. Es facil intercambiar dependencias o introducir nuevas sin la necesidad de modificar codigo existente, lo cual promueve a reutilizar codigo y hacer un sistema mas adaptable a cambios de requerimientos.

- Configuracion de dependencias centralizada: DI promueve centralizar la configuracion de las dependencias. El lugar indicado de realizar esto es al momento de iniciar la aplicacion. Esto permite tener una consistencia sobre las dependencias en toda la aplicacion.

- Cumple con OCP y SRP

Siguiendo el ejemplo de codigo, la aplicacion de DI dejaria el codigo de la siguiente manera:

```C#
[ApiController]
[Route("movies")]
public sealed class MovieController(IMovieLogic movieLogic)
 : ControllerBase
{
  [HttpGet]
  public List<Movie> GetAll()
  {
    return movieLogic.GetAll();
  }

  // ... rest of the code
}
```

```C#
public sealed class MovieLogic(
IMovieRepository movieRepository,
IUserRepository userRepository)
{
  // behaviour
}
```

Nuestro codigo se vio impactado en no instanciar las dependencias sino que en declarar que se necesita para que la clase funcione correctamente. Quien se encargue de instanciar estas dependencias en el momento adecuado sera el framework siguiendo la configuracion que nosotros especifiquemos.

Para terminar de configurar el uso de DI en nuestro sistema, debemos de configurar las dependencias en el inicio de nuestra aplicaion. En un proyecto web-api usando .NET 8 es en la clase `Program.cs`. Dicha clase inicialmente se encuentra de la siguiente manera:

```C#
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();
// Configure the HTTP request pipeline.

app.MapControllers();

app.Run();
```

Para realizar la configuracion de las dependencias, las mismas se deberan de encontrar despues de la primera linea `var builder = WebApplication.CreateBuilder(args);` y antes de la compulacion de la app `var app = builder.Build();`.

### Registro de servicios (dependencias)

Los serivcios involucrados en el registro son aquellos que son dependencias de otro servicio. Dicho registro ocurre para un contenedor de servicios al cual podemos seleccionar el ciclo de vida que le queremos dar y este contenedor gestionara la vida de los mismos.
Existen 3 ciclos de vida:

#### Scope

Estos servicios seran instanciados una vez dentro de un contexto de uso.

Bajo el dominio de una web api, los servicios `scope` seran instanciados por cada request, y dicha instancia sera compartida entre los lugares que se requiera dicha dependencia. Esto quiere decir que, si dos servicios (A y B) distintos, dependen del mismo servicio (C) y esta es declarada como `scope`, A y B comparten la misma instancia de C.

Esto implica que la instancia del servicio C es reusada para todos los servicios que la necesiten. Este ciclo de vida asgura consistencia y evita instancias duplicadas innecesariamente. Esta instancia es disposed por el contenedor de DI cuando la request termino de ejecutarse.

Para registrar un servicio con este ciclo de vida se debera de usar el metodo `AddScoped`

#### Transient

Estos servicios seran instanciadas para cada servicio que lo requiera.

Esto quiere decir que si tenemos los servicios A y B que dependen de C, y C esta declarado con este ciclo de vida, la instancia pasada al servicio A es difrente a la instancia pasada al servicio B, esto implica que la instancia de C no es reusable.

El largo de la vida de estos servicios es menor al largo de vida de los servicios `scope`;

#### Singleton

Solo existira una unica instancia de estos servicios y la misma sera compartida y distribuida para quellos servicios que la necesiten.

Estos servicios se instanciaran en la primera peticion y luego se reusara la instancia para peticiones futuras.

La duracion de vida de estos servicios es acorde a la vida del sistema.

Las dependencias entre los diferentes servicios debe ser en sentido gradual con respecto al largo de vida de los mismos. Esta es una restriccion para no utilizar servicios que el framework le hizo un dispose.

El orden de vida es el siguiente: `Singleton > Scope > Transient`, traduciendose a: los servicios `Singleton` son los que perduran mas en el tiempo seguido por los servicios `Scope` y luego los `Transient`. Esto hace que el sentido de depdendencias sea de forma inversa, quedando: `Transient -> Scope -> Singleton` y traduciendose a que servicios Transient pueden depender de otros servicios `Transient`, `Scope` o `Singleton`, servicios `Scope` pueden depender de servicios `Scope` o `Singleton` y servicios `Singleton` solo a servicios `Singleton`.

El siguiente codigo muestra como configurar servicios con el ciclo de vida `Scope`

```C#
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// services -> es el contenedor de servicios
var services = builder.Services;

// Registro de logica de negocio
services
  .AddScoped<IMovieLogic, MovieLogic>();

// Registro de acceso a datos
services
  .AddScoped<DbContext, VidlyContext>()
  .AddScoped<IMovieRepository, MovieRepository>()
  .AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();
// Configure the HTTP request pipeline.

app.MapControllers();

app.Run();
```

Dado esta configuracion, el framework sabra como tratar e instanciar nuestros servicios para cuando llegue una request. El contenedor de servicios autogestiona las dependencias sin tener que involucrarse manualmente.

## Referencias

[DI - Dependency injection in .NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-8.0#entity-framework-contexts)
