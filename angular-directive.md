[Atras - Arquitectura de Angular](https://github.com/daniel18acevedo/DA2-Tecnologia/blob/angular/angular-architecture.md)

# Directivas

Los templates de Angular son dinamicos. Cuando Angular los renderiza, transforma el DOM de acuerdo a las instrucciones dadas en las directivas. Una directiva es una clase con el decorador `@Directive()`.

Un componente es tecnicamente una directiva. Sin embargo, los componentes son un aspecto distintivo y central para las aplicaciones de Angular que se definio el decorador @Component() que extiende de `@Directive()` con funcionalidades para templates.

Las directivas ofrecen un excelente nivel de encapsulacion para comportamientos reusables, estos pueden ser aplicados a atributos, clases CSS y eventos de un elemento.

La composicion de una directiva permite aplicar la directiva a un componente host.

Existen dos tipos de directivas: `estructurales` y `atributos`. Angular define un numero de directivas para ambos tipos, y uno puede definir las propias usando el decorador `@Directive()` en una clase.

## Agregando una directiva a un componente

Las directivas son aplicadas a un componente al agregar la property `hostDirective` al decorador de un componente. Tales directivas son llamadas directivas host.

Por ejemplo, aplicaremos la directiva `MenuBehavior` al elemento host `AdminMenu`. Teniendo el componente `AdminMenu` de la siguiente manera:

```TypeScript
@Component({
  standalone: true,
  selector: 'admin-menu',
  template: 'admin-menu.html',
  hostDirectives: [MenuBehavior],
})
export class AdminMenu { }
```

Cuando Angular renderice el componente, tambien creara una instancia de cada directiva host. Las directivas usadas en la property `hostDirectives` deben de ser `standalone` y tambien Angular ignora el selector de la directiva.

## Inputs y outputs

Cuando aplicamos directivas host a un componente, los inputs y otuputs de la directiva host no son incluidos en la API del componente por defecto. Es necesario explicitar estas properties en la API del componente al expandir la declaracion de la directiva host, teniendo como resultado lo siguiente:

```TypeScript
@Component({
  standalone: true,
  selector: 'admin-menu',
  template: 'admin-menu.html',
  hostDirectives: [{
    directive: MenuBehavior,
    inputs: ['menuId'],
    outputs: ['menuClosed'],
  }],
})
export class AdminMenu { }
```

Al especificar de forma explicita los inputs y outputs los consumidores del componente pueden pasar informacion a dichos properties de la siguiente manera:

```HTML
<admin-menu menuId="top-menu" (menuClosed)="logMenuClosed">
```

En caso de conflictos o de mantenibilidad, se pueden generar alias a dichos inputs y outputs para customizar la API del componente, teniendo como resultado:

```TypeScript
@Component({
  standalone: true,
  selector: 'admin-menu',
  template: 'admin-menu.html',
  hostDirectives: [{
    directive: MenuBehavior,
    inputs: ['menuId: id'],
    outputs: ['menuClosed: closed'],
  }],
})
export class AdminMenu { }
```

```HTML
<admin-menu id="top-menu" (closed)="logMenuClosed">
```

## Agregando una directiva a otra directiva

La property `hostDirectives` tambien es parte de las directivas, permitiendo anidar directivas entre ellas. Esto permite la transitividad de agregar multiples comportamientos reusables.

En el siguiente ejemplo se definira dos directivas, `Menu` y `Tooltip`, para luego componer el comportamiento de una tercer directiva `MenuWithTooltip` la cual sera utilizada en `SpecializedMenuWithTooltip`.

Cuando `SpecializedMenuWithTooltip` sea usado en un template HTML, creara una instancia de `Menu`, `Tooltip` y `MenuWithTooltip`. Teniendo el siguiente codigo:

```TypeScript
@Directive({...})
export class Menu { }
@Directive({...})
export class Tooltip { }
// MenuWithTooltip can compose behaviors from multiple other directives
@Directive({
  standalone: true,
  hostDirectives: [Tooltip, Menu],
})
export class MenuWithTooltip { }
// CustomWidget can apply the already-composed behaviors from MenuWithTooltip
@Directive({
  standalone: true,
  hostDirectives: [MenuWithTooltip],
})
export class SpecializedMenuWithTooltip { }
```

## Orden de ejecucion

Las directivas host siguen el mismo ciclo de vida del componente y directivas que las usan directamente en su template. Sin embargo, las directivas host siempre ejecutan su constructor, sus metodos de ciclos de vida, y bindeos antes del componente o directiva en donde estan siendo utilizados.

Por ejemplo el siguiente codigo:

```TypeScript
@Component({
  standalone: true,
  selector: 'admin-menu',
  template: 'admin-menu.html',
  hostDirectives: [MenuBehavior],
})
export class AdminMenu { }
```

Tendra el siguiente orden de ejecucion:

1. `MenuBehavior` instanciado
2. `AdminMenu` instanciado
3. `MenuBehavior` recibe inputs en `ngOnInit`
4. `AdminMenu` recibe inputs en `ngOnInit`
5. `MenuBehavior` aplica bindeos
6. `AdminMenu` aplica bindeos

Esto tambien se aplica para las anidaciones:

```TypeScript
@Directive({...})
export class Tooltip { }
@Directive({
  standalone: true,
  hostDirectives: [Tooltip],
})
export class CustomTooltip { }
@Directive({
  standalone: true,
  hostDirectives: [CustomTooltip],
})
export class EvenMoreCustomTooltip { }
```

Teniendo el siguiente orden de ejecucion:

1. `Tooltip` instanciado
2. `CustomTooltip` instanciado
3. `EvenMoreCustomTooltip` instanciado
4. `Tooltip` recibe inputs en `ngOnInit`
5. `CustomTooltip` recibe inputs en `ngOnInit`
6. `EvenMoreCustomTooltip` recibe inputs en `ngOnInit`
7. `Tooltip` aplica bindeos
8. `CustomTooltip` aplica bindeos
9. `EvenMoreCustomTooltip` aplica bindeos

## Lecturas recomendadas

- [API de una directiva](https://angular.dev/guide/directives/directive-composition-api)

- [Introduccion a directivas](https://v16.angular.io/guide/architecture-components#directives)

- [Directivas de Angular](https://v17.angular.io/guide/built-in-directives)
