import { Injectable, SkipSelf } from '@angular/core'
import { environment } from '../../environments/environment'
import { HttpClient } from '@angular/common/http'
import { Applicant } from '../models/Applicant.model'
import { General } from '../models/General.model'

@Injectable({
  providedIn: 'root'
})
export class ApplicantJobService {
  baseApiUrl: string = environment.baseApiUrl

  constructor (private http: HttpClient) {
  }

  Apply () {
    var g: General = this.http.get(this.baseApiUrl + 'api/general/user', localStorage.getItem('jwt'))
    return this.http.post(this.baseApiUrl + 'api/applicants', g)
  }
}
