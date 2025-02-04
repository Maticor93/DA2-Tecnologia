[Atras - Indice](https://github.com/Maticor93/DA2-Tecnologia/tree/angular-component)

# Implementacion de la autenticacion

El modulo de autenticacion es el encargado de declarar aquellos componentes necesarios para loguear usuarios.

El primer paso sera crear el componente `login-form` que encapsulara la definicion del formulario para realizar el login. Para esto nos debemos de situar en el directorio `authentication` y crear el componente con Angular CLI.

```CMD
cd src
cd app
cd authentication
ng generate component login-form --no-standalone
```

Esto nos debio de crear dos archivos, `login-form.component.ts` y `login-form.component.html`, el cual sera declarado en el modulo `authentication.module.ts`.

En este componente vamos a necesitar: un titulo, un input para el email, un input para la password y un boton para el login.

El template HTML nos deberia de quedar asi:

```HTML
<h1>Bienvenido a MyServiceApp</h1>

<form [formGroup]="loginForm" (ngSubmit)="onSubmit()">
  <input type="text" placeholder="email@example.com" formControlName="email" />
  <small *ngIf="errorEmail">{{ errorEmail }}</small>

  <input placeholder="*****" type="password" formControlName="password" />
  <small *ngIf="errorPassword">{{ errorPassword }}</small>

  <button type="submit">Login</button>
</form>

```

Y la logica del componente asi:

```TypeScript
export class LoginFormComponent {
  private readonly formField: any = {
    email: {
      name: "email",
      required: "Email es requerido",
      email: "Email no es valido",
    },
    password: {
      name: "password",
      required: "Contraseña es requerida",
      minlength: "Contraseña debe tener al menos 6 caracteres",
    },
  };

  loginForm = new FormGroup({
    [this.formField.email.name]: new FormControl("", [
      Validators.required,
      Validators.email,
    ]),
    [this.formField.password.name]: new FormControl("", [
      Validators.required,
      Validators.minLength(6),
    ]),
  });

  get errorEmail() {
    return this.getError(this.formField.email.name);
  }

  get errorPassword() {
    return this.getError(this.formField.password.name);
  }

  getError(key: string): string | null {
    const element = this.loginForm.get(key)!;

    if (!element.errors || !element.touched) {
      return null;
    }

    const errorKey = Object.keys(element.errors)[0];

    return this.formField[key][errorKey];
  }

  public onSubmit() {
    const isValid = this.loginForm.valid;

    if (!isValid) {
      this.loginForm.markAllAsTouched();
      return;
    }

    console.log(this.loginForm.value);
  }
}
```

Este formulario fue construido con el approach [reactive-forms](https://github.com/Maticor93/DA2-Tecnologia/blob/angular-component/forms.md).

El comportamiento de este formulario validara los valores de los inputs a medida que se actualicen y en caso de encontrar algun error desplegara el mensaje de error correspondiente. En caso de que el usuario haga click de `Login` sin pasar por los inputs, este los marcara a todos como tocados para desplegar los mensajes de error. Una vez arreglados los errores y al hacer click en `Login`, se imprimiran por consola los valores puestos en los inputs como modo de confirmacion de los inputs.

Si nuestra aplicacion hace uso de muchos formularios, tenemos un potencial problema ya que todos van a requerir un template HTML similar y logicas similares. Estamos ante una situacion de duplicacion de codigo la cual puede generar un impacto negativo para la mantenibilidad de la aplicacion.

Lo unico que deberia de definir el componente `login-form` u otro formulario del negocio son los elementos: `formField`, `form` y `onSubmit` asumiendo que siempre se ejecuta cuando todos los valores estan bien. Todo el resto de elementos los debemos de mover a otro lado para reutilizarlo siempre que los necesitemos.

Para generar este refactor vamos a crear la carpeta `form-elements` en la carpeta `components`. Los componentes situados en este directorio tendran que ver con todo lo relacionado a un formulario.

Los componentes que crearemos son los siguients: `form`, `form-input` y `form-button`.

Antes de crearlos nos situaremos en el directorio correspondiente:

```CMD
cd src
cd components
mkdir form-elements
cd form-elements
```

Y ejecutaremos

```CMD
ng generate component form
ng generate component form-input
ng generate component form-button
```

Los elementos `form-input` y `form-button` son variaciones de los elementos `input` y `button` especificos para la manipulacion dentro de un formulario. Es por eso que no se usa `input` ni `button`.

El componente `form.component.html` debe definir dos parametros:

- `form`: el `FormGroup` que estara gestionando
- `onSubmit`: funcion que recibe los valores correctos y solo sera ejecutado cuando no existan errores

El template HTML del componente se ve asi:

```HTML
<form [formGroup]="form" (ngSubmit)="onLocalSubmit()">
  <ng-content />
</form>
```

`ng-content` es un elemento de Angular que le permite al componente aceptar hijos.

La logica del componente se ve asi:

```TypeScript
@Component({
  // ...
  imports: [ReactiveFormsModule],
  // ...
})
export class FormComponent {
  @Input({ required: true }) form!: FormGroup;
  @Input({ required: true }) onSubmit!: (values: any) => void;

  public onLocalSubmit() {
    const isValid = this.form.valid;

    if (!isValid) {
      this.form.markAllAsTouched();
      return;
    }

    this.onSubmit(this.form.value);
  }
}
```

Para usar dicho componente en `login-form` es necesario importarlo en el modulo `authentication`. Dejando el modulo `Authentication asi:

```TypeScript
@NgModule({
  // ...
  imports: [
    // ...
    FormComponent,
  ],
  // ...
})
export class AuthenticationModule {}
```

Este refactor impacta en el componente `login-form` de la siguiente manera, en el template HTML:

```HTML
<h1>Bienvenido a MyServiceApp</h1>

<app-form [form]="loginForm" [onSubmit]="onSubmit">
  <!-- ... -->
</app-form>
```

Y en la logica del componente asi:

```TypeScript
export class LoginFormComponent {
  // ...
  public onSubmit(values: any) {
    console.log(values);
  }
}
```

La proxima implementacion es la de `form-input`, el cual tiene que definir los siguientes parametros:

- `type`: tipo del input
- `label`: etiqueta a desplegar
- `placeholder`: ejemplo de valor a desplegar
- `name`: nombre del campo en el form-group
- `form`: form-group donde pertenece el control
- `formField`: configuracion de mensajes de error

La implementacion del template HTML seria de la siguiente manera:

```HTML
<app-input
  [type]="type"
  [label]="label"
  [placeholder]="placeholder"
  [(value)]="value" />
<small *ngIf="error">{{ error }}</small>
```

Como podemos ver estamos reusando y extendiendo la implementacion del componente esqueleto `input`.

Y la implementacion de la logica del componente asi:

```TypeScript
@Component({
  // ...
  imports: [ReactiveFormsModule, NgIf, InputComponent],
  // ...
})
export class FormInputComponent {
  @Input() type: "text" | "number" | "password" = "text";
  @Input() label: string | null = null;
  @Input() placeholder: string | null = null;
  @Input({ required: true }) name!: string;
  @Input({ required: true }) form!: FormGroup;
  @Input({ required: true }) formField!: any;

  get error() {
    const control = this.form.get(this.name)!;

    if (!control.errors || !control.touched) {
      return null;
    }

    const errorKey = Object.keys(control.errors)[0];

    return this.formField[this.name][errorKey];
  }

  get value() {
    return this.form.get(this.name)!.value;
  }

  set value(value: string) {
    this.form.get(this.name)!.setValue(value);
  }
}
```

Para usar dicho componente en `login-form` es necesario importarlo en el modulo `authentication`. Dejando el modulo `Authentication asi:

```TypeScript
@NgModule({
  // ...
  imports: [
    // ...
    FormInputComponent,
  ],
  // ...
})
export class AuthenticationModule {}
```

Este refactor impacta en el componente `login-form` de la siguiente manera, en el template HTML:

```HTML
<h1>Bienvenido a MyServiceApp</h1>

<app-form [form]="loginForm" [onSubmit]="onSubmit">
  <app-form-input
    type="text"
    placeholder="email@example.com"
    [name]="formField.email.name"
    [form]="loginForm"
    [formField]="formField" />

  <app-form-input
    type="password"
    placeholder="*****"
    [name]="formField.password.name"
    [form]="loginForm"
    [formField]="formField" />

    <!-- ... -->

</app-form>
```

Y en la logica del componente se eliminan los metodos `get errorEmail`, `get errorPassword` y `getError`.

La ultima implementacion es la de `form-button`, el cual tiene que definir los siguientes parametros:

- `title`: titulo del boton

La implementacion del template HTML seria de la siguiente manera:

```HTML
<button type="submit">{{title}}</button>
```

Y la implementacion de la logica del componente asi:

```TypeScript
export class FormButtonComponent {
  @Input({ required: true }) title!: string;
}
```

Para usar dicho componente en `login-form` es necesario importarlo en el modulo `authentication`. Dejando el modulo `Authentication asi:

```TypeScript
@NgModule({
  // ...
  imports: [
    // ...
    FormButtonComponent,
  ],
  // ...
})
export class AuthenticationModule {}
```

Este refactor impacta en el componente `login-form` de la siguiente manera, en el template HTML:

```HTML
<h1>Bienvenido a MyServiceApp</h1>

<app-form [form]="loginForm" [onSubmit]="onSubmit">
  <!-- ... -->

  <app-form-button title="Login"/>
</app-form>
```

Si ejecutamos nuestro codigo veremos que el comportamiento permanece invariante, pero ahora tenemos componentes reusables para facilitar la creacion y mantenimiento de los formularios en nuestra aplicacion.

Como las directivas de reactive-forms no los usamos directamente en `login-form` sino que mediante los componentes recien creados, `form`, `form-input` y `form-button`, podemos eliminar la importacion de `ReactiveFormModule` del modulo `authentication.module.ts`.

