[Atras - Indice](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-service)

# Reintentos automaticos

A veces un error desaparece automaticamente al reintentar realizar la peticion nuevamente. Por ejemplo, conexiones interrumpidas son muy comunes en escenarios donde involucran dispositivos moviles, e intentando nuevamente la peticion puede producir un resultado exitoso.

La libreria `RxJS` ofrece varios operadores de reintento. Por ejemplo, el operador `retry()` que automaticamente re suscribre a un `Observable` fallido un numero de veces determinadas. Re suscribiendoce al resultado de una llamada `HttpClient` tiene el efecto de realizar la request HTTP nuevamente.

El siguiente ejemplo muestra como en el `pipe` podemos agregar la configuracion del reintento antes de pasarle la respuesta al manejador de error.

```TypeScript
public getAll(): Observable<Array<MovieTypeBasicInfoModel>> {
    return this._http
      .get<Array<MovieTypeBasicInfoModel>>(
        `${environment.vidlyApi}/${this._endpoint}`
      )
      .pipe(
        retry(3), // reintenta una solicitud fallida hasta 3 veces
        catchError(this.handleError) // luego maneja el error
        );
  }
```

Es importante destacar que el uso de este operador tiene que ser antes de usar el operador `catchError`, sino no tendra efecto. Este operador nos permite resuscribirnos al observable original, el cual puede ser re ejecutado en caso de haber ocurrido algun error.

## Lecturas Recomendadas

- [Reintentos automaticos](https://docs.angular.lat/guide/http#retrying-a-failed-request)
