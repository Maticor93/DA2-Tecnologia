import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, retry, throwError } from "rxjs";
import MovieTypeBasicInfoModel from "../services/models/MovieTypeBasicInfoModel";
import { environment } from "../environment";

@Injectable({
  providedIn: "root",
})
export class MovieTypeApiRepositoryService {
  private readonly _endpoint = "movie-types";
  constructor(private readonly _http: HttpClient) {}

  public getAll(): Observable<Array<MovieTypeBasicInfoModel>> {
    return this._http
      .get<Array<MovieTypeBasicInfoModel>>(
        `${environment.vidlyApi}/${this._endpoint}`
      )
      .pipe(retry(3), catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error("An error occurred:", error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, ` + `body was: ${error.error}`
      );
    }
    // Return an observable with a user-facing error message.
    return throwError("Something bad happened; please try again later.");
  }
}
