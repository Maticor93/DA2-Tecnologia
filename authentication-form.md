[Atras - Indice](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-navigation)

# Navegacion post autenticacion

Una vez autenticado el usuario de forma exitosa, navegaremos al usuario a una ruta `home` que sera gestionada por un modulo `home`. El formulario de login sera utilizado por la pagina `authentication-page.component` bajo la ruta `login`.

Lo primero que debemos hacer es crear la ruta `login` que sera atendida por el componente `login-form.component` en el modulo `authenticacion-routing.module`, dejando este modulo de la siguiente manera:

```TypeScript
const routes: Routes = [
  {
    path: '',
    component: AuthenticationPageComponent,
    children: [
      {
        path: 'login',
        component: LoginFormComponent,
      },
      {
        path: '',
        redirectTo: 'login',
        pathMatch: 'full',
      },
    ],
  },
];
```

Lo siguiente a realizar es actualizar el template HTML del componente `authentication-page.component` para declarar el espacio dinamico, dejandolo de la siguiente manera:

```HTML
<router-outlet/>
```

Los cambios realizados en `authentication-routing.module`, configuran dos rutas, la ruta `login` cuyo template HTML es la del componente `login-form.component` y la ruta vacia `/` que redirecciona al login. Esto causa que cuendo se acceda a `https://localhost:4200/` se redireccione a `https://localhost:4200/login` y debemos de visualizar el formulario.

Cuando se ejecutemos la aplicacion deberiamos de ver lo siguiente:

<p align="center">
<img src="./images/image-1.png">
</p>

<p align="center">
[Ejecucion]
</p>

Podemos observar una parte estatica definida en `app.component` y la parte dinamica en `authentication-page` que despliega `login-form`.

Lo siguiente va a ser modificar el comportamiento de `login-form` para que navegue al usuario a una ruta `home` en caso de introducir valores correctos en los inputs.

Para eso modificaremos `login-form` de la siguiente manera:

```TypeScript
export class LoginFormComponent {
  // ...

  constructor(private readonly _router: Router) {}

  public onSubmit(values: any) {
    console.log(values);
    this._router.navigate(['/home']);
  }
}
```

`Router` es la dependencia en Angular que nos permitira redireccionar al usuario a otra parte de la aplicacion, para usar dicho elemento debemos modificar `authentication.module` de la siguiente manera:

```TypeScript
@NgModule({
  // ...
  imports: [
    // ...
    RouterModule,
  ],
})
export class AuthenticationModule {}
```

`RouterModule` es el modulo que declara y exporta el tipo `Router` para ser usado en otras partes de la aplicacion.

Si intentamos de ejecutar el codigo veremos un error de que `_router` es `undefined`, este error es porque al momento de pasarle la funcion `onSubmit` al componente `form.component`, esta referencia dentro del metodo es `undefined` y no se actualiza cuando una instancia de `Router` se inyecta en `login-form.component`. Para arreglar este error debemos de modificar `form.component`, dejandolo de la siguiente manera:

```TypeScript
export class FormComponent {
  @Input({ required: true }) form!: FormGroup;
  @Output() onSubmit = new EventEmitter<any>();

  public onLocalSubmit() {
    const isValid = this.form.valid;

    if (!isValid) {
      this.form.markAllAsTouched();
      return;
    }

    this.onSubmit.emit(this.form.value);
  }
}
```

Y en el template HTML donde se usa este componente se debera de cambiar el binding de `property` a `event` de la siguiente manera:

```HTML
<app-form ... (onSubmit)="onSubmit($event)">
  <!-- ... -->
</app-form>
```

Se arreglo el error `undefined` pero ahora se nos renderiza el template HTML del componente `page-not-found.component` en la ruta `/home`. Esto es porque aun no definimos esta ruta. Para ello definiremos un modulo de ruteo `home` y un componente `home-page` que se encargue de renderizar cuando se accede a esta ruta. Dicho modulo de ruteo debe estar situado dentro de `app`. Para crear el modulo debemos ejecutar lo siguiente:

```CMD
cd src
cd app
ng generate module home --routing
```

Y crearemos el componente `home-page` de la siguiente manera:

```CMD
cd home
ng generate component home-page --no-standalone
```

Una vez creado el modulo de ruteo y la pagina home, definiremos la ruta raiz `home` en `app-routing.module`, el cual nos debe quedar de la siguiente manera:

```TypeScript
const routes: Routes = [
  // ...
  {
    path: 'home',
    loadChildren: () => import('./home/home.module').then((m) => m.HomeModule),
  },
  // ...
];
// ...
```

Donde se esta definiendo la ruta `home` a nivel raiz. El paso siguiente es actualizar `home-routing.module` para que haga uso de `home-page.component`. Dejando `home-routing.module` de la siguiente manera:

```TypeScript
const routes: Routes = [
  {
    path: '',
    component: HomePageComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class HomeRoutingModule {}
```

Una vez terminada la implementacion de la ruta `home` veremos que el componente `page-not-found.component` no se renderiza sino que se renderiza `home-page.component` cuando accedemos a `home`.
