import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import MovieTypeBasicInfoModel from '../services/models/MovieTypeBasicInfoModel';
import { environment } from '../environment';
import ApiRepository from './api-repository';

@Injectable({
  providedIn: 'root',
})
export class MovieTypeApiRepositoryService extends ApiRepository {
  constructor(http: HttpClient) {
    super(environment.vidlyApi, 'movie-types', http);
  }

  public getAll(): Observable<Array<MovieTypeBasicInfoModel>> {
    return this.get<Array<MovieTypeBasicInfoModel>>();
  }
}
