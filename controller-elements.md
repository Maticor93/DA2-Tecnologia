# Elementos de un controller

## Atributo ApiController

Es un atributo especial para marcar una clase como **controller**. Este atributo es tipicamente aplicado a clases que heredan de **ControllerBase**, esto indicaria que la clase es un **API controller**.

Este atributo afecta de la siguiente manera en las clases:

- Respuesta automatica con codigo 400: .NET Core automaticamente genera validaciones en los modelos. Esto quiere decir, que si la serializacion de la request a un modelo falla, el framework retorna una respuesta 400 con detalles sobre el error.

- Bindeo automatico de la informacion: No es necesario especificar explicitamente desde donde se tiene que sacar la informacion para la serializacion en los parametros de las funciones. Esto queire decir que no es necesario el uso de atributos como [FromBody], [FromQuery], el framework infiere desde donde proviene la data.

- Respuesta automatica para errores no cacheadas: Cuando una excepcion ocurre durante el procesamiento de la request, este atributo, genera automaticamente una respuesta con codigo de error 500 con los detalles de la excepcion.

- Formato de errores: Las respuestas de error son retornadas en el formato especificado (JSON, XML) segun el valor en el header Accept.

- Respuestas 204 automaticas para resultados vacios: Si una funcion retorna null, el atributo automaticamente lo convierte a una respuesta 204 (NoContent), esto simplifica el manejo de escenarios donde la api puede o no incluir contenido en la respuesta.

En resumen este atributo simplifica un monton de tareas relacionadas con la api, haciendo mas facil la creacion de una api y permitir una consistencia. De igual manera que provee comportamientos por defecto, uno puede customizar estos para ciertos aspectos especificos para nuestra api en particular.

## Atributo Route

Es usado para definir el endpoint a nivel de clase como base o a nivel de funcion como individual en el controller. Le permite a los desarrolladores especificar cual va a ser la URI que corresponde a un controller en particular o una funcionalidad.

Este atributo afecta de la siguiente manera en las clases o funciones:

- Enrutamiento a nivel de clase: Cuando se aplica a nivel de clase, se define una ruta base que aplica para todas las funciones internas del controller. Esta ruta base se combina con rutas especificas definidas a nivel de funciones.

- Enrutamiento a nivel de funcion: Cuando se aplica a nivel de funcion, se define un nuevo nivel a la ruta base del controller.

- Soporta parametros: A las rutas se le pueden proporcionar parametros para que los niveles sean dinamicos y no estaticos. Para lograr esto se utilizan las llaves ({parameter}) indicando el nombre del parametro a utilizar en el codigo. Los valores son extraidos de la request y a nivel de codigo se usan las variables.

- Condiciones: Adicionalmente, los parametros en la ruta pueden incluir restricciones a los valores que se proporcionen. Estas restricciones son especificadas usando una sintaxis de una linea, permitiendo la validacion de tipos, regular expressions o logica a los valores de los parametros.

En resumen este atributo juega un rol principal en definir los endpoints permitiendole al desarrollador mapear request http a un controller o funcion especifico. Provee una flexibilidad y control sobre la estructura de los endpoints, haciendolo mas facil de diseñar, limpio y mas intuitivo.

Una de las grandes ventajas en separar en diferentes controllers y las rutas de esta manera es que todos los endpoints que atienden un recurso estan encapsulados en una misma clase. En cuestion de organizacion tambien es una ventaja esta encapsulacion.

## Atributos HttpPost, HttpGet, HttpPut, HttpDelete

Estos atributos son usados a nivel de funciones para especificar que la funcion es la encargada de procesar la request http. La combinacion de verbo http + endpoint da como resultado una unica funcion. Esto quiere decir que esta combinacion no puede estar ligada a otra funcion al mismo tiempo, independientemente si estan en el mismo controller o no, en caso de que exista esta situacion, .NET Core respondera con un error de ambiguedad, y que no sabe a que funcion enrutar la request http.

## Atributos binding

Son los atributos para especificarle al framework donde esta la data.

- FromHeader: la data esta en el header
- FromRoute: la data esta en el endpoint
- FromQuery: la data esta en los query params
- FromBody: la data esta en el body

# Lecturas recomendadas
- (Model binding)[https://learn.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-3.1]
