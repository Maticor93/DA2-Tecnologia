# Reflection

Reflection es la habilidad de un lenguaje de inspeccionar e invocar dinamicamente a clases, metodos, atributos, etc. en tiempo de ejecucion.

Para .Net, es la habilidad de un programa poder autoexaminarse con el objetivo de encontrar ensamblados (.dll), modulos, o informacion de tipos en tiempo de ejecucion. A nivel de codigo vamos a tener clases y objetos que nos van a permitir referenciar a ensablados, y a los tipos que se encuentren contenidos.

Se dice que un programa se refleja a si mismi (de ahi el termino reflection), a partir de extraer metadata de sus assemblies y de usar esa metadata para ciertos fines. Ya sea para informarle al usuario o para modificar su comportamiento.

El uso de reflection, obtenemos informacion detallada de un objeto, sus metodos, e incluso crear objetos e invocar sus metodos en tiempo de ejecucion, sin haber tenido que realizar una referencia al ensamblado que contiene la clase y a su namespace.

Especificamente lo que nos permite usar Reflection es el namespace `System.Reflection`, que contiene clases e interfaces que nos permiten manejar todo lo mencionado anteriormente: ensamblados, tipos, metodos, estado, crear objetos, invocar metodos, etc.

## Estructura de un assembly/ensamblado

Un ensamblado es el resultado de compilar el programa, generalmente lo podremos ver como un .dll. Es la unidad minima en .NET.

Los assemblies contienen paquetes, los paquetes contienen tipos y los tipos contienen estados. Reflection provee clases para encapsular estos elementos.

Como se dijo, es posible utilizar reflection para crear dinamicamente instancias de un tipo, obtener el tipo de un objeto existente e invocarle metodos y acceder a sus atributos de manera dinamica.

<p align="center">
<img src="./images/image-9.png"/>
[Estructuracion de un assembly]
</p>

Algunas ventajas:

- Desacoplamiento a tipos externos
- Inspeccion de tipos de forma dinamica
- Uso de tipos o metodos menos fuertemente tipados

Algunas desventajas:

- Performance overhead: las operaciones de reflection son generalmente lentas en comparacion con operaciones realizadas directamente sobre tipos conocidos en tiempo de compilacion. Esto es porque reflection involucra el descubrimiento de tipos en tiempo de ejecucion y la inspeccion de metadata, que puede inferir en performance overhead, especificamente en aplicaciones performance-sensitive como aplicaciones de salud o economicas.

- Complejidad agregada: el codigo de reflection puede ser dificil de mantener, debugguear y mantener. Todas las tareas de reflection no son tan transparentes.

- Falta de seguridad por compilacion: dado que reflection puede pasar chequeos en tiempo de compilacion, los errores relacionados a mismatches o falta de miembros ocurriran en tiempo de ejecucion causando excepciones no esperadas.

- Riesgos de seguridad: el uso de assemblies por reflection proponen una vulnerabilidad ya que estos assemblies pueden inspeccionar nuestra aplicacion.

En resumen, a pesar de las desventajas, reflection sigue siendo una herramienta poderosa, particularmente en escenarios donde la flexibilidad que trae en tiempo de ejecucion y el dinamismo sobre comportamientos es escencial. Sin embargo, es importante usar reflection de forma cautelosa y considerar caminos alternativos para mitigar posibles problemas.
