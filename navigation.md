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

## Orden de ejecucion

El orden de las rutas es importante porque `Router` utiliza la estrategia first-match gana cuando encuentra rutas que matchean, es por eso que, las rutas mas especificas deberian de estar ubicadas antes que las rutas menos especificas. Las rutas con una parte estatica deberan ser listadas primero, seguido por una ruta vacia, lo cual matchea con la ruta por defecto.

La ruta [comodin](https://v17.angular.io/guide/router#setting-up-wildcard-routes) debera ser declarada como ultima porque matchea con cualquier URL y el Router lo utiliza solo si no existe un matcheo con otra ruta antes.

Ejemplo de definicion de orden de rutas:

```TypeScript
const appRoutes: Routes = [
  { path: 'first-component', component: FirstPageComponent }, // ruta estatica que matcha con la ruta: https://localhost:3000/first-component
  { path: 'second-component', component: SecondPageComponent }, // ruta estatica que matcha con la ruta: https://localhost:3000/second-component
  { path: '',   redirectTo: '/first-component', pathMatch: 'full' }, // ruta vacia que matchea con la ruta por defecto: https://localhost:3000/
  { path: '**', component: PageNotFoundComponent } // ruta comodin que matchea con cualquier ruta que no matchee con las anteriores
];
```

## Navegacion anidada

A medida que la aplicacion va creciendo, es necesario ir creando mas nodos anidados para una buena organizacion y facil mantenimiento. Es muy comun querer elementos anidados para ir reutilizando partes estaticos. Para eso podemos usar la property `children` del tipo `Route` que define otro array de `Routes` para definir las rutas hijas de una ruta padre.

```TypeScript
const appRoutes: Routes = [
  { path: 'first-component', component: FirstPageComponent }, // ruta estatica que matcha con la ruta: https://localhost:3000/first-component
  { path: 'second-component', component: SecondPageComponent }, // ruta estatica que matcha con la ruta: https://localhost:3000/second-component
  {
    path: 'third-component',
    component: ThirdPageComponent,
    children: [
      { path: 'child', component: ChildComponent },
      { path: 'second-child', component: SecondChildComponent },
      { path: '', redirectTo: 'child', pathMatch: 'full' },
    ],
  }, // ruta estatica que matcha con las rutas: https://localhost:3000/third-component/child, https://localhost:3000/third-component/second-child yhttps://localhost:3000/third-component
  { path: '',   redirectTo: '/first-component', pathMatch: 'full' }, // ruta vacia que matchea con la ruta por defecto: https://localhost:3000/
  { path: '**', component: PageNotFoundComponent } // ruta comodin que matchea con cualquier ruta que no matchee con las anteriores
];
```

El codigo provisto define una nueva ruta, `third-component` la cual es una ruta raiz padre de las rutas `child` y `second-child`. Si indicamos las URL explicitamente en el navegador, podremos acceder al contenido de cada componente. Esta ruta tambien define un redireccionamiento a uno de los hijos en caso de que no se provea un hijo explicitamente.

Todas las rutas hijas hacen uso del comodin definido en la ruta raiz, eso quiere decir, que en caso de querer navegar a una ruta hija que no existe, por ejemplo: `https://localhost:3000/third-component/child-not-found`, el `Router` nos navegara al comodin `**` definido mas cercano encontrado, en este ejemplo es en la clase raiz, pero si se definiera el comodin como hijo de `third-component`, este seria el renderizado.

Esta forma de cargar los hijos o las rutas raices, implica la desventaja de que perjudica la organizacion y mantenimiento de dichos elementos ya que esta todas las rutas encapsuladas en un unico lugar. Esto en una aplicacion con muchos niveles de navegacion es perjudicial ya que tambien impacta indirectamente en el modulo raiz `app.module` ya que es el que define todos estos componentes.

Una de las mejoras a realizar es la creacion de diferentes modulos para la declaracion de los diferentes componentes, siguiendo el ejemplo, podriamos generar los siguientes modulos sin ruteo: `first`, `second` y `third`, donde estos modulos declararan sus componentes y los modulos seran importados en el modulo raiz `app.module`.

Realizando este refactor, nos quedaria:

### Modulo raiz: app.module

```TypeScript
@NgModule({
  declarations: [AppComponent, PageNotFoundComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FirstModule,
    SecondModule,
    ThirdModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
```

Y el modulo de rutas raiz `app-routing.module` la unica actualizacion que habria que hacerle es modificar la ubicacion de los componentes, ya que estos se encuentran dentro de la carpeta del modulo. Lo que logramos fue reducir el tamaño del modulo raiz, haciendolo responsable unicamente de los componentes que el utilizara.

Los modulos hijos a la raiz quedarian declarando sus componentes y exportandolos ya que deben ser importados por el modulo raiz `app.module`. Teniendo los modulos hijos de la siguiente manera:

### First modulo: first.module

```TypeScript
@NgModule({
  declarations: [FirstPageComponent],
  imports: [CommonModule],
  exports: [FirstPageComponent],
})
export class FirstModule {}
```

### Second modulo: second.module

```TypeScript
@NgModule({
  declarations: [SecondPageComponent],
  imports: [CommonModule],
  exports: [SecondPageComponent],
})
export class SecondModule {}
```

### Third modulo: third.module

```TypeScript
@NgModule({
  declarations: [ThirdPageComponent, ChildComponent, SecondChildComponent],
  imports: [CommonModule, RouterModule],
  exports: [ThirdPageComponent, ChildComponent, SecondChildComponent],
})
export class ThirdModule {}
```

Notar que los modulos creados son sin `routing` ya que la definicion del ruteo ocurre en el modulo de ruta raiz `app-routing.module`. Ahora el mantenimiento de dichos componentes esta aislado y encapsulado en su propio modulo lo cual resulta mas facil la evolucion de los mismos.

De igual manera seguimos con la desventaja de que la responsabilidad de la definicion de rutas recae solamente en el modulo de rutas raiz `app-routing.module`. Para evitar dicha desventaja cambiaremos la forma de importar los modulos de `eager` a `lazy`.

La forma en que la importacion de modulos `eager` funciona es cargar todos los modulos en cuanto la aplicacion carga, sin importar si estos son necesarios o no. Para aplicaciones grandes con muchas rutas, esto es una desventaja en temas de performance, y para este tipo de aplicaciones la forma de cargar los modulos debe ser con `lazy`, ya que de esta forma solo carga los modulos cuando son estrictamente necesarios.

### Lazy loading

Esta forma de cargar los modulos ayuda a que el tamaño del bundle sea mas chico, lo que ayuda a disminuir los tiempos de carga. Los modulos cargados de forma `lazy` son cargados con la property `loadChildren` en vez de usar `component` en las rutas definidas en `app-routing.module`.

```TypeScript
const routes: Routes = [
  {
    path: 'items',
    loadChildren: () => import('./items/items.module').then(m => m.ItemsModule)
  }
];
```

Para esto necesitamos en el modulo de rutas del modulo lo siguiente:

```TypeScript
const routes: Routes = [
  {
    path: '',
    component: ItemsComponent
  }
];
```

Para que esto funcion es necesario remover la referencia del modulo cargado de forma `eager` en el modulo raiz `app.module`. Siguiendo el ejemplo, habria que remover `ItemsModule` de `AppModule`

Dado que ahora la definicion de rutas de los modulos recae en los modulos mismos y no mas en el modulo de rutas raiz `app-routing.module`, la creacion de los modulos debera de ser utilizando la flag `routing`. En caso de contar ya con modulos creados, se debera de crear el modulo de ruta apropiado para el modulo.

Dado las grandes ventajas que propone la carga de modulos de forma `lazy`, procederemos a implementarla en el codigo que se viene trabajando. Teniendo como resultado lo siguiente:

#### Modulo raiz: app.module

```TypeScript
@NgModule({
  declarations: [AppComponent, PageNotFoundComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
```

### Modulo de ruta raiz: app-routing.module

```TypeScript
const routes: Routes = [
  {
    path: 'first-component',
    loadChildren: () => import('./items/items.module').then(m => m.ItemsModule)
  }
];
```

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

- [Codigo de ejemplo de navegacion con hijos](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-navigation/1-%20Angular%20application/MyNavigationWithChildrenExampleApp)

- [Codigo de ejemplo de navegacion con `eager`](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-navigation/1-%20Angular%20application/MyNavigationWithChildrenRefactorEagerExampleApp)

- [Codigo de ejemplo de navegacion con `lazy`](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-navigation/1-%20Angular%20application/MyNavigationWithChildrenRefactorLazyExampleApp)

- [Codigo de ejemplo de navegacion con parametros](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-navigation/1-%20Angular%20application/MyNavigationWithParamsExampleApp)

## Lecturas recomendadas

- [Ejemplo en vivo](https://stackblitz.com/run?file=src/app/app-routing.module.ts)

- [Ruteo de Angular](https://v17.angular.io/guide/routing-overview)
