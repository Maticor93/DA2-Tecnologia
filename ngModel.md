[Atras - Arquitectura de Angular](https://github.com/Maticor93/DA2-Tecnologia/blob/angular/angular-architecture.md)

# ngModel

Usar esta directiva para desplegar data obtenida desde la logica del componente o para actualizarla cuando el usuario realiza cambios.

Para hacer uso de dicha directiva es necesario importar el modulo `FormsModule` de Angular.

Por ejemplo, el siguiente codigo muestra como usar dicha directiva:

```HTML
<label for="example-ngModel">[(ngModel)]:</label>
    <input [(ngModel)]="currentItem.name" id="example-ngModel">
```

Esta notacion combina los bindeos property-binding y event-binding, haciendo que no tengamos que construir elementos diferentes para manejar el estado de la misma variable.

La version larga seria de la siguiente manera:

```HTML
<input [ngModel]="currentItem.name" (ngModelChange)="setUppercaseName($event)" id="example-uppercase">
```

<p align="center">
<img src="./images/ng-model-anim.gif"/>
</p>

<p align="center">
[Funcionamiento two-way binding]
</p>

## Funcionamiento de ngModel

`NgModel` funciona para aquellos elementos que soportan [`ControlValueAccessor`](https://angular.dev/api/forms/ControlValueAccessor). Angular provee value accessors para todos los elementos basicos de HTML. Para mas informacion ver [Formularios](https://angular.dev/guide/forms).

Para aplicar `[(ngModel)]` a un elemento que no pertenece a un formulario o a un componente custom de una libreria de terceros, es necesario desarrollar un value accessor. Para mas informacion sobre value accessor ver la [API](https://angular.dev/api/forms/DefaultValueAccessor/).

## Lecturas Recomendadas

- [NgModel](https://angular.dev/guide/directives#displaying-and-updating-properties-with-ngmodel)
