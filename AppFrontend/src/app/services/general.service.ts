import { Injectable } from '@angular/core'
import { HttpClient, HttpParams } from '@angular/common/http'
import { environment } from '../../environments/environment'
import { type General } from '../models/General.model'
import { type login } from '../models/login.model'
import { type Observable } from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class GeneralService {
  baseApiUrl: string = environment.baseApiUrl

  constructor (private readonly http: HttpClient) {
  }

  TryLogin (username: string, pass: string) {
    const lg: login = {
      username,
      password: pass
    }

    return this.http.post(this.baseApiUrl + 'api/general', lg, { responseType: 'text' })
  }

  GetUserData (): Observable<General> {
    return this.http.get<General>(environment.baseApiUrl + 'api/general')
  }
}
