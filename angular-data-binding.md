# Data Binding

Sin un framework, nosotros seriamos responsables de submitear los valores de la data a los elementos HTML y convertir las respuestas de los usuarios en acciones y actualizaciones de data. Escribir tal logica de push y pull de la data es tedioso, un posible causante de errores e inmantenible.

Es por eso que existe lo llamado data binding que permite combinar codigo HTML con ciertas sintaxis de Angular las cuales pueden modificar los elementos HTML antes de ser visualizados. Las directivas del template proveen logica, y las sintaxis de Angular conectan la data de la aplicacion con el DOM. Hay dos tipos de data binding:

| Data Binding     | Detalles                                                                                         |
| ---------------- | ------------------------------------------------------------------------------------------------ |
| Event Binding    | Le permite a la aplicacion responder a inputs de usuarios al actualizar la data de la aplicacion |
| Property Binding | Permite interpolar valores que son calculados en la logica de la aplicacion en el HTML           |

Antes de desplegar la vista, Angular evalua las sintaxis utilizadas y resuelve que informacion desplegar y que elementos HTML modificar del DOM. Angular soporta tambien two-way data binding, lo que significa que los cambios en el DOM, como inputs de usuarios, tambien pueden verse reflejados en la actualizacion de la data.

Por ejemplo tenemos el siguiente codigo que muestra muestra el nombre de una pelicula guardada en el estado del componente

```HTML
<h2>Pelicula: {{movie.name}}</h2>
```

<p align="center">
<img src="./images/image-7.png">
</p>
<p align="center">
[Formas de data binding]
</p>

En la imagen podemos ver las diferentes formas de hacer data binding entre el componente con el template HTML en el DOM.

- Property Binding: cuando el binding es hacia una property particular de algun elemento, como puede ser el valor de un img. Setea el valor de una property a un a expresíon en el template. Ver sintaxis en imagen de abajo.

- Event Binding: es binding hacia funciones o métodos que se ejecutan como consecuencia de eventos (por ejemplo: un click sobre un elemento. Cuando se hace un click a un elemento, se llama un metodo especifico).

- Two-Way Binding: Es un ida y vuelta entre el template y una property entre un component. Muestra el valor de la property en la vista, y si en la vista/template dicho valor cambia, la property también se ve reflejada (por eso es de dos caminos). Esto lo veremos con más detalle en el tutorial de más abajo.

<p align="center">
<img src="./images/image-8.png">
</p>
<p align="center">
[Ejemplo de data binding]
</p>

Two-way binding (usado principalmente en [formularios](https://v17.angular.io/guide/forms)) combina los data binding de property y event en una sola notacion.

Data binding juega un rol importante en la comunicacion entre el template y su componente, y es tambien importante en la comunicacion entre un componente padre con sus componentes hijos.

<p align="center">
<img src="./images/image-9.png">
</p>
<p align="center">
[Esquema de componentes anidados]
</p>



