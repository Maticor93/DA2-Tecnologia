[Atras - Arquitectura de Angular](https://github.com/daniel18acevedo/DA2-Tecnologia/blob/angular/angular-architecture.md)

## Directivas atributo

Las directivas atributo alteran la apariencia o el comportamiento de un elemento existente. En los templates lucen muy similar a atributos HTML.

La directiva `ngModel`, que permite implementar two-way data binding, es un ejemplo de esta directiva. `ngModel` modifica el comportamiento de un elemento existente (tipicamente `<input>`) al setear el valor mostrado y respondiendo a los cambios de eventos.

```HTML
<input type="text" id="MOVIE-name" [(ngModel)]="movie.name">

<!-- toggle the "special" class on/off with a property -->
<div [ngClass]="currentClasses">This div is special</div>

<div [ngStyle]="currentStyles">
  This div is initially italic, normal weight, and extra large (24px).
</div>
```

```TypeScript
export class AppComponent {
  currentClasses: Record<string, boolean> = {
    // CSS classes: added/removed per current state of component properties
      saveable: this.canSave,
      modified: !this.isUnchanged,
      special: this.isSpecial,
    };

  currentStyles: Record<string, string> = {
    // CSS styles: set per current state of component properties
      'font-style': this.canSave ? 'italic' : 'normal',
      'font-weight': !this.isUnchanged ? 'bold' : 'normal',
      'font-size': this.isSpecial ? '24px' : '12px',
  };
}

```

Angular pre define algunas directivas atributo como

| Directiva | Detalles                                       |
| --------- | ---------------------------------------------- |
| NgClass   | Agrega o elimina un set de clases CSS          |
| NgStyle   | Agrega o elimina un set the estilos HTML       |
| NgModel   | Agrega two-way data binding a un elemento HTML |

## Lecturas Recomendadas

- [Directivas atributo](https://angular.dev/guide/directives/attribute-directives)

