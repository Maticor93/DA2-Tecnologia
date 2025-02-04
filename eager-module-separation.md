[Atras - Indice](https://github.com/Maticor93/DA2-Tecnologia/tree/angular-navigation)

# Uso de modulos `eager`

Una de las mejoras a realizar es la creacion de diferentes modulos para la declaracion de los diferentes componentes, siguiendo el ejemplo, podriamos generar los siguientes modulos sin ruteo: `first`, `second` y `third`, donde estos modulos declararan sus componentes y los modulos seran importados en el modulo raiz `app.module`.

Realizando este refactor, nos quedaria:

## Modulo raiz: app.module

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

## First modulo: first.module

```TypeScript
@NgModule({
  declarations: [FirstPageComponent],
  imports: [CommonModule],
  exports: [FirstPageComponent],
})
export class FirstModule {}
```

## Second modulo: second.module

```TypeScript
@NgModule({
  declarations: [SecondPageComponent],
  imports: [CommonModule],
  exports: [SecondPageComponent],
})
export class SecondModule {}
```

## Third modulo: third.module

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

## Codigos

- [Codigo de ejemplo de navegacion con `eager`](https://github.com/Maticor93/DA2-Tecnologia/tree/angular-navigation/1-%20Angular%20application/MyNavigationWithChildrenRefactorEagerExampleApp)

