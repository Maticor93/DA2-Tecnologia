# Buenas practicas

## Route a nivel de clase
El uso del atributo [Route] deberia ser a nivel de clase y sin el uso del placeholder. Cuando se crea un controller se crea de la siguiente manera: [Route("[Controller]")] el cual se deberia de modificar de la siguiente forma [Route("resource")] siendo "resource" el recurso que el controller estara atendiendo. Este resource debe ser completamente en minuscula y en plural.

## Niveles extra
Para especificar niveles extra al base, se debera de hacer en los atributos de los verbos http. Por ejemplo: [HttpGet("{id}")] o [HttpGet("users")], el primer ejemplo, indica un nivel adicional dinamico, y el segundo ejemplo, indica un nivel adicional estatico.

## Controller sealed
Los controllers especificos de recursos son clases que no se reusan logica, no se deberian de poder heredar entre ellos.

## Estado privado
El estado de los controllers no deberia de ser algo que en la api se quiera utilizar, son puertas al mundo solamente. Para evitar complejidad en el uso, los estados que guarden deben de ser privados y readonly.

## Manejar un recurso a la vez
Los controllers no deben de manejar multiples recursos al mismo tiempo. Solo pueden estar ligados a un recurso y a una logica del negocio. Esto limita la complejidad y el mantenimiento de los mismos.

## Retorno de respuestas exitosas automaticas
Dado que el manejo de respuestas exitosas es automatica, las funciones dentro de los controllers deberan de retornar objetos que no sean del tipo IActionResult o ActionResult.

## Inexistencia de try y catch
El manejo de error debera ser de forma global, esto implica que no se debera de tener bloques de try y catch en las funciones de los controllers.

## Extension de las funciones
Los controllers como son un enrutamiento a la logica de negocio correspondiente, estas no deberan de contener ningun tipo de logica, solo la llamada correspondiente a la logica encargada de atender dicha solicitud. Esto porque la capa de api es de bajo nivel (tecnologia) esta podria ser cambiada por otra y si contiene logica de negocio, se perderia, o se duplicaria.

## Funciones publicas
Para que se pueda hacer el enrutamiento de la request http a la funcion correspondiente, estos deben ser publicos para ser invocados.

