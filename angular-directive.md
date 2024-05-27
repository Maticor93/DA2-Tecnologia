# Directivas

Los templates de Angular son dinamicos. Cuando Angular los renderiza, transforma el DOM de acuerdo a las instrucciones dadas en las directivas. Una directive es una clase con el decorador @Directive().

Un componente es tecnicamente una directive. Sin embargo, los componentes son un aspecto distintivo y central para las aplicaciones de Angular que se definio el decorador @Component() que extiende de @Directive() con funcionalidades para templates.

A parte de los componentes, existen otros dos tipos de directivas: estructurales y atributos. Angular define un numero de directivas para ambos tipos, y uno puede definir las propias usando el decorador @Directive() en una clase.

## Directivas estructurales

Las directivas estructurales alteran la estructura del HTML al agregar, eliminar, y remplacar elementos en el DOM. El siguiente ejemplo utiliza dos directivas estructurales hechas por Angular para agregar logica en la aplicacion sobre como se deberia de renderizar la vista.

```HTML
<li *ngFor="let movie of movies"></li>
<app-movie-detail *ngIf="selectedMovie"></app-movie-detail>
```

| Directivas | Detalles                                                                                                          |
| ---------- | ----------------------------------------------------------------------------------------------------------------- |
| \*ngFor    | Un iterador que le permite a Angular crear un elemento `<li>` por cada pelicula en la lista de peliculas `movies` |
| \*ngIf     | Un condicional que incluye el componente `MovieDetail` solo si existe una pelicula seleccionada                   |

## Directivas atributo

Las directivas atributo alteran la apariencia o el comportamiento de un elemento existente. En los templates lucen muy similar a atributos HTML.

La directiva `ngModel`, que permite implementar two-way data binding, es un ejemplo de esta directiva. `ngModel` modifica el comportamiento de un elemento existente (tipicamente `<input>`) al setear el valor mostrado y respondiendo a los cambios de eventos.

```HTML
<input type="text" id="MOVIE-name" [(ngModel)]="movie.name">
```

Angular incluye directivas pre definidas que cambian:

- La estructura del layout, como `ngSwitch` y
- Aspectos de los elementos y componentes del DOM, como `ngStyle` y `ngClass`

## Lecturas recomendadas

- [Introduccion a directivas](https://v17.angular.io/guide/architecture-components#directives)

- [Directivas de Angular](https://v17.angular.io/guide/built-in-directives)

- [Directivas atributo](https://v17.angular.io/guide/attribute-directives)

- [Directivas estructurales](https://v17.angular.io/guide/structural-directives)

- [Composicion de una directiva](https://v17.angular.io/guide/directive-composition-api)

