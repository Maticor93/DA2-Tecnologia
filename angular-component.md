# Componentes

Los componentes controlan una porcion de la pantalla denominada vista. Consiste en una clase de TypeScript, un template HTML, y un estilado en CSS. La clase de TypeScript define la interaccion del codigo HTML con la estructura DOM, mientras que el codigo de estilado define la apariencia.

Una aplicacion de angular usa componentes individuales para definir y controlar diferentes aspectos de la aplicacion. Por ejemplo, una aplicacion puede incluir componentes para describir:

- La raiz de la aplicacion con la navegacion
- Una lista de peliculas
- Un editor de pelicula

Un componente puede contener una vista jerarquica, la cual permite definir de forma arbitraria areas determinadas de la pantalla que pueden ser creadas, modificadas y destruidas como unidad. Una vista jerarquica puede mezclar vistas definidas en componentes que declara otro modulo. Esto es lo mas comun sobretodo para librarias de UI.

Supongamos que tenemos los siguientes modulos y componentes declarados

<p align="center">
<img src="./images/image-4.png">
</p>
<p align="center">
[Modulos y componentes]
</p>

Y ahora se quiere que dichos componentes se usen entre si, teniendo como resultado la vista jerarquica.

<p align="center">
<img src="./images/image-3.png">
</p>
<p align="center">
[Ejemplo de uso jerarquico]
</p>

Cuando se crea un componente, este se asocia directamente con una sola vista, llamada vista host. La vista host puede ser la raiz de una vista jerarquica, la cual puede contener embebida otras vistas, que son las vistas host de otros componentes. Estos componentes pueden estar declarados en el mismo modulo, o pueden ser importados de un modulo distinto. Las vistas en el arbol pueden ser anidados en cualquier nivel.

Toda aplicacion de Angular tiene al menos un componente, el componente raiz que conecta la vista jerarquica con la pagina DOM (document object model). Cada componente define una clase que contiene logica y data de la aplicacion y esta asociada a un template HTML que define la vista a desplegarse en el ambiente.

El decorador a utilizar para declarar una clase como componente es @Component(). Los decoradores son funciones que modifican clases JavaScript. Angular define un numero de decoradoras que atachean metadata especifica a las clases, asi el sistema de Angular puede saber que significan esas clases y como deberian de operar y ser tratadas.

Ejemplo de componnete

```TypeScript
@Component({
  selector:    'app-movie-feed',
  templateUrl: './movie-feed.component.html',
  styleUrls: ['./movie-feed.component.css']
})
export class MovieFeedComponent implements OnInit {
  /* . . . */
}
```

Los parametros mas importantes son:

| Parametro   | Detalles                                                                                                                                                                                                                                                                                           |
| ----------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| selector    | Un tag que le indica a Angular de crear e insertar una instancia del componente donde sea que encuentre dicho tag en un template HTML. Por ejemplo, si una vista HTML contiene <app-move-feed/>, entonces Angular insertara una instancia de la vista del componente MovieFeedComponent en ese tag |
| templateUrl | La ruta relativa del template HTML del componente. Alternativamente, se podria desarrollar el template HTML como valor de la property `template`. Este template HTML define la vista host del componente                                                                                           |
| styleUrls   | Un array de string donde se pone la referencia relativa a todos los archivos de estilado que se quieren aplicar al template HTML                                                                                                                                                                   |

## Template HTML

La vista de un componente se define en el template HTML. Un template es un documento HTML que le indica a Angular como renderizar un componente.

<p align="center">
<img src="./images/image-5.png">
</p>
<p align="center">
[De codigo a renderizacion]
</p>

Las vistas son organizadas jerarquicamente, permitiendo modificar o mostrar y ocultar una seccion entera como una unidad. El template inmediatamente se asocia con el componente que lo define como la vista host. El componente tambien puede definir una vista jerarquica, la cual contiene vistas embebidas, hosteadas por otros componentes.

<p align="center">
<img src="./images/image-6.png">
</p>
<p align="center">
[Ejemplo de vista jerarquica]
</p>

## Ciclos de vida

La instancia de un componente tiene un ciclo de vida que empieza cuando Angular instancia la clase del componente y renderiza la vista del componente junto con las vistas de los hijos. El ciclo de vida continua con la deteccion de cambios, mientras que Angular chequea cuando la data bindeada cambia, y actualiza tanto la vista como la instancia del componente que la necesita. El ciclo de vida termina cuando Angular destruye la instancia del componente y remueve el template renderizado del DOM. Las directivas tienen un ciclo de vida similar, Angular crea, actualiza, y destruye las instancias que estan en ejecucion.

Es comun ver en una aplicacion diferentes [ciclos de vida](https://v17.angular.io/guide/glossary#lifecycle-hook) para atender eventos especificos en la vida de un componente o directiva para inicializar instancias, estar atento a la deteccion de cambios cuando es necesario, responder a actualizaciones durante la deteccion de cambios, hacer limpieza antes de la eliminacion de una instancia.

Los ciclos de vida dan la oportunidad de actuar en la instancia de un componente o directiva ante un evento en el momento adecuado.

Cada instancia define un prototipo para el metodo del ciclo de vida, cuyo nombre es el de la interfaz con el prefijo `ng`. Por ejemplo, el ciclo de vida `OnInit` tiene un metodo llamado `ngOnInit()`. La implementacion de dicho metodo en un componente o directiva, sera invocado por Angular despues de instanciar el estado del componente o directiva por primera vez.

```TypeScript
@Directive({selector: '[appPeekABoo]'})
export class PeekABooDirective implements OnInit {
  private int nextId = 0;

  constructor(private logger: LoggerService) { }

  // implement OnInit's `ngOnInit` method
  ngOnInit() {
    this.logIt('OnInit');
  }

  logIt(msg: string) {
    this.logger.log(`#${nextId++} ${msg}`);
  }
}
```

No es necesario implementar todos los ciclos de vida, solo los que sean necesarios para el componente.

## Orden de ejecucion

Despues de que la aplicacion instancia el componente o el ciclo de vida al llamar al constructor, Angular llama los metodos de los ciclos de vida que fueron implementados en el momento deseado.

| Metodo del ciclo de vida | Proposito                                                                                                                                                                              | Tiempo                                                                                                                                    |
| ------------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- |
| ngOnChanges()            | Responde a cuando Angular setea o resetea valores bindeados a properties. El metodo recibe un objeto SimpleChanges con el estado actual y previo de los valores de las properties      | Es llamado antes de ngOnInit() si el componente tiene definido este comportamiento, y cuando una o mas data bindeada cambia               |
| ngOnInit()               | Inicializa el componente o directiva despues que Angular despliega los properties bindeadas.                                                                                           | Es llamado una vez, despues del primer ngOnChanges.                                                                                       |
| ngDoCheck()              | Detecta y actua ante cambios que Angular no puede o no detecta por si solo                                                                                                             | Es llamado inmediatamente despues de ngOnChanges() en cada cambio ocurrido, e inmediatamente despues de ngOnInit en la primera ejecucion. |
| ngAfterContentInit()     | Responde despues de que Angular setea contenido externo a la vista del componente.                                                                                                     | Es llamado una vez despues de ngDoCheck().                                                                                                |
| ngAfterContentChecked()  | Responde despues que Angular chequea el contenido del componente o directiva.                                                                                                          | Es llamado despues de ngAfterContentInit() y en cada llamada de ngDoCheck()                                                               |
| ngAfterViewInit()        | Responde despues de que Angular inicializa la vista del componente y la de los hijos                                                                                                   | Es llamado una vez despues de la primer llamada de ngAfterContentChecked()                                                                |
| ngAfterViewChecked()     | Responde despues de que Angular chequea la vista del componente y la de los hijos                                                                                                      | Es llamado despues de ngAfterViewInit() y despues de cada llamada de ngAfterContentChecked                                                |
| ngOnDestroy()            | Hace limpieza antes de que Angular destruya el componente. Es un buen momento para desuscribirse de cualquier objeto Observable y desatachear cualquier evento para evitar memory leak | Es llamado inmediatamente antes de que Angular destruye el componente                                                                     |

Por ejemplo si un componente implementase todos los ciclos de vida el orden de ejecucion seria el siguiente:

<p align="center">
<img src="./images/image-10.png">
</p>
<p align="center">
[Orden de ejecucion de los ciclos de vida]
</p>

Teniendo como salida lo siguiente:

| Orden | Salida              |
| ----- | ------------------- |
| 1     | OnChanges           |
| 2     | OnInit              |
| 3     | DoCheck             |
| 4     | AfterContentInit    |
| 5     | AfterContentChecked |
| 6     | AfterViewInit       |
| 7     | AfterViewChecked    |
| 8     | DoCheck             |
| 9     | AfterContentChecked |
| 10    | AfterViewChecked    |
| 11    | OnDestroy           |

## Inicializando un componente o directiva

Se debe de usar el metodo `ngOnInit()` para realizar alguna de las tareas siguientes:

| Tarea                                                                         | Detalles                                                                                                                                                                                                                                                                                                                                                                                   |
| ----------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Realizar inicializaciones complejas por fuera del constructor                 | Los componentes deberian de ser rapidos y seguros de inicializar. No se deberia de, por ejemplo, hacer request HTTP en el constructor. Al momento de instanciar un componente, este no se deberia de intentar conectar remotamente a un servidor independientemente si es creado por un flujo de uso o de test. NgOnInit es un buen lugar para un componente para realizar dichas acciones |
| Inicializar el componente despues de que Angular ya inicializo las properties | Los constructores no deberian de hacer nada mas que inicializar con valores por defecto el estado del componente.                                                                                                                                                                                                                                                                          |

## Lecturas

- [Introduccion a componentes de Angular](https://v17.angular.io/guide/architecture-components)
- [Componentes de Angular](https://v17.angular.io/guide/component-overview)
- [Ejemplo de ciclos de vida en vivo](https://stackblitz.com/run?file=src%2Fapp%2Fapp.component.html)

