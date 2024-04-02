# Elementos en una clase de pruebas unitarias

Una clase de pruebas unitaria encapsula una configuracion predeterminada para probar un una unidad de codigo determinada. La misma prepara un ambiente y elementos a usar para que las diferentes pruebas unitarias puedan reusar dejando a las mismas la responsabilida de definir los diferentes escenarios de prueba.

Para que una clase sea determinada por el framework como una clase de pruebas unitarias, la misma debera de ser `publica` y contener el atributo `[TestClass]`. Estas condiciones de la clase le permiten al framework identificar las pruebas disponibles para ejecutarlas.

```C#
[TestClass]
public sealed class MovieControllerTests
{
  // unit tests
}
```

Esta clase de prueba, es un ejemplo de una clase que quiere probar el comportamiento publico de la clase `MovieController`. Esta es una forma de organizacion de la prueba, tiene la ventaja y desventaja de que todo lo relacionado a este `controller` esta encapsulado en una clase sola. Independientemente de si la clase tiene muchos comportamientos a probar, esta clase de prueba definira varios casos de uso haciendola una clase muy extensa en donde trabajar. Una forma de resolver esta problematica es hacer uso de las `regions`.

Otra opcion de marco de trabajo podria ser tener una clase de prueba por comportamiento a probar. Siguiendo este camino podria existir lo siguiente:

```C#
[TestClass]
public sealed class CreateMovieControllerTests
{
  // unit tests
}
```

Esta clase hace referencia a probar el comportamiento `Create` de la clase `MovieController`. Este camino hace que cada clase de prueba sea mas compacta pero incrementa en cantidad de clases de prueba a mantener.

## TestInitialize

Es el atributo que se le puede dar a un metodo que se ejecutara previamente a cada prueba individualmente. Este atributo nos permite definir un espacio para la inicializacion de elementos previamente a cada prueba. Esto permite respetar la independencia entre las pruebas

Dado que es un metodo con un atributo, en este no podremos inicializar estado de la clase que haga uso de la palabra clave `readonly`. Dichos estados deberan ser definidos en el constructor de la clase de prueba o en la misma linea de declaracion.

```C#
[TestClass]
public sealed class MovieControllerTests
{
  [TestInitialize]
  public void Initialize()
  {
    // initialize logic
  }
}
```

## TestCleanup

Es el atributo que se le puede dar a un metodo que se ejecutara posteriormente a cada prueba individualmente. Este atributo nos permite definir un espacio para borrar estado de la prueba o en otros elementos para respetar la independencia entre las pruebas.

```C#
[TestClass]
public sealed class MovieControllerTests
{
  // some code

  [TestCleanup]
  public void Cleanup()
  {
    // clean up logic
  }
}
```

