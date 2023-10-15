import { Injectable, SkipSelf } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { environment } from '../../environments/environment'
import { Applicant } from '../models/Applicant.model'
import { Company } from '../models/Company.model'

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  baseApiUrl: string = environment.baseApiUrl

  constructor (private http: HttpClient) {
  }

  PostCompany (comp: Company) {
    return this.http.post(this.baseApiUrl + 'api/companies', comp)
  }
}
