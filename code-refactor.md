[Atras - Indice](https://github.com/daniel18acevedo/DA2-Tecnologia/tree/angular-service)

# Refactor del codigo

Una de las potenciales mejores es mover la funcionalidad `handleErrores` de `MovieTypeApiRepositoryService` a una clase padre `ApiRepositoryService` para que otros repositorios de api puedan usar la misma implementacion y ligerar los repositorios de api.

Para ello crearemos la clase en `repositories` de la siguiente manera:

```CMD
cd src
cd repositories
ng generate class api-repository
```

Y la clase se definiria de la siguiente manera:

```TypeScript
export default abstract class ApiRepository {
  protected fullEndpoint: string = `${this._apiOrigin}/${this._endpoint}`;

  constructor(
    protected readonly _apiOrigin: string,
    protected readonly _endpoint: string,
    protected readonly _http: HttpClient
  ) {}

protected get<T>(extraResource = '', query = ''): Observable<T> {
    query = query ? `?${query}` : '';
    extraResource = extraResource ? `/${extraResource}` : '';

    return this._http
      .get<T>(`${this.fullEndpoint}${extraResource}${query}`)
      .pipe(retry(3), catchError(this.handleError));
  }

  protected post<T>(body: any, extraResource = ''): Observable<T> {
    extraResource = extraResource ? `/${extraResource}` : '';

    return this._http
      .post<T>(`${this.fullEndpoint}${extraResource}`, body)
      .pipe(retry(3), catchError(this.handleError));
  }

  protected putById<T>(
    id: string,
    body: any = null,
    extraResource = ''
  ): Observable<T> {
    extraResource = extraResource ? `/${extraResource}` : '';

    return this._http
      .put<T>(`${this.fullEndpoint}/${id}${extraResource}`, body)
      .pipe(retry(3), catchError(this.handleError));
  }

  protected delete<T>(extraResource = '', query = ''): Observable<T> {
    query = query ? `?${query}` : '';

    extraResource = extraResource ? `/${extraResource}` : '';

    return this._http
      .delete<T>(`${this.fullEndpoint}${extraResource}${query}`)
      .pipe(retry(3), catchError(this.handleError));
  }

  protected handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, ` + `body was: ${error.error}`
      );
    }
    // Return an observable with a user-facing error message.
    return throwError('Something bad happened; please try again later.');
  }
}
```

Dejando `MovieTypeApiRepositoryService` asi:

```TypeScript
export class MovieTypeApiRepositoryService extends ApiRepository {
  constructor(http: HttpClient) {
    super(environment.vidlyApi, 'movie-types', http);
  }

  public getAll(): Observable<Array<MovieTypeBasicInfoModel>> {
    return this.get<Array<MovieTypeBasicInfoModel>>();
  }
}
```

Otro codigo especifico de las request http a APIs es el uso de los headers, para ello vamos a definir un `get` para obtener los headers actualizados siempre que se necesiten:

```TypeScript
 protected get headers() {
    return {
      headers: new HttpHeaders({
        accept: 'application/json',
        Authorization: localStorage.getItem('token') ?? '',
      }),
    };
  }
```

Siendo usado en cada metodo implementado:

```TypeScript
  protected get<T>(extraResource = '', query = ''): Observable<T> {
    query = query ? `?${query}` : '';
    extraResource = extraResource ? `/${extraResource}` : '';

    return this._http
      .get<T>(`${this.fullEndpoint}${extraResource}${query}`, this.headers)
      .pipe(retry(3), catchError(this.handleError));
  }

  protected post<T>(body: any, extraResource = ''): Observable<T> {
    extraResource = extraResource ? `/${extraResource}` : '';

    return this._http
      .post<T>(`${this.fullEndpoint}${extraResource}`, body, this.headers)
      .pipe(retry(3), catchError(this.handleError));
  }

  protected putById<T>(
    id: string,
    body: any = null,
    extraResource = ''
  ): Observable<T> {
    extraResource = extraResource ? `/${extraResource}` : '';

    return this._http
      .put<T>(`${this.fullEndpoint}/${id}${extraResource}`, body, this.headers)
      .pipe(retry(3), catchError(this.handleError));
  }

  protected delete<T>(extraResource = '', query = ''): Observable<T> {
    query = query ? `?${query}` : '';

    extraResource = extraResource ? `/${extraResource}` : '';

    return this._http
      .delete<T>(`${this.fullEndpoint}${extraResource}${query}`, this.headers)
      .pipe(retry(3), catchError(this.handleError));
  }
```
