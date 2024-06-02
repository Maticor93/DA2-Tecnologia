import { Injectable } from '@angular/core';
import { SessionApiRepositoryService } from '../../repositories/session-api-repository.service';
import { Observable } from 'rxjs';
import UserCredentialsModel from './models/user-credentials.model';
import SessionCreatedModel from './models/session-created.model';

@Injectable({
  providedIn: 'root',
})
export class SessionService {
  constructor(private readonly _repository: SessionApiRepositoryService) {}

  public login(
    credentials: UserCredentialsModel
  ): Observable<SessionCreatedModel> {
    return this._repository.login(credentials);
  }
}
