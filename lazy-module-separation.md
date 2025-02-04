[Atras - Indice](https://github.com/Maticor93/DA2-Tecnologia/tree/angular-navigation)

# Lazy loading

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

## Modulo raiz: app.module

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

Ahora el modulo raiz quedo sin la importacion de forma `eager` de los modulos hijos, lo que lo hace aun mas limpio.

## Modulo de ruta raiz: app-routing.module

```TypeScript
const routes: Routes = [
  {
    path: 'first-component',
    loadChildren: () =>
      import('./first/first.module').then((m) => m.FirstModule),
  },
  {
    path: 'second-component',
    loadChildren: () =>
      import('./second/second.module').then((m) => m.SecondModule),
  },
  {
    path: 'third-component',
    loadChildren: () =>
      import('./third/third.module').then((m) => m.ThirdModule),
  },
  { path: '', redirectTo: '/first-component', pathMatch: 'full' },
  { path: '**', component: PageNotFoundComponent },
];
```

La definicion de las rutas hijas de las rutas raices recaen en los modulos de rutas de los modulos hijos lo que hace este modulo mas limpio y mas mantenible. Este modulo ahora solo mantiene unicamente las rutas raices.

## Modulo First: first.module

```TypeScript
@NgModule({
  declarations: [FirstPageComponent],
  imports: [CommonModule, FirstRoutingModule],
  exports: [],
})
export class FirstModule {}
```

Podemos ver que importa el modulo de rutas `FirstRoutingModule`, el cual es el modulo de rutas especifico de este modulo. Tambien se puede observar como ya no es necesario que se exporten componentes.

## Modulo de ruta de First: first-routing.module

```TypeScript
const routes: Routes = [
  {
    path: '',
    component: FirstPageComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class FirstRoutingModule {}
```

Este es el modulo encargado de mantener las rutas relacionadas al modulo `first.module`. Dado que la definicion de la ruta utilizada era la de la raiz, esta esta definida en el modulo de rutas raiz `app-routing.module` y tiene como hijo la ruta vacia que despliega la vista del componente `FirstPageComponent`. Otra diferencia es que en los modulos considerados hijos de raiz, en la declaracion de las rutas se utiliza el metodo `forChild` del modulo `RouterModule` en vez del metodo `forRoots` como se usa en `app-routing.module`.

## Modulo Second: second.module

```TypeScript
@NgModule({
  declarations: [SecondPageComponent],
  imports: [CommonModule, SecondRoutingModule],
  exports: [],
})
export class SecondModule {}
```

## Modulo de ruta de Second: second-routing.module

```TypeScript
const routes: Routes = [
  {
    path: '',
    component: SecondPageComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SecondRoutingModule {}
```

## Modulo Third: third.module

```TypeScript
@NgModule({
  declarations: [ThirdPageComponent, ChildComponent, SecondChildComponent],
  imports: [CommonModule, ThirdRoutingModule],
  exports: [],
})
export class ThirdModule {}
```

## Modulo de ruta de Third: third-routing.module

```TypeScript
const routes: Routes = [
  {
    path: '',
    component: ThirdPageComponent,
    children: [
      {
        path: 'child',
        component: ChildComponent,
      },
      {
        path: 'second-child',
        component: SecondChildComponent,
      },
      {
        path: '',
        redirectTo: 'child',
        pathMatch: 'full',
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ThirdRoutingModule {}

```

## Codigos

- [Codigo de ejemplo de navegacion con `lazy`](https://github.com/Maticor93/DA2-Tecnologia/tree/angular-navigation/1-%20Angular%20application/MyNavigationWithChildrenRefactorLazyExampleApp)

