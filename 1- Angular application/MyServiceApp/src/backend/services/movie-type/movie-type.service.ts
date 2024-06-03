import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import MovieTypeBasicInfoModel from "./models/MovieTypeBasicInfoModel";
import { MovieTypeApiRepositoryService } from '../../repositories/movie-type-api-repository.service';

@Injectable({
  providedIn: "root",
})
export class MovieTypeService {
  constructor(private readonly _repository: MovieTypeApiRepositoryService) { }

  public getAll(): Observable<Array<MovieTypeBasicInfoModel>> {
    return this._repository.getAll();
  }
}
