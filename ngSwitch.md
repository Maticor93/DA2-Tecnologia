[Atras - Arquitectura de Angular](https://github.com/Maticor93/DA2-Tecnologia/blob/angular/angular-architecture.md)

# NgSwitch

La directiva `ngSwitch` o mas especificamente contenedor de una expresion a la cual matchear. Las expresiones con las cuales debe matchear son provistas por la directiva `ngSwitchCase` en vistas dentro del contenedor.

- Cada vista que matchea con la condicion se renderiza
- Si no hay matcheos, la vista con la directiva `ngSwitchDefault` es renderizada
- Elementos dentro de un contenedor `ngSwitch` pero sin las directivas `ngSwitchCase` o `ngSwitchDefault` mantendran su lugar en la renderizacion

El siguiente ejemplo muestra como usar el contendor:

```HTML
<container-element [ngSwitch]="switch_expression">
```

Y dentro del contenedor, se deberan de encontrar declaraciones para los casos de matcheo para la expresion. teniendo como resultado:

```HTML
<container-element [ngSwitch]="switch_expression">
   <some-element *ngSwitchCase="match_expression_1">...</some-element>
...
   <some-element *ngSwitchDefault>...</some-element>
</container-element>
```

## Lecturas Recomendadas

- [ngSwitch](https://angular.dev/api/common/NgSwitch)

