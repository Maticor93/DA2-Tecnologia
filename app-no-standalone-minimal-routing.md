# Elementos en la carpeta app de una aplicacion sin standalone, minimal y routing

En esta carpeta podremos encontrar 3 archivos.

## app.component.ts

Es el componente raiz utilizado por `index.html`, el mismo es el quien encabeza todas las vistas anidadas. Es un buen lugar para dejar codigo estatico independientemente la pagina como un `footer`, y definir un espacio reservado para el dinamismo de la navegacion.

Encontraremos la siguiente definicion:

```TypeScript
@Component({
  selector: 'app-root',
  template: `
    <h1>Welcome to {{title}}!</h1>

    <router-outlet />
  `,
  styles: []
})
export class AppComponent {
  title = 'MyMinimalRoutingNoStandalonApp';
}
```

La cual define una clase llamada `AppComponent` y utiliza el decorador `@Component()` para indicarle a Angular que esta clase es un componente. En la metadata del componente, podemos encontrar la definicion del selector a utilizar dentro de las vistas HTML para utilizar dicho componente y tambien encontramos una definicion basica del template HTML del componente el cual despliega un titulo estatico pero dinamico porque lee un valor de una variable, y tambien define un espacio dinamico para la navegacion al usar `<router-outlet/>`.

## app.module.ts

Es el modulo raiz de la aplicacion, en este podemos encontrar la declaracion del componente raiz, las importaciones que este necesita para operar y el proceso de bootstraping hacia el componente raiz.

```TypeScript
@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
```

Podemos observar que define una clase `AppModule` y utiliza el decorador `@NgModule()` para indicarle a Angular que esta clase es un modulo que declara componentes, importa dependencias y provee servicios.

## app-routing.module.ts

Es el modulo que se encarga de definir las rutas raices que se atenderan en la aplicacion.

```TypeScript
const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
```

Podemos observar que define una clase `AppRoutingModule` y utiliza el decorador `@NgModule` el cual en la definicion de la metadata declara los elementos de importacion que necesita que son las rutas y el nivel que deben de tener dichas rutas, y que se exporta para que otro modulo lo importe.

Si vemos `AppModule` vemos que una de las importaciones, es este modulo, y lo que importa es lo que `AppRoutingModule` exporta.

Si no usaramos dos moduloes separados tendriamos lo siguiente:

```TypeScript
const routes: Routes = [];

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, RouterModule.forRoot(routes)],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
```

