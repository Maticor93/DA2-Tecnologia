# Filtro de autorizacion

Son el tipo de filtros que son ejecutados primero, definen el control de acceso a la request a procesar y tienen un unico metodo.

Al ser los primeros filtros que son ejecutados, las excepciones que son arrojadas no seran manejadas por nadie, estos tendran que definir un manejo de excepciones de forma interna. Esto quiere decir, que si se tiene un filtro de excepciones, este no tendra alcance a las excepciones que seran lanzadas en el filtro de autorizacion.

Para implementar un filtro custom de este tipo es necesario implementar la interfaz: `IAuthorizationFilter`.

```C#
public sealed class AuthorizationFilterAttribute : Attribute, IAuthorizationFilter

public void OnAuthorization(AuthorizationFilterContext context)
{
  // some code
}
```

El siguiente codigo mustra como usarlo a nivel de clase o a nivel de metodo.

```C#
[ApiController]
[Route('endpoints')]
[AuthorizationFilter]
public sealed class CustomController : ControllerBase
{
  [HttpGet]
  [AuthorizationFilter]
  public void MyAction()
  {
    // some code
  }
}
```

## Material de lectura

[Authorization](https://learn.microsoft.com/en-us/aspnet/core/security/authorization/introduction?view=aspnetcore-8.0)

