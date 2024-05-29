[Atras - Indice](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-navigation)

# Ruteo y navegacion

En una SPA, se cambia lo que el usuario ve al mostrar u ocultar porciones de la vista que corresponden a un componente particular, en vez de ir al servidor para obtener una pagina nueva. Cuando el usuario realiza las diferentes tareas en la aplicacion, se mueve entre las diferentes vistas que fueron definidas en la aplicacion.

Para gestionar esta navegacion de una vista a otra, se utiliza lo denominado Angular [`Router`](https://v17.angular.io/api/router/Router). El `Router` habilita la navegacion al interpretar la URL del navegador como una instruccion para cambiar la vista.

Existen tres bloques fundamentales para definir las rutas.

## Primer bloque: configuracion de las rutas

Tendremos un archivo `app-routing.module.ts` el cual es el lugar donde definiremos las rutas y las configuraremos como raices. Para ello, tendremos que definir las rutas en un array `routes`, donde cada ruta debe definir al menos las siguientes properties: `path` y `component`. La property `path` define la ruta que estara matcheando en la URL del navegador y la property `component` define el componente de Angular que se debera de instanciar cuando ocurra un matcheo entre el `path` definido con la URL del navegador.

```TypeScript
const routes: Routes = [
  { path: 'first-component', component: FirstPageComponent },
  { path: 'second-component', component: SecondPageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
```

En la metadata del decorador, podemos observar que importa las rutas definidas y las declara para que sean atendidas por la raiz. Tambien podemos observar que exporta lo modulo del router, esto implica que quien importe este modulo estara importando la configuracion de las rutas.

## Segundo bloque: importacion de las rutas

Una vez que tenemos las rutas definidas para la navegacion, este modulo tiene que ser importado en el modulo raiz `app.module` el cual estara importando la definicion de rutas raices.

```TypeScript
@NgModule({
  declarations: [AppComponent, FirstPageComponent, SecondPageComponent],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
```

Podemos ver como en la metadata del decorador, en la property `imports` el modulo de ruteo `AppRoutingModule` ya se encuentra importado. Tambien podemos observar que es necesario que el modulo declare los componentes que estaran atendiendo las rutas en la property `declarations`.

## Tercer bloque: espacio reservado para desplegar los componentes

Para que la navegacion tenga efecto, es necesario definir un espacio reservado para que Angular pueda mostrar y ocultar los componentes relacionados a las rutas en la URL. Para realizar esto se utiliza el componente `router-outlet`, el cual sirve como la definicion del espacio reservado para que Angular muestre u oculte los componentes en ese lugar. Aquel template HTML que tenga defina `router-outlet` tiene que tener rutas hijas, es por esto que el siguiente codigo se ubica en `app.component.html`, ya que es el compnente raiz y queremos definir un espacio dinamico en este.

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

## Pasar informacion en la ruta

Es comun querer pasar informacion en la ruta de navegacion. Por ejemplo, si consideramos una aplicacion que muestra un listado de elementos y cada elemento tiene un unico `id`. Para editar un elemento determinado, el usuario haria click en un boton `Editar`, que navegaria el usuario a la vista del componente `UpdateElementComponent`.

Para hacer definimos la ruta de la siguiente forma:

```TypeScript
export const appRoutes: Route[] = [
  {
    path:'elements/:elementId'
    component: UpdateElementComponent
  }
]
```

Y en el componente declaramos un parametro que matchee en nombre y usar `Input`

```TypeScript
@Input()
set id(elementId: string) {
  this.element$ = this.service.getElementById(elementId);
}
```

En caso de querer hacer uso de dicho parametro al momento de inicializacion del componente:

```TypeScript
ngOnInit() {
  const id = this.route.snapshot.paramMap.get('elementId')!;

  this.element$ = this.service.getElementById(id);
}
```

## Codigos

- [Codigo de ejemplo basico de navegacion](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-navigation/1-%20Angular%20application/MyNavigationExampleApp)

## Lecturas recomendadas

- [Ejemplo en vivo](https://stackblitz.com/run?file=src/app/app-routing.module.ts)

- [Ruteo de Angular](https://v17.angular.io/guide/routing-overview)
