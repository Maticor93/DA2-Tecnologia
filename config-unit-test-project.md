# Configuracion de proyecto de prueba unitaria

El framework a utilizar para simular el comportamiento de las dependencias es `Moq`. Este debera de ser agregado a los proyectos de prueba unitaria para adquerir todas las funcionalidades del framework y crear los casos de prueba correspondientes.

`Moq` define diferentes comportamientos que determinan como un objeto `mock` se deberia de comportar cuando sus metodos son invocados. Estos comportamientos le permiten a los desarrolladores especificar respuestas o acciones que el objeto mock deberia de realizar durante la prueba. Estos comportamientos son:

- Strict: haciendo que se lance una excepcion en caso de que la llamada actual no cumpla con la esperada

- Loose: se retornara un valor por defecto del tipo a retornar en caso de no cumplir con lo esperado

Tambien se debera de instalar el paquete `FluentAssertions` el cual es una libreria que provee una sintaxis mas expresiva para escribir `assertions` en las pruebas, haciendo mas leible y facil de entender.

Algunos puntos claves sobre `FluentAssertions`:

- Sintaxis fluida: ofrece una API fluida que le permite a los desarrolladores encadenar multiples assertions juntas en una sola declaracion, resultando un codigo de prueba mas leible y conciso. La sintaxis fluida se asemeja a un lenguaje natural, haciendo mas facil de expresar la intencion de la prueba. Por ejemplo

```C#
someObject.Should().NotBeNull().And.BeOfType<MyClass>().And.BeEquivalentTo(expectedObject);
```

- Set amplio de assertions: provee un set de metodos de assert para varios tipos de datos y escenarios. Soporta assertions de objetos, colecciones, strings, numeros, exceptions, y mas. Este set tan amplio de metodos cubre muchos escenarios y ayuda a los desarrolladores a escribir pruebas mas robustas.

```C#
someObject.Should().Be(expectedObject);
collection.Should().Contain(expectedItem).And.NotContain(unexpectedItem);
```

- Mensajes de fallo claros: cuando un assert falla, se genera un mensaje de error claro y descriptivo que ayuda al desarrollador facilmente realizar un diagnostico del issue. El mensaje de error prove informacion detallada sobre los valores esperados y actuales, haciendo mas facil identificar la causa de fallo.

```C#
Expected someObject to be <expectedObject>, but found <actualObject>.
```

- Reglas custom de assertion: le permite a los desarrolladores definir reglas custom o extender los metodos para las necesidades especificas de la prueba. Esta flexibilidad ayuda a los desarrolladores extender funcionalidades de `FluentAssertions` y crear assertions mas especificas al negocio.

```C#
someObject.Should().Satisfy<MyClass>(obj => obj.CustomProperty == expectedValue);
```

- [Visual studio](https://github.com/Maticor93/DA2-Tecnologia/blob/unit-testing/config-unit-test-project-visual-studio.md)

- [Por comandos](https://github.com/Maticor93/DA2-Tecnologia/blob/unit-testing/config-unit-test-project-dotnet-cli.md)
