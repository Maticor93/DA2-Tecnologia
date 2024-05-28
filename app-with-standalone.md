# Elementos en la carpeta app sin ninguna flag utilizada

## app.component.ts

Es el componente raiz utilizado por `index.html`, el mismo es el quien encabeza todas las vistas anidadas. Es un buen lugar para dejar codigo estatico independientemente la pagina como un `footer`, y definir un espacio reservado para el dinamismo de la navegacion.

Encontraremos la siguiente definicion:

```TypeScript
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'MyFirstAngularApp';
}
```

La cual define una clase llamada `AppComponent` y utiliza el decorador `@Component()` para indicarle a Angular que esta clase es un componente. En la metadata del componente, podemos encontrar la definicion del `selector` a utilizar dentro de las vistas HTML para utilizar dicho componente. Tambien podemos encontrar el uso de la flag `standalone`, la cual indica que este componente es autogestionable, dado esta configuracion encontraremos informacion de las dependencias que necesita para operar en la property `imports`.

Tambien se define en `templateUrl` la ruta al template HTML del componente que se situa en otro archivo y por ultimo, tenemos `styleUrl` que define la ruta al archivo de estilados especificos para el componente.

## app.component.html

Es el tamplate HTML del componente, estos estan vinculados por la metadata del componente, y entre estos ocurrira toda la comunicacion entre el DOM y la logica de la aplicacion.

Podemos observar que al final utiliza el espacio reservado para dinamismo, `<router-outlet>`, el cual permitira un sentido de navegacion entre paginas a traves de la URL del navegador. Esto es una dependencia del componente, y la declaracion de la misma la podemos observar en los `imports` de la metadata del componente.

## app.component.spec

Es un archivo de pruebas del componente

## app.component.css

Es el archivo de estilado especifico solo para el componente, es el lugar indicado para hacer algun override de algun estilado heredado o la implementacion de algo especifico solo para el componente.

## app.config.ts

Es el archivo de configuracion de la aplicacion que provee la configuracion de las rutas. Esta configuracion sera utilizada en `main.ts`.

## app.routes

Es el archivo que define las rutas que la aplicacion estara atendiendo.

