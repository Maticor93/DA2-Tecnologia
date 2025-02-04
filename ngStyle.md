[Atras - Arquitectura de Angular](https://github.com/Maticor93/DA2-Tecnologia/blob/angular/angular-architecture.md)

# ngStyle

Es una directiva atributo que actualiza el estado del elemento HTML al cual se aplica. Sete una o muchas properties de estilado, especificadas con como un par clave-valor separadas por una coma. La clave es el nombre de la property. El valor es una expresion a ser evaluada. El resultado no-null, es asignado a la property de estilado, si el valor es null dicha property es eliminada.

El nombre del estilo puede tener como opcional el sufijo de la unidad a agregar como `top.px`, `font-style.em`.

Por ejemplo, se puede usar de forma inline:

```HTML
<some-element [ngStyle]="{'font-style': styleExp, 'max-width.px':widthExp'}">...</some-element>
```

O usando un objeto:

```HTML
<div [ngStyle]="currentStyles">
  This div is initially italic, normal weight, and extra large (24px).
</div>
```

Y en la clase del componente:

```TypeScript
currentStyles: Record<string, string> = {
    // CSS styles: set per current state of component properties
      'font-style': this.canSave ? 'italic' : 'normal',
      'font-weight': !this.isUnchanged ? 'bold' : 'normal',
      'font-size': this.isSpecial ? '24px' : '12px',
  }
```

## Lecturas Recomendadas

- [NgStyle](https://angular.dev/guide/directives#setting-inline-styles-with-ngstyle)

- [Como usar](https://angular.dev/api/common/NgStyle?tab=usage-notes)

