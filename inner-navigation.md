# Navegacion anidada

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

## Codigos

- [Codigo de ejemplo de navegacion con hijos](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-navigation/1-%20Angular%20application/MyNavigationWithChildrenExampleApp)

