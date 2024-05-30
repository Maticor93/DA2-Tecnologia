[Atras - Indice](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-service)

# Creacion de servicio y repositorio

En esta parte vamos a crear un servicio junto con su repositorio para consumir los tipos de peliculas disponibles a desplegar en el componente `movie-type-dropdown`.

Para ello debemos crear las carpetas restantes de la organizacion ya vista, `services`, `services/models` y `repositories`.

Creacion de la carpeta `services` y `services/models`

```CMD
cd src
mkdir services
cd services
mkdir models
```

Creacion de la carpeta `repositories`

```CMD
cd src
mkdir repositories
```

## Creacion del repositorio

La carpeta de `repositories` sera la capa mas baja de nuestra aplicacion de Angular. Esta podria consumir la data desde una API Web como podria consumir la data en memoria. Lo importante es que los servicios no deben enterarse de donde proviene la data para limitar el impacto de cambio.

Para crear un repositorio procedemos a situarnos en el directorio:

```CMD
cd src
cd repositories
```

Y ejecutamos el siguiente comando de Angular CLI:

```CMD
ng generate service movie-type-api-repository
```

Esto nos generara el siguiente repositorio:

```TypeScript
@Injectable({
  providedIn: 'root'
})
export class MovieTypeApiRepositoryService {

  constructor() { }
}
```

La clase `MediaTypeApiRepositoryService` es identificada como un servicio inyectable por Angular por tener el decorador `@Inyectable`. Dentro de la metadata podemos observar que quien provee el servicio es la raiz, esto implica que es accesible por cualquier `servicio`, `componente` dentro de la aplicacion.

Dicho servicio tiene la responsabilidad de comunicarse con una API Web, para realizar dicha request http, es necesario modificar la clase de la siguiente manera:

```TypeScript
export class MovieTypeApiRepositoryService {

  constructor(private readonly _http: HttpClient) { }
}
```

Para realizar request HTTP, Angular nos provee el elemento `HttpClient` el cual nos sirve para realizar dicha accion. Este elemento tiene funciones para cada verbo http necesario para su ejecucion. Por lo que depende de que verbo necesitemos tendremos que invocar la funcion especifica.

A continuacion crearemos un metodo para obtener todos los tipos de peliculas disponibles. El resultado de implementar dicho comportamiento es el siguiente:

```TypeScript
export class MovieTypeApiRepositoryService {
  private readonly _endpoint = "movie-types";
  constructor(private readonly _http: HttpClient) {}

  public getAll(): Observable<Array<MovieTypeBasicInfoModel>> {
    return this._http.get<Array<MovieTypeBasicInfoModel>>(
      `${environment.vidlyApi}/${this._endpoint}`
    );
  }
}
```

La implementacion de dicho comportamiento impacto en crear la estructura esperada por la api `MovieTypeBasicInfoModel` la cual esta situada en `services/models`. Una vez creada la estructura, le indicamos a `HttpClient` con el uso de generic, a que tipo de dato debe de serializar el JSON obtenido en la respuesta de la api.

Un aspecto importante sobre el tipo de la estructura, es que debe ser de tipo `interface` en vez de una `class`, esto es porque la respuesta es un objeto plano que no puede ser automaticamente convertido a una instancia de una clase.

```TypeScript
export default interface MovieTypeBasicInfoModel {
  id: string;
  name: string;
}
```

Otro impacto que llevo a realizar dicho comportamiento fue la creacion de un archivo llamado `environment` el cual esta situado en `src`. Este archivo servira para acceder a variables del ambiente dentro de la aplicacion de una forma encapsulada. Es de gran utilidad este archivo para variar los valores de las variables definidas dependiendo el ambiente en el que se corra o compile la aplicacion.

Por ultimo, el tipo de retorno del comportamiento tiene que ser el mismo que el de la funcion a utilizar de la clase `HttpClient`. El tipo de retorno es `Observable` el cual hace uso del patron `Observer` que nos permite suscribirnos a un evento y actualizar el estado de la clase cuando los datos esten disponibles. [Aca](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-service/observer.md) podran encontrar mas informacion sobre el patrong `Observer` y como Angular lo utiliza.

El paso siguiente es repetir el proceso de creacion de un servicio pero para la creacion del servicio `MovieTypeService` en la carpeta `services`. Para realizar dicha creacion ejectuar los siguientes comandos:

```CMD
cd src
cd services
ng generate service movie-type
```

Teniendo como resultado la siguiente clase:

```TypeScript
@Injectable({
  providedIn: 'root'
})
export class MovieTypeService {

  constructor() { }
}
```

La definicion de esta clase es muy similar a la clase del repositorio, pero las responsabilidades son distintas. La responsabilidad de los servicios situados en `services` es de consumir repositorios que estos proveen los datos, y los servicios proveen estos datos obtenidos a los componentes. Eventualmente estas clases pueden agregar logica extra al consumo de algun tipo, logrando que la logica no recaiga en los componentes sino que en esta capa.

Esta organizacion tiene la ventaja de que los componentes se desacoplan de la forma de obtener los datos logrando que estos sean mas ligeros y solo se encarguen de la gestion y mantenimiento de la UI.

Este servicio le faltaria utilizar el repositorio encargado de obtener la data que por el momento es `MovieTypeApiRepositoryService`. Para consumir dicho repositorio, basta con declararlo como una dependencia en el constructor del servicio, como se hizo en el repositorio con `HttpClient`.

Teniendo como resultado el servicio de la siguiente manera:

```TypeScript
export class MovieTypeService {

  constructor(private readonly _repository: MovieTypeApiRepositoryService) {}
}
```

Como este servicio va a ser consumido directamente por los componentes, este tiene que definir los mismos comportamientos que el repositorio que utiliza.

Dejando la clase de la siguiente manera:

```TypeScript
export class MovieTypeService {

  constructor(private readonly _repository: MovieTypeApiRepositoryService) {}

  public getAll(): Observable<Array<MovieTypeBasicInfoModel>> {
    return this._repository.getAll();
  }
}
```

El paso siguiente es utilizar este servicio en el componente `movie-type-dropdown` para poder obtener todos los tipos de peliculas disponibles cuando el componente se este inicializando.

Teniendo como resultado el componente de la siguiente manera:

```TypeScript
export class MovieTypeDropdownComponent implements OnInit, OnDestroy {
  @Input() value: string | null = null;

  movieTypes: Array<DropdownOption> = [];

  private _movieTypeGetAllSubscription: Subscription | null = null;

  constructor(private readonly _movieTypeService: MovieTypeService) {}

  ngOnDestroy(): void {
    this._movieTypeGetAllSubscription?.unsubscribe();
  }

  ngOnInit(): void {
    this._movieTypeGetAllSubscription = this._movieTypeService
      .getAll()
      .subscribe((movieTypes) => {
        this.movieTypes = movieTypes.map((movieType) => ({
          value: movieType.id,
          label: movieType.name,
        }));
      });
  }
}
```

Como el servicio es inyectable, basta con declarar la dependencia en el constructor del componente para que cuando Angular quiera inicializar el componente le debera de inyectar una instancia del servicio.

Dado que el consumo de datos es un proceso pesado, este no debe realizarse en el constructor del componente, sino que debe realizarse en la implementacion del metodo del ciclo de vida `OnInit`. Esto nos permitira realizar la peticion de la data cuando el componente ya este renderizado y evitar problemas de instanciacion del componente.

La data del componente se vera actualizada cuando en la suscripcion a los datos estos esten listos para ser consumidos, es por eso que en el metodo dentro de la suscripcion es el lugar para actualizar el estado del componente.

Como la obtencion de la data es a traves de una suscripcion de un objeto `Observable`, esta suscripcion se debe de eliminar al momento de destruir el componente para evitar problemas de perdida de memoria. Es por esto que se implementa el comportamiento del ciclo de vida `OnDestroy`, donde hacemos la desuscripcion en caso de existir una.
