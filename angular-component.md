# Componentes

Los componentes controlan una porcion de la pantalla denominada vista. Consiste en una clase de TypeScript, un template HTML, y un estilado en CSS. La clase de TypeScript define la interaccion del codigo HTML con la estructura DOM, mientras que el codigo de estilado define la apariencia.

Una aplicacion de angular usa componentes individuales para definir y controlar diferentes aspectos de la aplicacion. Por ejemplo, una aplicacion puede incluir componentes para describir:

- La raiz de la aplicacion con la navegacion
- Una lista de peliculas
- Un editor de pelicula

Un componente puede contener una vista jerarquica, la cual permite definir de forma arbitraria areas determinadas de la pantalla que pueden ser creadas, modificadas y destruidas como unidad. Una vista jerarquica puede mezclar vistas definidas en componentes que declara otro modulo. Esto es lo mas comun sobretodo para librarias de UI.

Supongamos que tenemos los siguientes modulos y componentes declarados

<p align="center">
<img src="./images/image-4.png">
</p>
<p align="center">
[Modulos y componentes]
</p>

Y ahora se quiere que dichos componentes se usen entre si, teniendo como resultado la vista jerarquica.

<p align="center">
<img src="./images/image-3.png">
</p>
<p align="center">
[Ejemplo de uso jerarquico]
</p>

Cuando se crea un componente, este se asocia directamente con una sola vista, llamada vista host. La vista host puede ser la raiz de una vista jerarquica, la cual puede contener embebida otras vistas, que son las vistas host de otros componentes. Estos componentes pueden estar declarados en el mismo modulo, o pueden ser importados de un modulo distinto. Las vistas en el arbol pueden ser anidados en cualquier nivel.

Toda aplicacion de Angular tiene al menos un componente, el componente raiz que conecta la vista jerarquica con la pagina DOM (document object model). Cada componente define una clase que contiene logica y data de la aplicacion y esta asociada a un template HTML que define la vista a desplegarse en el ambiente.

El decorador a utilizar para declarar una clase como componente es @Component(). Los decoradores son funciones que modifican clases JavaScript. Angular define un numero de decoradoras que atachean metadata especifica a las clases, asi el sistema de Angular puede saber que significan esas clases y como deberian de operar y ser tratadas.

Ejemplo de componnete

```TypeScript
@Component({
  selector:    'app-movie-feed',
  templateUrl: './movie-feed.component.html',
})
export class MovieFeedComponent implements OnInit {
  /* . . . */
}
```

Los parametros mas importantes son:

| Parametro   | Detalles                                                                                                                                                                                                                                                                                           |
| ----------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| selector    | Un tag que le indica a Angular de crear e insertar una instancia del componente donde sea que encuentre dicho tag en un template HTML. Por ejemplo, si una vista HTML contiene <app-move-feed/>, entonces Angular insertara una instancia de la vista del componente MovieFeedComponent en ese tag |
| templateUrl | La ruta relativa del template HTML del componente. Alternativamente, se podria desarrollar el template HTML como valor de la property `template`. Este template HTML define la vista host del componente                                                                                           |

## Template HTML

La vista de un componente se define en el template HTML. Un template es un documento HTML que le indica a Angular como renderizar un componente.

<p align="center">
<img src="./images/image-5.png">
</p>
<p align="center">
[De codigo a renderizacion]
</p>

Las vistas son organizadas jerarquicamente, permitiendo modificar o mostrar y ocultar una seccion entera como una unidad. El template inmediatamente se asocia con el componente que lo define como la vista host. El componente tambien puede definir una vista jerarquica, la cual contiene vistas embebidas, hosteadas por otros componentes.

<p align="center">
<img src="./images/image-6.png">
</p>
<p align="center">
[Ejemplo de vista jerarquica]
</p>

