import { Injectable, SkipSelf } from '@angular/core'
import { HttpClient, HttpParams } from '@angular/common/http'
import { Applicant } from '../models/Applicant.model'
import { environment } from '../../environments/environment'
import { ApplicantJob } from '../models/ApplicantJob.model'
import { catchError } from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class ApplicantsService {
  baseApiUrl: string = environment.baseApiUrl

  constructor (private http: HttpClient) {
  }

  PostApplicant (appl: Applicant) {
    return this.http.post(this.baseApiUrl + 'api/applicants', appl)
  }

  getById (id: number) {
    const options = id ? { params: new HttpParams().set('id', id) } : {}
    return this.http.get<Applicant>(this.baseApiUrl + 'api/applicants/id', options)
  }
}
