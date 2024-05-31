## Directivas atributo

Las directivas atributo alteran la apariencia o el comportamiento de un elemento existente. En los templates lucen muy similar a atributos HTML.

La directiva `ngModel`, que permite implementar two-way data binding, es un ejemplo de esta directiva. `ngModel` modifica el comportamiento de un elemento existente (tipicamente `<input>`) al setear el valor mostrado y respondiendo a los cambios de eventos.

```HTML
<input type="text" id="MOVIE-name" [(ngModel)]="movie.name">
```

Angular pre define algunas directivas atributo como

| Directiva | Detalles                                       |
| --------- | ---------------------------------------------- |
| NgClass   | Agrega o elimina un set de clases CSS          |
| NgStyle   | Agrega o elimina un set the estilos HTML       |
| NgModel   | Agrega two-way data binding a un elemento HTML |



## Lecturas Recomendadas

- [Directivas atributo](https://angular.dev/guide/directives/attribute-directives)

