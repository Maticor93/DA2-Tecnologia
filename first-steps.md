# Primeros pasos

Para iniciar con EF Core en nuestra aplicacion, es necesario instalar el paquete `Microsoft.EntityFrameworkCore`.

- [Visual Studio]()

- [Por comandos]()

## Crear contexto concreto

Una vez instalado EF Core en el proyecto con la responsabilidad de interactuar con la base de datos. Debemos de crear una clase concreta, especifica para nuestro negocio que configure la conexion a la base de datos. Esta clase se identifica por ser un `contexto concreto`.

```C#
public sealed class VidlyDbContext : DbContext
{
  // some code
}
```

El nombre del `contexto concreto` debe de dar informacion sobre de que negocio es el contexto, asi se puede identificar rapidamente con que base de datos opera y que tablas podemos encontrar en ella.

Tambien se podria dar informacion sobre que ORM utiliza, quedando el nombre asi:

```C#
public sealed class VidlyEfCoreContext : DbContext
{
  // some code
}
```

Esta notacion es util cuando se tienen varios `contextos concretos` y se utilizan ORM diferentes, algunos relacionales y otros no relacionales.

## Crear tablas

Dentro del `contexto concreto` deberemos de configurar el set de tablas con las que el contexto puede trabajar.

```C#
public sealed class VidlyDbContext : DbContext
{
  public DbSet<Movie> Movies { get; set; }

  public DbSet<User> Users { get; set; }
}
```

Las properties de tipo `DbSet` son las que indicaran que tablas se tendran que crear en la base de datos y el nombre es tomado por el nombre de la property. Esto implica que con el ejemplo se van a crear dos tablas, una `Users` y otra `Movies`.

## Conexion a la base de datos

A la hora de indicar que nuestro contexto se deba de conectar a a la base de datos, debemos de ser lo mas flexible posibles ya que, nuestra base puede variar segun el ambiente en el cual queramos correr la aplicacion. Esto quiere decir, que podemos tener diferentes base de datos, una por cada ambiente en la cual ejecutemos nuestra aplicacion.

Podemos tener los siguientes ambientes:

- Produccion: la base de datos guardara informacion real de nuestra aplicacion de usuarios finales.

- Desarrollo: la base de datos guardara informacion muy parecida a la real en produccion, sirve para trabajar con un buen set de datos.

- QA: la base de datos aca es para probar libremente, sin miedo a dejar inconsistencias o probar cosas.

- Local: la base de datos es personal para cada desarrollador, sus datos no son compartidos.

Como nuestra aplicacion puede ser ejecutada en alguno de estos ambientes u otros, la forma de setear a que base de datos se debe de conectar el contexto, debe ser lo mas flexible posible. No solamente estamos siendo flexibles a que base de datos se esta conectando sino que tambien a que motor de base de datos se esta conectando. Para eso definiremos el siguiente constructor:

```C#
public sealed class VidlyDbContext : DbContext
{
  public DbSet<Movie> Movies { get; set; }

  public DbSet<User> Users { get; set; }

  public VidlyDbContext(DbContextOptions options)
    : base(options)
    {
    }
}
```

En caso de que nuestra aplicacion maneje mas de un contexto concreto, se debera de especificar de la siguiente manera:

```C#
public sealed class VidlyDbContext : DbContext
{
  public DbSet<Movie> Movies { get; set; }

  public DbSet<User> Users { get; set; }

  public VidlyDbContext(DbContextOptions<VidlyDbContext> options)
    : base(options)
    {
    }
}
```

Con el contexto hasta ahora es suficiente para crear las migraciones y utilizarlo para ejecutar consultas a nuestra base de datos. Toda la interaccion contra la base debe ser a traves de un contexto concreto, ya que es la clase que configura la conexion.

## Configuracion del motor de base de datos

Previamente a utilizar el contexto concreto en nuestra aplicacion, debemos de configurarla para que utilice la base de datos en el ambiente que se este ejecutando.

La configuracion tomara lugar en el inicio de nuestra aplicacion, bajo el contexto de una web api en .NET 8 es en la clase `Program.cs`.

```C#
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var services = builder.Services;
var configuration = builder.Configuration;

var vidlyConnectionString = configureation.GetConnectionString("VidlyDb");
if(string.IsNullOrEmpty(vidlyConnectionString))
{
  throw new Exception("Missing VidlyDb connection-string");
}

services.AddDbContext<VidlyDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

```

En esta configuracion leemos el connection string desde el archivo de configuracion `appsettings.json` segun el ambiente en el que se este ejecutando la aplicacion, y en caso de que no exista se lanza una excepcion causando la interrupcion de la aplicacion.

Posteriormente de configura la inyeccion de `VidlyDbContext` con el uso de SQL Server y usando el connection-string provisto.

## Primera migracion

Para realizar migracines es necesario instalar 3 paquetes.

- **Microsoft.EntityFramework.Design**: sirve para que EF Core logre interpretar las entidades y pueda realizar un modelado de tablas

- **Microsoft.EntityFramework.Tools**: permite crear y aplicar migraciones y generar codigo a partir de una base de datos existente.

- **Microsoft.EntityFramework.SqlServer**: paquete para conectarse a una base de datos con motor SQL Server

Instalacion en:

- [Visual Studio]()

- [Por comandos]()

La creacion de las migraciones y ejecucion de las mismas, ocurren por consola:

### 1. Chequear que estoy en la raiz de la solucion

```
ls
```

Comandos:

- `ls`: lista eleemntos en un directorio

### 2. Pararse en el proyecto donde se van a guardar las migraciones

```
cd Vidly.WebApi
```

Comandos:

- `cd`: entrar a un directorio
- `Vidly.WebApi`: directorio al cual quiero acceder

### 3. Chequeo que estoy dentro de `Vidly.WebApi`

```
ls
```

### 4. Crear primera migracion

```
dotnet ef migrations add InitialCreation
```

Comandos:

- `dotnet`: programa para ejecutar comandos de dotnet

- `ef`: parametro para operar con base de datos

- `migrations`: parametro para operar con migraciones

- `add`: parametro para indicar la creacion de una migracion

- `InitialCreation`: nombre de la migracion

### 5. Chequear que se creo la migracion

### 6. Ejecutar migracion

```
dotnet ef database update
```

Comandos:

- `database`: parametro para operar con la base
- `update`: parametro par actualizar la base

### 7. Chequear la creacion de la base de datos
