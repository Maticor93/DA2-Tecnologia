import { Injectable } from '@angular/core';
import ApiRepository from './api-repository';
import { HttpClient } from '@angular/common/http';
import environments from '../../environments';
import UserCredentialsModel from '../services/session/models/UserCredentialsModel';
import { Observable } from 'rxjs';
import SessionCreatedModel from '../services/session/models/SessionCreatedModel';

@Injectable({
  providedIn: 'root',
})
export class SessionApiRepositoryService extends ApiRepository {
  constructor(http: HttpClient) {
    super(environments.vidlyApi, 'sessions', http);
  }

  public login(
    credentials: UserCredentialsModel
  ): Observable<SessionCreatedModel> {
    return this.post(credentials);
  }
}
