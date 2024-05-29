[Atras - Indice](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-service)

# Servicios

Cuando uno desarrolla alguna parte del sistem, como un modulo o una clase, por lo general necesita alguna funcionalidad declarada en otra clase. Por ejemplo, se podria necesitar un servicio HTTP para realizar requests a un servidor. La inyeccion de dependencia, o DI, es un patron de diseño y un mecanismo para crear y entregar alguna parte de la aplicacion a otra parte de la aplicacion que la necesita. Angular soporta este patron de diseño y se puede utilizar para aumentar la flexibilidad y modularizacion.

En Angular, las dependencias tipicamente son servicios y los servicios son una amplia categoria que engloban cualquier valor, funcion, o funcionalidad que la aplicacion necesita. Un servicio es una clase bien definida con un proposito que deberia de hacer una unica cosa y bien.

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
export class MovieService {
```

Angular para inyectar dichos servicios, hace uso de un [injector](https://v17.angular.io/guide/glossary#injector) (creado automaticamente durante el proceso de bootstrap) el que instancia las dependencias necesitadas el cual utiliza la configuracion del proveedor del servicio.

Existen dos roles fundamentales, los que consumen dependencias y los que proveen dependencias.

Reglas para usar DI

- Algo inyectable tiene que ser registrado por un inyector antes de ser creado y usado

- Registrar un inyectable con un proveedor, un objeto que le dice al inyector como obtener o crear la dependencia. Para una clase de servicio, el proveedor es tipicamente la clase en si.

- No es necesario preocuparnos de crear inyectores. Por atras Angular crea un application-wide root inyector por nosotros durante el proceso de bootstrap. Crea inyectores hijos adicionales de ser necesario.

Como nota, una dependencia inyectable no necesariamente tiene porque ser una clase - puede ser una funcion o un valor tambien.

Cuando Angular crea una instancia de la clase del componente, determina que servicios u otras dependencias el componente necesita al ver los tipos de los parametros del constructor. Por ejemplo, el constructor de `MovieFeedComponent` necesita `MovieService`.

```TypeScript
constructor(private service: MovieService) { }
```

Cuando Angular descubre que el componente depende de un servicio, primero chequea si el injector tiene una instancia del servicio existente. Si no existe una instancia del servicio solicitado, el injector crea una usando el proveedor registrado y agrega la instancia al injector antes de retornarle la instancia a Angular.

Cuando todos los servicios solicitados fueron resueltos y retornados, Angular puede llamar al constructor de la clase del componente con esos servicios como argumentos.

El proceso de la inyeccion del servicio `MovieService` luce algo similar a esto.

<p align="center">
<img src="./images/image-12.png">
</p>
<p align="center">
[Proceso de inyeccion de dependencia]
</p>

## Provedor de servicios

Se debe de registrar al menos un provedor de cualquier servicio que se quiera usar. El proveedor puede ser parte de la propia metadata del servicio, haciendo ese servicio disponible en cualquier lugar, o se puede registrar proveedores con componentes especificos.

Los proveedores se registran en la metadata del servicio (en el decorador @Injectable()) o en la metadata de @Componente().

- Por defecto, el comando Angular CLI `ng generate service` registra un proveedor en el inyector raiz para el servicio al incluir la metadata del proveedor en @Injectable().

```TypeScript
@Injectable({providedIn: 'root'})
export class MovieService {
```

Cuando se provee el servicio al nivel de la raiz, Angular crea una sola instancia compartida de `MovieService` y la inyecta en cualquier clase que la pida. Registrar el proveedor en la metadata de @Injectable() tambien le permite a Angular optimizar la aplicacion al remover el servicio de la aplicacion compilada si no se usa, es un proceso llamado tree-shaking.

- Cuando se registra el proveedor a nivel del componente, se obtiene una nueva instancia del servicio cada vez que existe una nueva instancia del componente. A nivel del componente, registrar el proveedor del servicio en la property `providers` de la metadata del decorador @Component()

```TypeScript
@Component({
  selector:    'app-movie-feed',
  templateUrl: './movie-feed.component.html',
  imports:     [ NgFor, NgIf, HeroDetailComponent ],
  providers:  [ MovieService ]
})
```

## Lecturas recomendadas

- [Introduccion a servicios](https://v17.angular.io/guide/architecture-services)

- [DI en Angular](https://v17.angular.io/guide/dependency-injection-overview)

- [Entendiendo DI](https://v17.angular.io/guide/dependency-injection)

