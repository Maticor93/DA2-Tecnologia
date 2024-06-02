import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import MovieTypeBasicInfoModel from '../services/movie-type/models/movie-type-basic-info.model';
import ApiRepository from './api-repository';
import environments from '../../environments';

@Injectable({
  providedIn: 'root',
})
export class MovieTypeApiRepositoryService extends ApiRepository {
  constructor(http: HttpClient) {
    super(environments.vidlyApi, 'movie-types', http);
  }

  public getAll(): Observable<Array<MovieTypeBasicInfoModel>> {
    return this.get<Array<MovieTypeBasicInfoModel>>();
  }
}
