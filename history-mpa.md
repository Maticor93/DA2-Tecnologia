# Inicios en paginas web

Antes de hablar sobre que es angular y las SPAs, es necesario hablar sobre que opcion existia antes que estos para entenderlas un poco mejor como operan.

Dicha opcion era conocida como MPAs (Multi-Page Applications), y esta define que la composicion de la aplicacion es un conjunto de archivos separados HTML. Cuando un usuario interactua con la aplicacion, el navegador envia la request http al servidor para que la procese y este genere el HTML necesario para enviarselo al navegador del cliente. Esto establece que la comunicacion entre cliente-servidor es un envio constante de archivos HTML, js y css. Esto hace que la pagina web entera se refrezque con todo el contenido nuevo.

<p align="center">
<img src="./images/image.png">
</p>
<p align="center">
[Comunicacion entre cliente-servidor]
</p>

Esta opcion para la epoca era la esperada y acorde, pero la misma tenia sus desventajas. Imaginemos que estamos navegando por una tienda online construida como MPA. Cuando navegamos de la pagina de inicio a la pagina de un producto especifico, el navegador solicita la nueva pagina al server. El server reune toda la informacion necesaria, como los detalles del producto e imagenes, los reune en el HTML de la pagina del producto, y la envia al navegador del cliente. El navegador descarta la pagina actual en la que se encontraba y carga la pagina nueva que el servidor le envia. Este proceso se repita para cada interaccion que requiere nueva data o una nueva vista.

<p align="center">
<img src="./images/image-1.png">
</p>
<p align="center">
[Navegacion en una pagina MPA]
</p>

En las MPAs, la mayoria de la logica de la aplicacion y el procesamiento de la data ocurre del lado del servidor. Cuando un usuario solicita una pagina, el servidor corre scripts para buscar la data desde la base de datos, popular los templates con la data y le envia un archivo HTML completo al cliente. Este metodo asegura que el contenido es generado dinamicamente.

Sin embargo, esta opcion de construccion paginas web, significa la reconstruccion de la pagina entera para cada interaccion con el usuario sin importar la magnitud del mismo, desde un click a un link hasta submitear un formulario. Esto puede hacer la experiencia de usuario (UX) un poco lenta y desajustada porque el contenido de la pagina entera es recargada, incluso si una pequeña parte de la misma es la que cambia. Los usuarios experimentan un delay notable y un flash visual mientras que la pagina nueva se renderiza.

Para mejorar la experiencia de usuario, los desarrolladores empezaron a utilizar tecnicas como AJAX (Asynchronous JavaScript and XML) para actualizar partes de la pagina de forma asincrona sin la necesidad de actualizar toda la pagina. Esto permitio una interaccion mas fluida con las MPAs y la creacion de elementos mas dinamicos como actualizar un carrito de compra sin la necesidad de recargar la pagina completa. Sin embargo, estas actualizaciones con AJAX eran un suplemento al motor de la arquitectura MPA, donde la recarga de las paginas completas era la norma en la mayoria de las interacciones.

Por mucho tiempo la creacion de las paginas web haciendo uso esta arquitectura fue efectiva, pero eventualmente decallo con la aparicion de las SPAs (Single Page Application) la cual ofrece una experiencia mas fluida y un comportamiento mas como una aplicacion al cargar un unico archivo HTML y dinamicamente actualizarle el contenido a traves de JavaScript sin la necesidad de recargar la pagina completamente.

