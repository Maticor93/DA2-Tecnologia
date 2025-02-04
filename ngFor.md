[Atras - Arquitectura de Angular](https://github.com/Maticor93/DA2-Tecnologia/blob/angular/angular-architecture.md)

# ngFor

Es una directiva estructural que renderiza el template de cada elemento en una coleccion. La directiva es usada en un elemento, y se convierte en padre del template clonado.

La directiva `ngForOf` es usada generalmente como `*ngFor`. De esta forma, el template a renderizar para cada elemento de la iteracion es el elemento al que se le aplica la directiva.

El siguiente ejemplo muestra la microsintax de la directiva usada en un elemento `li`:

```HTML
<li *ngFor="let item of items; index as i; trackBy: trackByFn">...</li>
```

Angular transforma la microsintax a la forma mas completa usando el selector `ngForOf` en un elemento `ng-template`. El contenido del elemento `ng-template` es el elemento `li` de la version microsintax.

Aca podemos ver la forma expandida de la version microsintax de la directiva:

```HTML
<ng-template ngFor let-item [ngForOf]="items" let-i="index" [ngForTrackBy]="trackByFn">
  <li>...</li>
</ng-template>
```

Angular automaticamente expande la sintaxis microsintax cuando compila el template. El contexto de cada vista anidada es mergeada logicamente al componente actual segun la posicion.

## Lecturas Recomendadas

- [ngFor](https://angular.dev/api/common/NgFor)

