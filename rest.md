# REST

Representational State Transfer es un estilo arquitectonico para diseñar aplicaciones web. Es un approach escalable y mantenible para la creacion de web services y APIs. Los sistemas que sigan este estilo arquitectonico se categorizan por cumplir un set de restricciones.

Al ser un estilo arquitectonico, esto implica que no es un estandard estricto y permite flexibilidad. Gracias a esta flexibilidad es importante definir buenas practicas a respetar.

## Restricciones

### 1. Interfaz uniforme

Define una interfaz (un contrato), con un set de funcionalidades para una interaccion cliente-servidor. Permite una evolucion de la implementacion independientemente de la evolucion del cliente. Esto implica un desacoplamiento entre ambos extremos.

Para lograr esto se deben seguir los siguientes principios:

- Basarse en recursos
- Respuestas con la informacion necesaria para la manipulacion

### 2. Comunicacion Stateless

Toda la informacion para interpretar la solicitud, tiene que estar contenida en la request misma (en el endpoint, body, headers, query params, etc). Esto es porque el servidor no mantiene una conexion viva con el cliente.

Debido a esto, es necesario mandar la informacion correspondiente en la request, para que el servidor pueda identificar quien es el que hace la request para tomar acciones.

Esta restriccion impacta tanto al servidor como al cliente, ya que desde el lado del servidor se debe poder identificar el propietario de la request segun la informacion que mande y desde el lado del cliente se debe guardar la identificacion a mandar en futuras interacciones con el servidor.

Esta restriccion tiene la ventaja de lograr que el servidor sea mas facil de escalar y de ser distribuido. Esto implica poder realizar redespliegues facilmente en casos de fallo y tambien un escalado individual.

Esto es gracias a que cada request puede ser dirigida a cualquier instancia/nodo/componente ya que no se establece una conexion punto a punto para una entablar una comunicacion.

<p align="center">
  <img src="images/image-15.png"/>
</p>

<p align="center">
[Escalabilidad]
</p>

<p align="center">
  <img src="images/image-16.png"/>
</p>

<p align="center">
[Multiples conexiones]
</p>

### 3. Cacheable

Algunas respuestas del servidor pueden ser cacheadas por los clientes. Para lograr esto, las respuestas con tal objetivo, deben definir algun parametro para indicar que tal respuesta puede ser cacheada.

Esto quiere decir que si una respuesta es marcada como cacheable, el cliente va a poder persistir esa respuesta desde su lado y consumirla mas rapidamente sin la necesidad de ir al servidor.

Esto se hace en aquellas respuestas que se saben que no varian con el tiempo.

Esta restriccion bien utilizada puede lograr eliminar la interaccion con el servidor de forma parcial o total con el objetivo de mejorar la escalabilidad y performance.

<p align="center">
  <img src="images/image-17.png"/>
</p>

### 4. Cliente-Servidor

Al tener una interfaz uniforme logramos separar los clientes de los servidores. Esto permite que los clientes no se preocupen de como los datos son almacenados a procesados, ya que es trabajo del servidor. Esto implica que el codigo del cliente sea mas portable, ligero.

Esto tiene la misma implicancia del lado del servidor, a este no le preocupa manejar una interfaz de usuario o el estado del mismo, ya que los servidores son mas escalables.

Siempre y cuando la interfaz, el contrato, siga cumpliendose, los clientes y los servidores pueden variar.

<p align="center">
  <img src="images/image-18.png"/>
</p>

### 5. Tiered y Layered system

Esta restriccion implica que un cliente no puede deducir si esta comunicandose con un servidor final o un intermediario (tier).

Los servidores intermediarios permiten mejorar la escalabilidad a traves de habilitar el balanceo de carga y caches compartidos. Cada capa tambien puede exigir politicas de seguridad. A su vez, se base en una arquitectura en capas.

<p align="center">
  <img src="images/image-19.png"/>
</p>

## Buenas practicas a seguir

### 1. Endpoint/Rescurso

Un endpoint es una URI (Uniform Resource Identifier) especificaen un web service o web API que es usado para acceder a un recurso particular o realizar una accion especifica. Cada endpoint corresponde a una funcionalidad provista por un web service o una web api, y es accedida por request http.

Estos tienen que seguir las siguientes reglas:

- **Sustantivos ante verbos**

  - ../dogs\_ → URI para manipular perros
  - .../users →\_ URI para manipular usuarios
  - .../sessions → URI para manipular sesiones

- **Intuitiva y simple**

- **Plural ante singular**

- **En minuscula**

- **Nombres concretos ante abstractos**

1. Bien:
   1. ../_dogs_
   2. ../_admins_
2. Evitar:
   1. ../_animals_
   2. ../_persons_

- **Recursos con relaciones**

1. Bien:
   1. ../owners/1/dogs
2. Evitar:
   1. ../_users/1/dogs/2_

- **Ocultar complejidad con '?'**

- **Verbos fuera de la URI**

1. Bien:
   1. ../_dogs_?_leashed=true_
   2. ../_dogs_
2. Evitar:
   1. ../_getAllLeashedDogs_
   2. ../_getHungerLevel_

- **Hasta 3 niveles**

### 2. Verbos HTTP

Existen varios verbos http, los mas comunes a usar y que representan bien las operaciones CRUD son: POST, GET, PUT, DELETE.

La aplicacion de los diferentes verbos ante el mismo endpoint, implican funciones distintas.

Los verbos se los suele agrupar por ser idempotentes o no. Un verbo es idempotente cuando no importa las veces que se ejecute, el servidor siempre responde lo mismo.

Los verbos idempotentes son: GET, PUT y DELETE.

### 3. Manejo de errores

- **Buen manejo de codigo de error**
  Los codigos de error correctos especifican el tipo de error ocurrido. Es por eso que existen diferentes familias de errores.
- **Consistencia de body**
  Una vez diseñado la estructura del error, se debera de cumplir independientemente del tipo de error.

  El diseño de los errores debe de proveer la informacion suficiente para arreglar el error, este diseño tambien debera de tener en cuenta que sera consumido por sistemas y desarrolladores.

### 4. Funcionalidades no relacionadas a recursos

Existen funsionalidades que no estan relacionadas a recursos. Por ejemplo, calculos financieros o traducciones de lenguaje. Estas funcionalidades responden a un resultado y no a un recurso. En estos casos se deberia de usar verbos y no sustantivos, pero el uso de estos verbos debe ser lo mas simple posible.

Por ejemplo un endpoint para convertir de una moneda a otra, se puede tener algo de la siguiente manera:

```
/convert?from=EUR&to=CNY&amount=100
```

Es importante que estos endpoints sean documentados correctamente, especificando sus parametros y comportamiento. Dado que no es estandard, un usuario de la API no sabra como se comporta facilmente.
