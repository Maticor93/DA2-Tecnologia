[Atras - Indice](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-service)

# Manejo de errores api

Una aplicacion deberia de darle feedback util al usuario cuando ocurre un error. Un objeto de error crudo no es particularmente util para proveer feedback del error. En adicion para detectar los errores ocurridos, se necesita obtener detalles del error y usar esos detalles para construir una respuesta user-friendly.

Pueden ocurrir dos tipos de errores:

- El servidor puede rechazar la request, retornando una respuesta HTTP con un codigo de error como 404 o 500. Estos son errores de respuesta.

- Algo ocurrio mal del lado del cliente como un error en la conexion a internet que previene la completitud exitosa de la request o el operador de `RxJS` lanzo una excepcion.

Estos errores son del tipo `ErrorEvent`.

`HttpClient` captura ambos tipos de errores en su objeto `HttpErrorResponse`. Lo que nos permite inspeccionar la respuesta para identificar la causa del error.

El siguiente codigo muestra una forma de manejar los errores:

```TypeScript
private handleError(error: HttpErrorResponse) {
  if (error.error instanceof ErrorEvent) {
    // A client-side or network error occurred. Handle it accordingly.
    console.error('An error occurred:', error.error.message);
  } else {
    // The backend returned an unsuccessful response code.
    // The response body may contain clues as to what went wrong.
    console.error(
      `Backend returned code ${error.status}, ` +
      `body was: ${error.error}`);
  }
  // Return an observable with a user-facing error message.
  return throwError(
    'Something bad happened; please try again later.');
}
```

El manejador de errores retorna una instancia de `ErrorObservable` de `RxJS` con un mensaje de error user-friendly. El siguiente codigo actualiza la obtencion de los tipos de peliculas usando un [`pipe`](https://docs.angular.lat/guide/pipes) para enviar todos los respuestas `Observables` del metodo al manejador de error.

```TypeScript
  public getAll(): Observable<Array<MovieTypeBasicInfoModel>> {
    return this._http
      .get<Array<MovieTypeBasicInfoModel>>(
        `${environment.vidlyApi}/${this._endpoint}`
      )
      .pipe(catchError(this.handleError));
  }
```

## Lecturas Recomendadas

- [Manejo de errores](https://docs.angular.lat/guide/http#handling-request-errors)

