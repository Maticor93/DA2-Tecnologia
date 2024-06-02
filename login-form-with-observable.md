[Atras - Indice](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-service)

# `login-form` con Observable

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
    return this._repository.login(credentials);
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

Y esta situada en el directorio `backend/service/session/models/user-credentials.model.ts`;

Tambien implementamos el tipo de retorno `SessionCreatedModel` la cual esta definida de la siguiente manera:

```TypeScript
export default interface SessionCreatedModel{
  token: string;
}
```

Y esta situada en el directorio `backend/service/session/models/session-created.model.ts`;

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

        localStorage.setItem('token', response.token);

        this._router.navigate(['/home']);
      },
      error: (error) => {
        this.loginStatus = { error: error.message };
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

  <app-form-button *ngIf="!loginStatus; else loadingOrError" title="Login" />

  <ng-template #loadingOrError>
    <div *ngIf="loginStatus.loading; else notLoading">
      Cargando...
    </div>
    <ng-template #notLoading>
      <div>{{ loginStatus.error }}</div>
    </ng-template>
  </ng-template>
</app-form>
```

