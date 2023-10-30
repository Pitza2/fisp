import { Injectable } from '@angular/core'
import { HttpClient, HttpParams } from '@angular/common/http'
import { environment } from '../../environments/environment'
import { Student } from '../models/student.model'
import { jobCompany } from '../models/jobCompany'
import { ApplicantJob } from '../models/ApplicantJob.model'

@Injectable({
  providedIn: 'root'
})
export class CompanyJobService {

  baseApiUrl: string = environment.baseApiUrl

  constructor (private http: HttpClient) {
  }

  getJobListings () {
    return this.http.get<jobCompany[]>(environment.baseApiUrl + 'api/jobs/1')
  }

  getById (id: number) {
    const options = id ? { params: new HttpParams().set('id', id) } : {}
    return this.http.get<jobCompany>(this.baseApiUrl + 'api/jobs/id',options)
  }

  AddJob (obj: { jobTitle: string | null | undefined; jobDescription: string | null | undefined }){
    return this.http.post(this.baseApiUrl + 'api/jobs', obj)
  }
}
