import { Injectable, SkipSelf } from '@angular/core'
import { environment } from '../../environments/environment'
import { HttpClient } from '@angular/common/http'
import { Applicant } from '../models/Applicant.model'
import { General } from '../models/General.model'
import { ApplicantJob } from '../models/ApplicantJob.model'
import { Observable } from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class ApplicantJobService {
  baseApiUrl: string = environment.baseApiUrl

  constructor (private http: HttpClient) {
  }

  apply (aj: ApplicantJob) {
    return this.http.post(this.baseApiUrl + 'api/jobs/applicant', aj)
  }

  getApplicationList (): Observable<ApplicantJob[]> {
    return this.http.get<ApplicantJob[]>(this.baseApiUrl + 'api/jobs/applicant')
  }
}
