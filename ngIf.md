[Atras - Arquitectura de Angular](https://github.com/Maticor93/DA2-Tecnologia/blob/angular/angular-architecture.md)

# ngIf

Es una directiva estructural condicional que incluye un template HTML dependiendo del valor de una expresion booleana. Cuando la expresion evalua `true`, Angular renderizara el template provisto en el caso `then`, y cuando es `false` o `null`, Angular renderizara el template provisto en el caso opcional `else`. El valor por defecto para el caso `else` es algo vacio.

La microsintax de la directiva es `*ngIf="condicion booleana"`, la cual es usada generalmente y es provista como un atributo al elemento que queremos renderizar segun la condicion. Angular al detectar esto, lo transforma a una version mas explicita, en donde el elemento es contenido en un elemento `ng-template`. Por ejemplo:

Uso con microsintax:

```HTML
<div *ngIf="condition">Content to render when condition is true.</div>
```

Como Angular lo transforma:

```HTML
<ng-template [ngIf]="condition"><div>Content to render when condition is
true.</div></ng-template>
```

En caso de querer usar un `else`:

```HTML
<div *ngIf="condition; else elseBlock">Content to render when condition is true.</div>
<ng-template #elseBlock>Content to render when condition is false.</ng-template>
```

U otra opcion seria:

```HTML
<div *ngIf="condition; then thenBlock else elseBlock"></div>
<ng-template #thenBlock>Content to render when condition is true.</ng-template>
<ng-template #elseBlock>Content to render when condition is false.</ng-template>
```

Tambien podriamos guardar el valor de la condicion para desplegarlo en una variable del template de la siguiente manera:

```HTML
<div *ngIf="condition as value; else elseBlock">{{value}}</div><ng-template #elseBlock>Content to render when value is null.</ng-template>
```

## Lecturas Recomendadas

- [ngIf](https://angular.dev/api/common/NgIf)

