[Atras - Arquitectura de Angular](https://github.com/Maticor93/DA2-Tecnologia/blob/angular/angular-architecture.md)
# Pipe

Los pipes de Angular nos permiten declarar transformaciones de valores en el template HTML. Una clase con el decorador @Pipe define una funcion que transforma un input a un output para ser desplegado en la vista.

Angular define varios pipes, como por ejemplo [`date`](https://v17.angular.io/api/common/DatePipe) y [`currency`](https://v17.angular.io/api/common/CurrencyPipe), podemos encontrar una lista de todos los pipes definidos por angular [aca](https://v17.angular.io/api?type=pipe).

Para especificar la transformacion de un valor en un template HTML, se tiene que usar el operador de pipe `|`.

```HTML
{{interpolated_value | pipe_name}}
```

Se pueden encadenar varios pipes, enviando el output de un pipe como input al pipe siguiente. Un pipe tambien puede esperar argumentos que controlan como deberia de ser la transformacion. Por ejemplo, se le puede pasar el formato deseado al pipe `date`.

```HTML
<!-- Default format: output 'Jun 15, 2015'-->
<p>Today is {{today | date}}</p>

<!-- fullDate format: output 'Monday, June 15, 2015'-->
<p>The date is {{today | date:'fullDate'}}</p>

<!-- shortTime format: output '9:43 AM'-->
<p>The time is {{today | date:'shortTime'}}</p>
```

## Lecturas recomendadas

- [Comprendiendo pipes](https://v17.angular.io/guide/pipes-overview)
