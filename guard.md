[Atras - Indice](https://github.com/Maticor93/DA2-Tecnologia/tree/angular-navigation)

# Guard

Por el momento cualquier usuario puede navegar sin restricciones por la aplicacion en cualquier momento, pero algunas veces se necesita tener un control de acceso para diferentes rutas de la aplicacion por diversas razones, algunas de ellas pueden ser:

- Un usuario no autenticado quiere navegar a un componente que no deberia

- Antes de acceder a cualquier elemento se debe pasar por un proceso de autenticacion

- Capaz que se deberia de obtener cierta data antes de renderizar el componente

- Se podrian guardar cambios pendientes antes de dejar el componente

- Se podria preguntarle al usuario si se pueden descartar los cambios pendientes en lugar de salvarlos.

Para manejar estos escenarios y mas, se configuran las rutas para que utilicen `guards`

El valor que retornen las `guards` determinaran el comportamiento de la navegacion de la siguiente manera:

| Valor que retorna la `guard` | Detalles                                                                                                                                                          |
| ---------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `true`                       | El proceso de navegacion continua                                                                                                                                 |
| `false`                      | El proceso de navegacion se ve interrumpido y el usuario queda pendiente                                                                                          |
| `UrlTree`                    | La navegacion actual se cancela y una nueva navegacion se inicializa con el `UrlTree` retornado. Se utiliza para navegar al usuario a otro lado de la aplicacion. |

El `router` puede soportar multiples tipos de guards:

| Guard              | Detalles                                                                         |
| ------------------ | -------------------------------------------------------------------------------- |
| `canActivate`      | Mediar navegacion a una ruta                                                     |
| `canActivateChild` | Mediar navegacion a una ruta hija                                                |
| `canDeactivate`    | Mediar navegacion para afuera de la ruta actual                                  |
| `resolve`          | Realizar la obtencion de data antes de activar la ruta                           |
| `canMatch`         | Controlar si `Route` deberia de ser usado, incluso si la ruta matchea con la URL |

Se pueden tener multiples `guards` en cada nivel de una jerarquia de rutas. El `router` chequea las `guards` `canDeactivate` primero, desde la ruta hija mas profunda hasta arriba. Luego chequea las `guards` `canActivate` y `canActivateChild` desde arriba hasta la ruta hija mas profunda. Si el modulo es cargado de forma asincrona, la `guard` `canMatch` es chequeada antes de que el modulo es sea cargado.

A excepcion de `canMatch`, si cualquiera de las `guards` retorna `false`, cualquier `guard` pendiente que no terminara de ejecutarse sera cancelada, por ende, la navegacion entera es cancelada. Si una `guard` `canMatch` retorna `false`, el `router` continua procesando el resto de rutas para ver si una ruta diferente matchea con el URL.

## Creacion

Las guardas las vamos a guardar en una carpeta llamada `guards` dentro de `src`. Para ello ejecutaremos:

```CMD
cd src
mkdir guards
```

Y crearemos una `guard` que valide si el usuario este autenticado para poder acceder a la ruta, dicha `guard` debe ser de tipo `canActivate`. Para ello ejecutaremos:

```CMD
cd guards
ng generate guard auth
```

Y seleccionaremos la opcion de `CanActivate`:

<p align="center">
<img src="./images/image-2.png">
</p>
<p align="center">
[Respuesta a pregunta]
</p>

Esto nos creara lo siguiente:

```TypeScript
export const authGuard: CanActivateFn = (route, state) => {
  return true;
};
```

Esta `guard` la usaremos para indicar que se tiene que estar autenticado para acceder a las rutas: `home`, `users` y `movies`, modificando `app-routing.module` de la siguiente manera:

```TypeScript
const routes: Routes = [
  {
    path: 'users',
    canActivate: [authGuard],
    loadChildren: () => import('./user/user.module').then((m) => m.UserModule),
  },
  {
    path: 'movies',
    canActivate: [authGuard],
    loadChildren: () =>
      import('./movie/movie.module').then((m) => m.MovieModule),
  },
  {
    path: 'home',
    canActivate: [authGuard],
    loadChildren: () => import('./home/home.module').then((m) => m.HomeModule),
  },
  // ...
];
```

Por el momento solo creamos la `guard` y configuramos en donde se deben de utilizar, pero dicha implementacion por si sola no verifica nada. Modifiquemos la `guard` para que chequee si el usuario esta autenticado usando [`localstorage`](https://www.w3schools.com/jsref/prop_win_localstorage.asp), nos deberia de quedar de la siguiente manera:

```TypeScript
export const authGuard: CanActivateFn = (route, state) => {
  const isLoggedIn = localStorage.getItem('isLoggedIn') !== null;
  return isLoggedIn;
};
```

Y para setear un valor en dicha key, modificaremos la logica de login en `login-form.component` de la siguiente manera:

```TypeScript
export class LoginFormComponent {
  // ...
  public onSubmit(values: any) {
    console.log(values);
    localStorage.setItem('isLoggedIn', 'true');
    this._router.navigate(['/home']);
  }
}
```

Una vez todo implementado, cuando queramos acceder a una ruta protegida sin estar autenticado, lo unco que veremos es la parte estatica de `app.component`. A continuacion modificaremos la `guard` para que nos redireccione al `login` en ese caso. Dejando `authGuard` de la siguiente manera:

```TypeScript
export const authGuard: CanActivateFn = (route, state) => {
  const isLoggedIn = localStorage.getItem('isLoggedIn') !== null;

  if (!isLoggedIn) {
    const router = inject(Router);

    return router.parseUrl('/login');
  }

  return true;
};
```

Estas modificaciones lo que implican es que en caso de que el usuario no este autenticado sea redireccionado a la ruta `login` al retornar un `UrlTree`, y en caso de que este autenticado retorna `true` para permitir el acceso a la ruta.

Una vez implementado dicha modificacion, cuando queramos acceder a una ruta protegida por `authGuard` la misma nos redireccionara a `login`.

Creemos otra `guard` que haga el comportamiento inverso, donde solo usuarios no autenticados, puedan acceder a `login` y en caso contrario redireccionarlos a `home`. Dicha `guard` la llamaremos `no-auth`, la cual debe verse de la siguiente manera:

```TypeScript
export const noAuthGuard: CanActivateFn = (route, state) => {
  const isLoggedIn = localStorage.getItem('isLoggedIn') !== null;

  if (isLoggedIn) {
    const router = inject(Router);

    return router.parseUrl('/home');
  }

  return true;
};
```

Y lo usaremos en la ruta `login` en `app-routing`, modificandolo de la siguiente manera:

```TypeScript
const routes: Routes = [
  // ...
  {
    path: '',
    canActivate: [noAuthGuard],
    loadChildren: () =>
      import('./authentication/authentication.module').then(
        (m) => m.AuthenticationModule
      ),
  },
  // ...
];
```

Si completamos el formulario de login de forma exitosa, nos redireccionara a `home`, seteara `true` en `isLoggedIn` en `localstorage` y si queremos acceder a `login` no podremos ya que tenemos un valor seteado en dicha variable.

## Lecturas Recomendadas

- [Guard de Angular](https://v16.angular.io/guide/router-tutorial-toh#milestone-5-route-guards)

