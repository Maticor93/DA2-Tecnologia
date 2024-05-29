[Atras - Indice](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-navigation)

# Orden de ejecucion

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
