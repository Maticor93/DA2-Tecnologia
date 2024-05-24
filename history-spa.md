# Inicios SPAs

Las Single Page Applications (SPAs) representan la opcion moderna para el desarrollo web que transformo la forma en que los usuarios interactuan con las aplicaciones web.

Imaginemos estar en la misma pagina online de compras, pero en vez de que la pagina se refrezque completamente cada vez que hacen un click a un link o agregan un elemento al carrito, el contenido se actualiza en su lugar, creando una experiencia ininterrumida y mas fluida. Esto es lo escencial de las SPAs.

En una SPA, la aplicacion entera carga un unico HTML al inicio. Esta carga inicial incluye todo los scripts, recursos necesarios, los cuales van a ser gestionados con JavaScript. Cuando uno interactua con la aplicacion, JavaScript toma el control y actualiza de forma dinamica el contenido y responde a las acciones del usuario sin la necesidad de refrezcar la pagina completa. Esta opcion trae una experiencia muy parecida al usar una aplicacion de escritorio, donde las transiciones son instantaneas y la interfaz es consistente y dinamica.

<p align="center">
<img src="./images/image-2.png">
</p>
<p align="center">
[Comunicacion con una SPA]
</p>

Consideremos una pagina donde tenemos un encabezado y queremos navegar desde el inicio a una muestra de productos y luego terminar en el perfil de usuario.
Cuando hacemos click en el boton de ver los productos, el area del contenido se actualiza para desplegar el listado de productos, pero el resto de la interfaz, como el encabezado, permanece sin cambios. Esta interaccion fluida es traida por un framework SPA que maneja la navegacion y actualizaciones del contenido por atras, pudiendo proveer una experiencia de usuario mas fluida y eficiente.

La tecnologia sobresaliente que le permite a las SPAs funcionar de esta manera involucra un uso poderoso de JavaScript. Existen frameworks como Angular o librerias como React y Vue, que proveen las herramientas necesarias para la construccion de SPAs al manejar el estado de la aplicacion y las actualizaciones de renderizacion de interacciones con el usuario. Estos frameworks o librerias mantienen una representacion virtual de la UI, los cuales ellos actualizan de forma eficiente para reflejar los cambios, esto minimiza la cantidad actual de refrezcos de la pagina.

Una de las ventajas que tienen las SPAs es que reducen la carga del servidor y mejoran la performance. Ya que solo data, en vez de una pagina completa, es lo que se intercambia entre cliente y servidor despues de la carga inicial. La cantidad de data que es transferida es significativamente mucho mas chica. Esto hace que las aplicaciones web sean mas rapidas y mas dinamicas. Tambien se logra que la experiencia de usuario sea mas cohesiva ya que no hay interrupciones por recargas de paginas.

Las SPAs tambien permiten el uso de herramientas mas interactivas y dinamicas. Por ejemplo, en actualizaciones de tiempo real, como las live notificaciones y mensajes instantaneos, son facilmente integrados. Los desarrolladores pueden crear UI mas complejas con animaciones mas fluidas y transiciones donde en una MPA no hubiese sido posible.

Sin embargo, construir una SPA lleva sus desafios. Los desarrolladores deben asgurar un manejo apropiado sobre el historico de la navegacion y deep linking, lo cual es critico para mantener una navegacion dentro de la aplicacion coherente. Adicionalmente, la carga inicial puede demorar dado que tiene que descargar todos los recursos necesarios de una solicitud.

A pesar de estos desafios, el cambio de MPAs a SPAs revoluciono el desarrollo web, proviendole a los usuarios aplicaciones mas rapidas y dinamicas.

## Caracteristicas

- Unica carga inicial: SPAs cargan un unico archivo HTML al inicio, junto con todo los recursos necesarios para operar. Las interacciones subsiguientes no requieren la recarga de la pagina completa.

- Renderizacion del lado del cliente (CSR): La mayor parte de la renderizacion del contenido ocurre del lado del cliente usando frameworks de JavaScript. La aplicacion dinamicamente actualiza la vista en respuesta a las interacciones con el usuario.

- Comunicacion asincrona: SPAs se comunican con un servidor de forma asincrona usando AJAX o Fetch API. La data es enviada a medida que es necesitada, sin la necesida de refrezcar toda la pagina.

- Experiencia de usuario mas fluida: Las interacciones con los usuarios son manejadas en tiempo real, lo que provee una experiencia mas fluida y una sensacion mas parecida a aplicaciones de escritorio.

## Tecnologias

- HTML/CSS
- JavaScript
- Frameworks o librerias
- APIs

## Ventajas de uso de framework o libreria

- Mejoran la perfromance: Reducen la carga del lado del servidor y en las interacciones solo se transfiere data

- Mejoran la experiencia de usuario: Ocurren transiciones mas fluidas y actualizaciones en tiempo real

- Herramientas dinamicas: Facil implementacion o incorporacion de herramientas en tiempo real como live notificaciones o mensajes instantaneos

## Desafios

- SEO: Search engine optimization puede ser mas complejo, se requieren tecnicas adicionales para asegurar una indexacion apropiada

- Carga inicial: La carga inicial puede ser lenta dado la cantidad de elementos invlucrados en la descarga

- Historico de navegacion y navegacion: Tiene que existir un manejo apropiado para el historico de navegacion dentro de la aplicacion

En resumen las SPAs revolucionaron el desarrollo web al proveer una forma mas interactiva y dinamica con los usuarios, equilibrando frameworks modernos de JavaScript con comunicacion asincrona para crear sigle page applicacions dinamicos.

