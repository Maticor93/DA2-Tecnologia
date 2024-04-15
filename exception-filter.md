# Filtro de excepciones

Este filtro define una forma de manejar las excepciones no catcheadas en el sistema de forma global. Puede ser utilizado para manejar politicas custom sobre las excepciones.

Para implementar un filtro de excepciones, se debe implementar la interfaz `IExceptionFilter`.

El siguiente codigo muestra como implementar este filtro con la interfaz `IExceptionFilter`:

```C#
public sealed class CustomExceptionFilterAttribute : Attribute, IExceptionFiler
{
  public void OnException(ExceptionContext context)
  {
    //some code to handle exception
  }
}
```

El siguiente codigo muestra como usar el filtro de excepcion a nivel de clase:

```C#
[ApiController]
[Route("endpoints")]
[CustomExceptionFilter]
public sealed class CustomController : ControllerBase
{
  [HttpGet]
  public void Action()
  {
    //som code
  }
}
```

Este filtro de excepciones custom, manejara todas las excepciones no manejadas que ocurran dentro de esta clase.

Una vez que llega la excepcion al filtro, este debera de setear a la property `ExceptionHandled` el valor de `true` o un valor a la property `Result` para responder el error al cliente. Este filtro no puede convertir la respuesta de error en una de exito, solo el filtro de `Action` puede hacer eso.

Estos filtros son buenos como ultimo recurso para aquellas excepciones no manejadas dentro del sistema pero tienen la desventaja que no son tan flexibles como un middleware para manejar los errores.

## Caminos de implementacion

### Camino 1

Se puede tener tantos exception filter como uno quiera, eso da a lugar que se podria tener un exception filter por cada controller donde cada exception filter solo controla las excepciones que se lancen dentro de los metodos de ese controller.

Eso quiere decir que si tenemos los controllers: `Controller1` y el `Controller2`, podriamos crear un filtro de excepcion independiente para cada controller.

Teniendo lo siguiente:

```C#
public sealed class Controller1ExceptionFilterAttribute : Attribute, IExceptionFilter
{
  // code to handle unhandle exceptions of Controller1
}
```

<p align="center">
[Filtro de excepcion para `Controller1`]
</p>

```C#
public sealed class Controller2ExceptionFilterAttribute : Attribute, IExceptionFilter
{
  // code to handle unhandle exceptions of Controller2
}
```

<p align="center">
[Filtro de excepcion para `Controller2`]
</p>

Los cuales se usarian de la siguiente manera:

```C#
[ApiController]
[Route('controller1')]
[Controller1ExceptionFilter]
public sealed class Controller1Controller : ControllerBase
{
  // code to handle unhandle exceptions of Controller1
}
```

<p align="center">
[Controller1 con su filtro de excepciones]
</p>

```C#
[ApiController]
[Route('controller1')]
[Controller2ExceptionFilter]
public sealed class Controller2Controller : ControllerBase
{
  // code to handle unhandle exceptions of Controller1
}
```

<p align="center">
[Controller2 con su filtro de excepciones]
</p>

Esto llevaria a tener varios filtros de excepcion con un tamaño adecuado para mantener.

Este camino no tiene en cuenta aquellas excepciones que no son especificas del controller, las cuales deben ser manejadas de forma global.

### Camino 2

Tener un solo filtro de excepciones el cual tiene el control de cualquier excepcion no manejada y este debe ser declarado de forma global.

La implementacion del filtro no varia, varia la forma de usarlo, ya que no se especificara en ninguna clase o metodo.

Para registrar un filtro de excepciones de forma global, es necesario modificar la clase `Program.cs`

```C#
builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilter>();
});
```

Este camino tiene la ventaja de no tener que crear varios filtros de excepciones pequeños y evita el setearlo en cada clase. Tiene la desventaja de que impacta en el mantenimiento del mismo ya que controla todas las excepciones del sistema.

## Material de lectura

[Excepcion](https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-8.0#exception-filters)

