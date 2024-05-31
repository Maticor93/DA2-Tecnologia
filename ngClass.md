[Atras - Arquitectura de Angular](https://github.com/daniel18acevedo/DA2-Tecnologia/blob/angular/angular-architecture.md)

# ngClass

Agrega o elimina clases CSS en un elemento HTML.

En el elemento que queremos aplicarle estilado con clases CSS, agregar `[ngClass]` al que se le puede setear:

- `string`: las clases CSS listadas en un string con un espacio delimitador
- `Array`: las clases CSS declaradas en un Array
- `Object`: las clases CSS como properties del objeto con un `true` si se quieren usar o `false` en caso contrario

Por ejemplo el siguiente codigo, agrega la clase CSS `special` si la variable `isSpecial` es true

```HTML
<!-- toggle the "special" class on/off with a property -->
<div [ngClass]="isSpecial ? 'special' : ''">This div is special</div>
```

Tambien podemos usar la directiva teniendo una referencia a un objeto con aquellas clases CSS a usar o remover, teninedo lo siguiente:

```HTML
<div [ngClass]="currentClasses">This div is initially saveable, unchanged, and special.</div>
```

Y en la clase del componente:

```TypeScript
currentClasses: Record<string, boolean> = {
    // CSS classes: added/removed per current state of component properties
      saveable: this.canSave,
      modified: !this.isUnchanged,
      special: this.isSpecial,
    };
```

## Lecturas Recomendadas

- [NgClass](https://angular.dev/guide/directives#adding-and-removing-classes-with-ngclass)

- [Como usar](https://angular.dev/api/common/NgClass?tab=usage-notes)

