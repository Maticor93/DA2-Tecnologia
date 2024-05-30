import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import MovieTypeBasicInfoModel from "../services/models/MovieTypeBasicInfoModel";
import { environment } from "../environment";

@Injectable({
  providedIn: "root",
})
export class MovieTypeApiRepositoryService {
  private readonly _endpoint = "movie-types";
  constructor(private readonly _http: HttpClient) {}

  public getAll(): Observable<Array<MovieTypeBasicInfoModel>> {
    return this._http.get<Array<MovieTypeBasicInfoModel>>(
      `${environment.vidlyApi}/${this._endpoint}`
    );
  }
}
