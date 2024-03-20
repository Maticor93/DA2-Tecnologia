# Controller

Son las clases que juegan un rol fundamental para el procesamiento de request HTTP y la generacion de respuestas.

Estas clases contienen funciones responsables en procesar las request HTTP y retornar la respuesta correspondiente a la peticion. Cada controller representa un set de endpoints asociado a un recurso, las cuales son mapeadas a funciones dentro de la clase. Estos endpoints son las funcionalidades de la web api disponibles a utilizar a traves de http.

Estas clases tienen tres responsabilidades:

- Mapeo de endpoint a funciones
- Procesamiento de las requests
- Generar una respuesta

Estos elementos son nada mas que clases, por convension deben estar ubicadas dentro de la carpeta.

En resumen son el punto de entrada para request http hacia nuestra web api y tienen el trabajo de orquestrar el procesamiento de estas requests y responderle a los clientes. Encapsulan la logica de manejar la comunicacion HTTP y son un aspecto crucial.

Al ser el punto de entrada a nuestra web api, estas clases son utilizadas por .NET Core, no seran instanciadas para utilizar en la logica, serian instanciadas para pruebas unitarias.

Cuando una request llega a la web api, .NET Core usa la configuracion de enrutamiento para determinar que controller y que funcion deberia de manejar la request. Una vez que el controller y la funcion son identificados, el framework crea una instancia del controller e invoca la funcion apropiada para procesar la request.

- [Elementos de un controller](https://github.com/daniel18acevedo/DA2-Tecnologia/blob/web-api/controller-elements.md)
- [Buenas practicas](https://github.com/daniel18acevedo/DA2-Tecnologia/blob/web-api/controller-good-practices.md)
