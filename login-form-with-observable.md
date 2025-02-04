[Atras - Indice](https://github.com/Maticor93/DA2-Tecnologia/tree/angular-service)

# `login-form` con Observable

## Creacion del servicio `session`

En esta seccion implementaremos en `login-form` la llamada a un servicio que tenga la logica de login.

Para esto crearemos un servicio `session` en `services`. Procederemos a ejecutar:

```CMD
cd src
cd backend
cd services
ng generate service session
```

En dicho servicio implementaremos el comportamiento `login` que definira un parametro `credentials` donde le mandaremos las credenciales validadas puestas por el usuario en el formulario. Esta funcion retornara un `Observable` al cual nos suscribiremos desde `login-form` para actualizar el estado del componente y realizar la redireccion. Como los servicios no son los encargados de comunicarse directamente con la data, debemos de crear el repositorio `session-api-repository` que es el encargado de esta responsabilidad. Procederemos a ejecutar:

```CMD
cd src
cd backend
cd repositories
ng generate service session-api-repository
```

Una vez creados el servicio y el repositorio, procederemos a implementarlos con las especificaciones antes mencionadas.

## Implementacion del servicio `session`
El servicio `session` nos debera de quedar de la siguiente manera:

```TypeScript
@Injectable({
  providedIn: 'root',
})
export class SessionService {
  constructor(private readonly _repository: SessionApiRepositoryService) {}

  public login(
    credentials: UserCredentialsModel
  ): Observable<SessionCreatedModel> {
    return this._repository
      .login(credentials)
      .pipe(tap((response) => {
        localStorage.setItem("token", response.token);
        localStorage.setItem(
          "permissions",
          JSON.stringify(response.permissions)
        );
    }));
  }
}
```

Esta implementacion nos llevo a implementar la estructura `UserCredentialsModel` la cual esta definida de la siguiente manera:

```TypeScript
export default interface UserCredentialsModel{
  email: string;
  password: string;
}
```

Y esta situada en el directorio `backend/service/session/models/UserCredentialsModel.ts`;

Tambien implementamos el tipo de retorno `SessionCreatedModel` la cual esta definida de la siguiente manera:

```TypeScript
export default interface SessionCreatedModel{
  token: string;
  permissions: Array<string>;
}
```

Y esta situada en el directorio `backend/service/session/models/SessionCreatedModel.ts`;

## Implementacion del servicio `session-api-repository`

Una vez terminada la implementacion del servicio, pasaremos a implementar a `session-api-repository.session`, la cual debera de quedar asi:

```TypeScript
@Injectable({
  providedIn: 'root',
})
export class SessionApiRepositoryService extends ApiRepository {
  constructor(http: HttpClient) {
    super(environments.vidlyApi, 'sessions', http);
  }

  public login(
    credentials: UserCredentialsModel
  ): Observable<SessionCreatedModel> {
    return this.post(credentials);
  }
}
```

## Inyeccion de dependencia

Una vez terminada la implementacion del lado del backend, el siguiente paso es utilizar el servicio `session` en el componente `login-form` de la siguiente manera:

```TypeScript
  // ...
export class LoginFormComponent {
  // ...
  constructor(
    private readonly _router: Router,
    private readonly _sessionService: SessionService
  ) {}

  // ...
}
```

Ahora que tenemos declarada la dependencia del servicio en el componente, procederemos a modificar el comportamiento `onSubmit` en el componente para que utilice el servicio. La modificacion nos debera de quedar de la siguiente manera:

```TypeScript
export class LoginFormComponent {
  // ...

  loginStatus: {
    loading?: true;
    error?: string;
  } | null = null;

  constructor(
    private readonly _router: Router,
    private readonly _sessionService: SessionService
  ) {}

  public onSubmit(values: UserCredentialsModel) {
    this.loginStatus = { loading: true };

    this._sessionService.login(values).subscribe({
      next: (response) => {
        this.loginStatus = null;

        this._router.navigate(['/home']);
      },
      error: (error) => {
        this.loginStatus = { error };
      },
    });
  }
}
```

En la modificacion del comportamiento `onSubmit` creamos el estado `loginStatus` que nos ayudara para indicarle al usuario que las credenciales estan siendo procesadas en caso de que la property `loading` sea `true` y para indicarle si hubo un error en caso de que la property `error` sea seteada con un mensaje. En caso de que la solicitud se proceso de forma exitosa, pondremos el valor por defecto `null` al estado `loginStatus` y el comportamiento que ya tenia.

Esta modificacion impacta en el template HTML del componente de la siguiente manera:

```HTML
<h1>Bienvenido a MyServiceApp</h1>

<app-form [form]="loginForm" (onSubmit)="onSubmit($event)">
 <!-- ... -->

   <div *ngIf="loginStatus?.loading; else notLoading">Cargando...</div>

  <ng-template #notLoading>
    <div *ngIf="loginStatus?.error">{{ loginStatus!.error }}</div>
    <app-form-button title="Login" />
  </ng-template>
</app-form>
```

## Custom observable

Lo siguiente que vamos a implementar es una property de tipo `Observable` que guarde el usuario logueado en `session`, para que los componentes puedan suscribirse a esta property y reaccionar ante los cambios de valores de la property. De esta forma asi podemos mantener el estado de nuestra aplicacion sincronizada sin la necesidad de hacer un refresh de la aplicacion de forma manual.

Para esto, vamos a modificar el comportamiento `login` en `session` de la siguiente manera:

```TypeScript
export class SessionService {
  private readonly _userLogged$: BehaviorSubject<UserLoggedModel | null> =
    new BehaviorSubject<UserLoggedModel | null>(null);

  get userLogged(): Observable<UserLoggedModel | null> {
    if (!this._userLogged$.value) {
      const token = localStorage.getItem("token");

      if (token) {
        const permissions = JSON.parse(
          localStorage.getItem("permissions") || "[]"
        );
        this._userLogged$.next({ token, permissions });
      }
    }

    return this._userLogged$.asObservable();
  }

  constructor(private readonly _repository: SessionApiRepositoryService) {}

  public login(
    credentials: UserCredentialsModel
  ): Observable<SessionCreatedModel> {
    return this._repository.login(credentials).pipe(
      tap((response) => {
        localStorage.setItem("token", response.token);
        localStorage.setItem(
          "permissions",
          JSON.stringify(response.permissions)
        );
        this._userLogged$.next(response);
      })
    );
  }
}
```

Lo que estamos haciendo es publicando el nuevo valor de token cuando ocurre un login exitoso, y estamos exponiendo el `userLogged` para que se suscriban. El token lo estamos persistiendo en dos lugares en `localStorage` y en memoria con `Observable`. Es necesario persistirlo en `localStorage` porque en ese lugar la data no se borra ni se ponen los valores por defectos cuando ocurren un reload de la aplicacion como ocurre con la data en memoria. Es por eso que antes de retornar el `Observable` del `userLogged` preguntamos si no tiene valor, si no tiene valor, esto no significa que no se logueara el usuario, ya que pudo haber ocurrido un login pero un reload de la aplicacion. Si no hay un valor en memoria pero si en `localStorage` entonces se actualiza el `Observable` y se retorna a quien lo solicita.

Este `Observable` lo usaremos dentro de `home-page` para desplegar los permisos del usuario logueado. Dejando `home-page` de la siguiente manera:

```TypeScript
// ...
export class HomePageComponent implements OnInit {
  permissions: Array<string> = [];

  constructor(private readonly _sessionService: SessionService) {}

  ngOnInit(): void {
    this._sessionService.userLogged.subscribe({
      next: (userLogged) => {
        this.permissions = userLogged?.permissions ?? [];
      },
    });
  }
}
```

Y su template HTML de la siguiente forma:

```HTML
<p *ngFor="let permission of permissions">{{ permission }}</p>
```

Cuando se renderice el componente la lista `permissions` sera una lista vacia, pero cuando los permisos del usuario logueado esten listos para ser consumidos, estos se desplegaran.

## Actualizacion de las `guards`

### Actualizacion de `auth-guard`

La ultima modificacion es la actualizacion de las `guards` para que usen la nueva variable `token`.

Quedando `auth-guard` de la siguiente manera:

```TypeScript
export const authGuard: CanActivateFn = (route, state) => {
  const isNotLoggedIn = localStorage.getItem('token') === null;

  if (isNotLoggedIn) {
    const router = inject(Router);

    return router.parseUrl('/login');
  }

  return true;
};
```

### Actualizacion de `no-auth`

Y la `guard` `no-auth` debera quedar asi:

```TypeScript
export const noAuthGuard: CanActivateFn = (route, state) => {
  const isLoggedIn = localStorage.getItem('token') !== null;

  if (isLoggedIn) {
    const router = inject(Router);

    return router.parseUrl('/home');
  }

  return true;
};
```
