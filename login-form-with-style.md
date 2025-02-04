[Atras - Indice](https://github.com/Maticor93/DA2-Tecnologia/tree/angular-style)

# Aplicando estilos a `login-form`

En esta seccion aplicaremos estilos a los elementos necesarios de `login-form`. Centraremos el titulo y el formulario a la pagina, definiremos espacios entre los elementos, alinearemos de forma vertical el formulario, definiremos una `card` y otros estilos. Tambien le definiremos estilos al componente `navbar` usado en `home`.

## Estilo de `login-form`

Pasaremos a modificar el template HTML de `login-form` para alinear de forma vertical los elementos:

```HTML
<div class="container">
  <div class="row justify-content-center mb-3">
    <div class="col-auto">
      <h1>Bienvenido a MyFinalApp</h1>
    </div>
  </div>

  <app-form [form]="loginForm" (onSubmit)="onSubmit($event)">
    <div class="row justify-content-center mb-3">
      <div class="col-4">
        <app-form-input
          type="text"
          label="Email"
          placeholder="email@example.com"
          [name]="formField.email.name"
          [form]="loginForm"
          [formField]="formField" />
      </div>
    </div>

    <div class="row justify-content-center mb-4">
      <div class="col-4">
        <app-form-input
          type="password"
          label="Password"
          placeholder="*****"
          [name]="formField.password.name"
          [form]="loginForm"
          [formField]="formField" />
      </div>
    </div>

    <div class="row justify-content-center">
      <div class="col-auto">
        <div *ngIf="loginStatus?.loading; else notLoading">Cargando...</div>

        <ng-template #notLoading>
          <div *ngIf="loginStatus?.error">{{ loginStatus!.error }}</div>
          <app-form-button title="Login" color="primary" />
        </ng-template>
      </div>
    </div>
  </app-form>
</div>
```

Realizar esta implementacion llevo a modificar los templates HTML de los componentes `form-input`, `input` y `form-button`.

El template HTML del componente `form-input` debera de quedar de la siguiente manera:

```HTML
<app-input
  [type]="type"
  [label]="label"
  [placeholder]="placeholder"
  [(value)]="value" />
<small *ngIf="error" [ngStyle]="{ color: 'var(--bs-form-invalid-color)' }">{{
  error
}}</small>
```

Y su logica asi:

```TypeScript
@Component({
  // ...
  imports: [ReactiveFormsModule, NgIf, InputComponent, NgStyle],
  // ...
})
```

Luego el template HTML del componente `input` nos debe quedar de la siguiente manera:

```HTML
<label *ngIf="label" class="form-label">{{ label }}</label>
<input
  class="form-control"
  [placeholder]="placeholder"
  [type]="type"
  [value]="value"
  (input)="onValueChange($event)" />
```

Y por ultimo el template HTML del componente `form-button` nos debe quedar de la siguiente manera:

```HTML
<button [ngClass]="['btn', colorClass()]" type="submit">{{ title }}</button>
```

Y su logica asi:

```TypeScript
@Component({
  selector: "app-form-button",
  standalone: true,
  imports: [NgClass],
  templateUrl: "./form-button.component.html",
  styles: ``,
})
export class FormButtonComponent {
  @Input({ required: true }) title!: string;
  @Input() color:
    | 'primary'
    | 'secondary'
    | 'success'
    | 'danger'
    | 'warning'
    | 'info'
    | 'light'
    | 'dark'
    | 'link' = 'dark';

  public colorClass(): string {
    return `btn-${this.color}`;
  }
}
```

## Resultado final

El resultado final es el siguiente:

<p align="center">
<img src="./images/image-12.png">
</p>
<p align="center">
[Formulario inicial]
</p>

<p align="center">
<img src="./images/image-13.png">
</p>
<p align="center">
[Formulario validado]
</p>

Como vemos entre los botones se esta duplicando logica y en el template HTML del componente `login-form` podemos ver muchas notaciones de HTML y clases de `bootstrap` que podrian encapsularse en componentes fuertemente tipados para facilitar la creacion de estructuras que queremos repetir como un formulario centrado y alineado de forma vertical.

## Estilo `navbar`

A continuacion modificaremos el estilado del componente `navbar` para que se vea de la siguiente manera:

<p align="center">
<img src="./images/image-14.png">
</p>
<p align="center">
[Navbar de bootstrap con elementos centrados]
</p>

[En construccion...]

## Codigos

- [MyFinalApp](https://github.com/Maticor93/DA2-Tecnologia/tree/angular-style/1-%20Angular%20application/MyFinalApp)

