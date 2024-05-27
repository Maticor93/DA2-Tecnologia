# Ruteo y navegacion

En una SPA, se cambia lo que el usuario ve al mostrar u ocultar porciones de la vista que corresponden a un componente particular, en vez de ir al servidor para obtener una pagina nueva. Cuando el usuario realiza las diferentes tareas en la aplicacion, se mueve entre las diferentes vistas que fueron definidas en la aplicacion.

Para gestionar esta navegacion de una vista a otra, se utiliza lo denominado Angular [`Router`](https://v17.angular.io/api/router/Router). El `Router` habilita la navegacion al interpretar la URL del navegador como una instruccion para cambiar la vista.

Existen tres bloques fundamentales para definir las rutas.

## Primer bloque: configuracion de las rutas

Se tiene que importar las rutas al archivo `app.config.ts` y agregarlo con la funcion `provideRouter` teniendo como resultado lo siguiente:

```TypeScript
export const routes: Routes = []

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes)]
};
```

## Segundo bloque: definicion de las rutas

Cada ruta en el array `routes` contiene dos properties. La property `path`, define la URL para la ruta y la property `component`, define el componente de Angular que se deberia de usar para la ruta correspondiente.

```TypeScript
const routes: Routes = [
  { path: 'first-component', component: FirstComponent },
  { path: 'second-component', component: SecondComponent },
];
```

## Tercer bloque: espacio reservado para desplegar los componentes

Para que la navegacion tenga efecto, es necesario definir un espacio reservado para que Angular pueda mostrar y ocultar los componentes relacionados a las rutas en la URL. Para realizar esto se utiliza el componente `router-outlet`, el cual sirve como la definicion del espacio reservado para que Angular muestre u oculte los componentes en ese lugar.

```HTML
<h1>Angular Router App</h1>
<nav>
  <ul>
    <li><a routerLink="/first-component" routerLinkActive="active" ariaCurrentWhenActive="page">First Component</a></li>
    <li><a routerLink="/second-component" routerLinkActive="active" ariaCurrentWhenActive="page">Second Component</a></li>
  </ul>
</nav>
<!-- The routed views render in the <router-outlet>-->
<router-outlet></router-outlet>
```

Podemos ver que hay dos links que se relacionan uno a uno con las rutas definidas en el array de rutas y como se reservo un espacio para la renderizacion de dichos componentes. El resultado sera que se va a desplegar la vista del componente seleccionado en la navegacion, pero el componente de la navegacion no se vera afectado por dichos movimientos.

En esta vista tenemos una parte estatica, la navegacion, y una parte dinamica, el espacio reservado.

Para que dicho codigo funcione es necesario importar los siguientes elementos: `CommonModule`, `RouterOutlet`, `RouterLink`, `RouterLinkActive`.

## Orden de ejecucion

El orden de las rutas es importante porque `Router` utiliza la estrategia first-match gana cuando encuentra rutas que matchean, es por eso que, las rutas mas especificas deberian de estar ubicadas antes que las rutas menos especificas. Las rutas con una parte estatica deberan ser listadas primero, seguido por una ruta vacia, lo cual matchea con la ruta por defecto.

La ruta [comodin](https://v17.angular.io/guide/router#setting-up-wildcard-routes) debera ser declarada como ultima porque matchea con cualquier URL y el Router lo utiliza solo si no existe un matcheo con otra ruta antes.

Ejemplo de definicion de orden de rutas:
```TypeScript
const appRoutes: Routes = [
  { path: 'create-movie', component: CreateMovieComponent }, // ruta estatica que matcha con la ruta: https://localhost:3000/create-movie
  { path: 'movies',        component: MovieFeedComponent }, // ruta estatica que matcha con la ruta: https://localhost:3000/movies
  { path: '',   redirectTo: '/movies', pathMatch: 'full' }, // ruta vacia que matchea con la ruta por defecto: https://localhost:3000/
  { path: '**', component: PageNotFoundComponent } // ruta comodin que matchea con cualquier ruta que no matchee con las anteriores
];
```

## Pasar informacion en la ruta

Es comun querer pasar informacion en la ruta de navegacion. Por ejemplo, si consideramos una aplicacion que muestra un listado de peliculas, cada pelicula tiene un unico `id`. Para editar una pelicula determinada, el usuario haria click en un boton Editar, que navegaria el usuario a la vista del componente `UpdateMovieComponent`.

Para hacer esto modificamos la informacion de la ruta por la siguiente:

1. Agregamos la funcion `withComponentInputBinding` al `providerRouter` metodo.

```TypeScript
export const appRoutes: Route[] =[
  {
    path:'component/:movieId'
    component: UpdateMovieComponent
  }
]
providers: [
  provideRouter(appRoutes, withComponentInputBinding()),
]
```

2. Actualizar el componente para tener un parametro que matchee en nombre y usar `Input`

```TypeScript
@Input()
set id(movieId: string) {
  this.movie$ = this.service.getMovie(movieId);
}
```

En caso de querer hacer uso de dicho parametro al momento de inicializacion del componente:

```TypeScript
ngOnInit() {
  const id = this.route.snapshot.paramMap.get('movieId')!;

  this.movie$ = this.service.getMovie(id);
}
```

## Lecturas recomendadas

- [Ejemplo en vivo](https://stackblitz.com/run?file=src/app/app-routing.module.ts)

- [Ruteo de Angular](https://v17.angular.io/guide/routing-overview)

