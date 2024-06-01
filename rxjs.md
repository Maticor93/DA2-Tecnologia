[Atras - Indice](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-service)

# RxJS

La programacion rectiva es un paradigma de la programacion asincrona con streams de datos y la propagacion de cambios. RxJS (Reactive Extensions for JavaScript) es una libreria para la programacion reactiva usando observables que hacen mas facilmente la composicion de llamadas callback asincronas.

RxJS provee una implementacion del tipo `Observable`, el cual sirve para utilizar este paradigma de programacion. Tambien provee funciones utiles para crear y trabajar con estos tipos. Estas funciones pueden ser usadas para:

- Convertir codigo existente que usa operaciones asincronas a observables

- Iterar los valores de un stream

- Mapear valores a tipos diferentes

- Filtrar streams

- Componer multiples streams

Los conceptos escenciales en `RxJS` que resuelven eventos asincronos son:

- Observable: representa la idea de invocar una coleccion de valores futuros o eventos

- Observer: es una coleccion de funciones callback que saben como escuchar los valores entregados por el Observable

- Subscription: representa la ejecucion de un Observable, es sumamente util para cancelar la ejecucion

- Operators: son puramente funciones que permiten lidear con el paradigma de programacion funcional con colecciones.

- Subject: es equivalente a `EventEmitter`, y la unica forma de castear un valor o evento a multples observers

- Schedulers: son dispatches centralizados para controlar la concurrencia, permitiendonos coordinar cuando la ejecucion ocurre.

## Operadores

Los operadores son funciones construidos bajo la misma paradigma de los observables que nos permiten una manipulacion mas sofisticada a las colecciones. Por ejemplo, RxJS define los siguientes operadores `map`, `filter`, `concat` y `flatMap`.

Los operadores reciben unas opciones de configuracion, y retornan una funcion que recibe un observable. Cuando la funcion retornada es ejecutada, el operador observa la emision de valores por el observable, los transforma, y retorna un nuevo observable con esos valores transformados. Aca podemos ver un codigo de ejemplo:

```TypeScript
import { of } from 'rxjs';
import { map } from 'rxjs/operators';

const nums = of(1, 2, 3);

const squareValues = map((val: number) => val * val);// la funcion map recibe la funcion que realiza la conversion y la guarda en una variable llamada squareValues
const squaredNums = squareValues(nums);

squaredNums.subscribe(x => console.log(x)); //cuando los elementos esten listos para utilizarlos, seran impresos en la consola

// Logs
// 1
// 4
// 9
```

Se pueden usar `pipes` para vincular operadores. Los `pipes` nos permiten combinar multiples funciones en una sola funcion. La funcion `pipe` toma como argumentso las funciones que queremos combinar, y retorna una nueva funcion, que cuando es ejecutada, ejecuta todas las funciones compuestas en el orden declaradas.

Un set de operadores aplicados a un observable es una receta - esto quiere decir, que un set de instrucciones en un orden determinado producira un resultado esperado. Por si solos, las instrucciones no hacen nada. Es necesario invocar el metodo `subscribe` para producir un resultado de un set de instrucciones. Aca podemos ver un codigo de ejemplo:

```TypeScript
import { of, pipe } from 'rxjs';
import { filter, map } from 'rxjs/operators';

const nums = of(1, 2, 3, 4, 5);

// Create a function that accepts an Observable.
const squareOddVals = pipe(
  filter((n: number) => n % 2 !== 0),
  map(n => n * n)
);

// Create an Observable that will run the filter and map functions
const squareOdd = squareOddVals(nums);

// Subscribe to run the combined functions
squareOdd.subscribe(x => console.log(x));
```

La funcion `pipe` es tambien un metodo del tipo observable de `RxJS`, asi que podemos utilizar esta version mas corta de la funcion:

```TypeScript
import { of } from 'rxjs';
import { filter, map } from 'rxjs/operators';

const squareOdd = of(1, 2, 3, 4, 5)
  .pipe(
    filter(n => n % 2 !== 0),
    map(n => n * n)
  );

// Subscribe to get values
squareOdd.subscribe(x => console.log(x));
```

## Observables vs Promise

Otra forma bastante comun de obtener datos a través de HTTP es usando promises. Las promises/promesas son objetos de JavaScript que sirven para hacer computación asincrónica, representando un cierto valor que puede estar ahora, en el futuro o nunca. Estas permiten setear manejadores (funciones o callbacks), que ejecuten comportamiento una vez que el valor esté disponible. Las llamadas por HTTP, pueden ser manejadas a través de promesas. Esto permite que métodos asíncronicos devuelvan valores como si fueran sincrónicos: en vez de inmediatamente retornar el valor final, el método asincrónico devuelve una promesa de suministrar el valor en algún momento en el futuro.

Tanto Observables como Promises sirven para lo mismo, pero los Observables permiten hacer más cosas:

- Los Observables permiten cancelar la suscripcion, mientras que las Promises no. Si el resultado de una request HTTP a un servidor o alguna otra operación costosa que es asincrónica no es más necesaria, el objeto Suscription sobre un Observable puede ser cancelado.

- Las Promises manejan un unico evento, cuando una operación asincronica completa o falla. Los Observables son como los Stream (en muchos lenguajes), y permiten pasar cero o mas eventos donde el callback sera llamado para cada evento.

- En general, se suelen usar Observables porque permiten hacer lo mismo que las Promises y más.

- Los Observables proveen operadores como map, forEach, reduce, similares a un array.

## Convenciones de nombres

Como las aplicaciones de Angular estan desarrolladas usando TypeScript, deberiamos de poder identificar cuando una variable es un observable. Para detectar dicha evidencia, es normal terminar el nombre de las variables de este tipo con el signo `$`.

Esto puede ser de gran utilidad para tener clean code. A parte, si tambien queremos guardar el valor mas reciente del observable, puede ser muy conveniente utilizar el mismo nombre del observable pero sin el signo `$`. Por ejemplo:

```TypeScript
@Component({
  selector: 'app-stopwatch',
  templateUrl: './stopwatch.component.html'
})
export class StopwatchComponent {

  stopwatchValue = 0;
  stopwatchValue$!: Observable<number>;

  start() {
    this.stopwatchValue$.subscribe(num =>
      this.stopwatchValue = num
    );
  }
}
```

## Lecturas Recomendadas

- [Documentacion oficial de RxJS](https://rxjs.dev/guide/overview)

- [RxJS en Angular](https://v16.angular.io/guide/rx-library)
