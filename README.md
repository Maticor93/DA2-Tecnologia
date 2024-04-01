# Pruebas

Las pruebas son un aspecto fundamental en el desarrollo de software de calidad. En base a un set de pruebas aseguran que el codigo desarrollado funciona como es de esperar y es libre de bugs.

Existen varios tipos de pruebas, cada una con un proposito diferente para validar aspectos especificos del sistema.

# Pruebas de integracion

Estas pruebas se concentran en probar la interaccion entre diferentes modulos/capas del sistema. Verifica que modulos individuales funcionen correctamente en grupo. Este tipo de pruebas pueden ser realizadas en diferentes niveles del sistema.

Las mismas requieren un nivel de configuracion mas grande ya que prueban desde una capa inicio hasta la capa fin del sistema.

Este tipo de pruebas no suelen ser usadas de forma exaustiva ya que el consumo de las mismas es demasiado grande. Se suelen utilizar para probar cosas puntuales.

# Pruebas unitarias

Son el primer nivel de pruebas que involucran probar de forma individual componentes de forma aislada a otros componentes. Estan enfocadas en verificar la correctitud de trozos de codigo chico y aislados. Los desarrolladores usualmente escriben pruebas unitarias en conjunto con el codigo que desarrollan, asegurandose que cada componente se comporta de la manera que espera.

Estas pruebas deberan solamente probar codigo que este al alcance del desarrollador y solo un componente a la vez.

Este tipo de pruebas nos ayudaran a probar nuestro codigo sin la necesidad de probar las dependencias al mismo tiempo, esto ayudara a los desarrolladores a encontrar errores ubicados unicamente en la porcion de codigo que se esta probando.

Algunos aspectos fundamentales son:

- Aislamiento: las pruebas deberan de probar componentes de forma aislada a sus dependencias

- Diseñadas en funcion de test cases: estas pruebas giran en torno a casos de prueba, los cuales son escenarios especificos o entradas diseñadas para verificar un comportamiento de una unidad individual bajo diferentes condiciones. Los casos de prueba deben cubrir un set de escenarios grande para asegurar una cobertura completa

- Assertions: las pruebas unitarias incluyen assertions, los cuales son declaraciones que verifican el comportamiento esperado de la prueba unitaria. Estas declaraciones comparan el resultado actual con lo esperado.

- Mocking y Stubbing: las dependencias externas a la porcion de codigo son remplazadas con objetos mock o stubs para simular el comportamiento. Esto le permite a los desarrolladores controlar el ambiente en el cual la prueba es ejecutada y concentrarse solamente en probar la porcion de codigo.

- Ejecucion rapida: estas pruebas suelen ser rapidas, permitiendole a los desarrolladores ejecutarlas frecuentemente durante el proceso de desarollo sin ninguna complicacion. Una rapida ejecucion genera un rapido feedback, permitiendole a los desarrolladores identificar y arreglar defectos rapidamente.

- Integracion continua: las pruebas unitarias son escenciales para la integracion y entrega de codigo de forma continua. Estas pruebas son ejecutadas de forma automatica como parte de un proceso que asegura que el codigo compila y esta libre de bugs.

- Seguridad al refactorear: un set bueno de pruebas unitarias, genera una sensacion de seguridad a la hora de refactorear el codigo. Cuando un desarrollador realiza cambios, este puede introducir errores en alguna parte del codigo, la forma de asegurarse de que eso no suceda, es chequeando si alguna prueba unitaria falla despues de realizar los cambios.

## Mocks

Los mocks son objetos que simulan comportamiento de un objeto real de forma controlada. Son usados principalmente en pruebas unitarias para aislar la unidad a probar de sus dependencias. Estos objetos imitan el comportamiento de componentes externos con los que la unidad a probar interactua, por ejemplo: base de datos, servicios en la web u otros servicios o clases en el sistema.

Los mocks nos permiten verificar la interaccion del sistema bajo prueba (SUT - system under test) con sus dependencias.

Algunas caracteristicas de los mocks son:

- Simulacion del comportamiento de un objeto.
- Aislamiento de codigo de sus dependencias
- Reduccion de dependencias

Los mocks son un tipo de test doubles, estos son objetos que se utilizan en lugares de dependencias reales durante el testing para aislar una unidad de codigo especifica y controlar el comportamiento de las dependencias. Los test doubles le permiten al desarrollador crear ambientes controlados para las pruebas, asegurandose que las pruebas sean predecibles, repetibles e independientes a factores externos.

Algunos otros test doubles son:

- Dummy: son placeholder usados cuando un parametro es requerido pero su valor es irrelevante a la prueba. Son tipicamente pasados como argumentos pero nunca usados en la prueba en si. Ayudan a satisfacer la firma de un metodo o constructor sin impactar en la logica de la prueba.

- Stub: proven una respuesta a la llamada de metodos durante una prueba. Simulan el comportamiento de objetos reales al retornar valores pre definidos o lanzar excepciones pre definidas. Son utiles para controlar el comportamiento de dependencias y asegurarse resultas consistentes.

- Mock: Son objetos pre programados con expectativas sobre las llamadas que esperan recibir durante la prueba. Le permiten a los desarrolladores especificar las interacciones esperadas entre la unidad que esta bajo prueba con sus dependencias. Pueden verificar los argumentos con los cuales son llamados los metodos, especificar un orden y frecuencia.

- Fake: son simplemente implementaciones de dependencias que proveen una forma alternativa a los objetos reales. Son usados tipicamente en escenarios donde el objeto real no es pracico, como por ejemplo: el uso de base de datos en memoria en lugar de una base de datos en produccion para pruebas. Estos sacrifican similitud por simpleza y velocidad.

- Spy: guardan las interacciones entre la unidad a probar con sus dependencias, permitiendo a los desarrolladores inspeccionar y verificar esas interacciones despues de que la prueba fue ejecutada. Son utiles para monitorear como las pruebas interactuan con sus dependencias sin modificar su comportamiento.

Algunas ventajas de usar los diferentes test doubles son:

- Aislamiento
- Control
- Velocidad
- Flexibilidad

[Creacion de un proyecto de prueba unitaria con MSTest](https://github.com/daniel18acevedo/DA2-Tecnologia/blob/unit-testing/create-unit-test-project.md)