[Atras - Arquitectura de Angular](https://github.com/Maticor93/DA2-Tecnologia/blob/angular/angular-architecture.md)

# Directivas estructurales

Las directivas estructurales alteran la estructura del HTML al agregar, eliminar, y remplacar elementos en el DOM. El siguiente ejemplo utiliza dos directivas estructurales hechas por Angular para agregar logica en la aplicacion sobre como se deberia de renderizar la vista.

```HTML
<li *ngFor="let movie of movies"></li>

<app-movie-detail *ngIf="selectedMovie"></app-movie-detail>

<container-element [ngSwitch]="<<expresion>>">
  <some-element *ngSwitchCase="expresion matcheo 1">...</some-element>
  <some-element *ngSwitchDefault>...</some-element>
</container-element>
```

La directivas estructurales mas usadas son:

| Directivas | Detalles                                                                                                          |
| ---------- | ----------------------------------------------------------------------------------------------------------------- |
| \*ngFor    | Un iterador que le permite a Angular crear un elemento `<li>` por cada pelicula en la lista de peliculas `movies` |
| \*ngIf     | Un condicional que incluye el componente `MovieDetail` solo si existe una pelicula seleccionada                   |
| \*ngSwitch | Un set de directivas que intercala el uso de vistas                                                               |

Las directivas estructurales son directivas aplicadas a un elemento `ng-template` que condicionalmente o iterativa renderiza el contenido de ese elemento `ng-tempalte`.

## Forma corta de usar la directiva

Angular soporta una sintaxis corta para este tipo de directivas que evita la necesidad de explicitar el uso de un elemento `ng-template`.

Estas directivas pueden ser aplicadas directamente a un elemento usando el prefijo `*` en el atributo de la directiva, como por ejemplo `*ngIf`, `*ngFor`, `*ngSwitch`. Angular transforma el prefijo en un elemento `ng-template` que hostea la directiva y envuelve el elemento y sus hijos.

```HTML
<div *ngIf="<<boolean condition>>">
```

Este ejemplo muestra la flexibilidad de la sintaxis corta la cual es llamada microsyntax.

## Una directiva estructural por elemento

Solo se puede aplicar una directiva estructural por elemento cuando se usa de forma microsyntax. Esto es porque solo existe un elemento `ng-template` donde esa directiva cada envuelta. Multiples directivas requerira anidar elementos `ng-template`, y no es claro que directiva deberia de ir primero. `ng-container` puede ser usado para crear un envoltorio cuando multiples directivas necesitan ser aplicadas sobre un elemento DOM o componente, esto permite definir la estructura anidada.

## Creacion de una directiva custom

Crearemos una directiva que sirva para obtener data desde una fuente de informacion y lo renderice en un template cuando la data este disponible. La directiva se llamara `SelectDirective`, por la palabra reservada `SELECT` de `SQL` que matcheara con el atributo de la directiva `select`.

Esta directiva tendra un input que sea la fuente de la informacion, la cual llamaremos `selectFrom`.

Pudiendo usar la directiva de la siguiente manera:

```HTML
<p *select="let data from source">The data is: {{data}}</p>
```

La primera parte de la expresion `let data` define una variable `data` en el alcance del template. Como no sigue ningun tipo de asignacion, la variable de template esta ligada a la property `$implicit` del contexto del template.

La segunda parte de la expresion `from source`. `from` es una palabra clave para bindear y `source` es una expresion regular del template. Las properties de bindeo son mapeadas a properties transformadas a la sintaxis `PascalCase`. La palabra clave `from` es mapeada a `selectFrom`, que es despues combinada con la expresion `source`. Esto es la razon por la cual estas directivas tendran muchos inputs que son todos prefijados con el selector de la directiva.

### Creando la directiva

Para generar la directiva, utilizaremos Angular CLI y debemos ejecutar lo siguiente:

```CMD
ng generate directive select
```

### Hacer la directiva estructural

Debemos de inyectar `TemplateRef` y `ViewContainerRef`, dejando la clase de la directiva de la siguiente manera:

```TypeScript
import {Directive, TemplateRef, ViewContainerRef} from '@angular/core';
@Directive({
  standalone: true,
  selector: 'select',
})
export class SelectDirective {
  constructor(private templateRef: TemplateRef, private ViewContainerRef: ViewContainerRef) {}
}
```

### Agregar el input selectFrom

Agregamos la property `selectFrom` la cual es un input, dejando la clase asi:

```TypeScript
export class SelectDirective {
  // ...
  @Input({required: true}) selectFrom!: DataSource;
}
```

### Agregamos la logica de la directiva

Ahora la directiva estructurada como una directiva estructural con sus inputs, ahora es necesario agregar la logica que haga la obtencion de la data y renderice el template al cual esta aplicado la directiva.

```TypeScript
export class SelectDirective {
  // ...
  async ngOnInit() {
    const data = await this.selectFrom.load();
    this.viewContainerRef.createEmbeddedView(this.templateRef, {
      // Create the embedded view with a context object that contains
      // the data via the key `$implicit`.
      $implicit: data,
    });
  }
}
```

## Lecturas Recomendadas

- [Directivas estructurales](https://angular.dev/guide/directives/structural-directives#example-use-case)

- [Directivas estructurales](https://v17.angular.io/guide/structural-directives)

