# Servicios

Los servicios son una amplia categoria que engloban cualquier valor, funcion, o funcionalidad que la aplicacion necesita. Un servicio es una clase bien definida con un proposito. Deberia de hacer una unica cosa y bien.

Angular distingue los componentes de los servicios para aumentar la modularidad y reusabilidad.

Idealmente, el trabajo de un componente es brindar unicamente experiencia de usuario. Un componente deberia de tener properties y metodos para el data binding para mediar entre la vista y la logica de la aplicacion. La vista es el template renderizado y la logica de la aplicacion es lo hace la nocion de modelo.

Un componente deberia de usar servicios para tareas que no involucran a la vista o la logica de la aplicacion. Los servicios son buenos para tareas como la realizacion de requests http a un servidor, validar los inputs del usuario, o loguear directamente en consola. Al definir tales tareas en una clase de servicio inyectable, esas tareas se vuelven disponibles para cualquier componente. Tambien se puede hacer la aplicacion mas adaptable al inyectar diferentes proveedores del mismo servicio en funcion a las circunstancias.

Por ejemplo tenemos el siguiente servicio que es para loguear diferentes tipos de mensaje en consola:

```TypeScript
export class Logger {
  log(msg: any)   { console.log(msg); }
  error(msg: any) { console.error(msg); }
  warn(msg: any)  { console.warn(msg); }
}
```

Los servicios pueden depender de otros servicios. Por ejemplo, tenemos `MovieService` que depende de `Logger`, y tambien usa `BackendService` para obtener las peliculas con una request http.

```TypeScript
export class MovieService {
  private movies: Movie[] = [];

  constructor(
    private backend: BackendService,
    private logger: Logger) { }

  getHeroes() {
    this.backend.getAll('movies').then( (movies: Movie[]) => {
      this.logger.log(`Fetched ${movies.length} movies.`);
      this.movies.push(...movies); // fill cache
    });
    return this.movies;
  }
}
```

## Inyeccion de dependencias

<p align="center">
<img src="./images/image-11.png">
</p>
<p align="center">
[Inyeccion de dependencia (DI)]
</p>

La inyeccion de dependencia es la parte del framework de Angular que le provee a los componentes acceso a los servicios y otros recursos. Angular provee la habilidad de inyectar los servicios en los componentes para darle acceso a dicho servicio.

Es necesario agregar el decorador `@Inyectable()` en la clase del servicio para que Angular lo pueda inyectar en los componentes que declaran el servicio como dependencia. Los argumentos opcionales le indican a Angular donde registrar la clase por defecto.

```TypeScript
@Injectable({providedIn: 'root'})
export class MOvieService {
```

Reglas

- Algo inyectable tiene que ser registrado por un inyector antes de ser creado y usado

- Registrar un inyectable con un proveedor, un objeto que le dice al inyector como obtener o crear la dependencia. Para una clase de servicio, el proveedor es tipicamente la clase en si.

- No es necesario preocuparnos de crear inyectores. Por atras Angular crea un application-wide root inyector por nosotros durante el proceso de bootstrap. Crea inyectores hijos adicionales de ser necesario.

Como nota, una dependencia inyectable no necesariamente tiene porque ser una clase - puede ser una funcion o un valor tambien.
