import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { environment } from '../../environments/environment'
import { Student } from '../models/student.model'
import { jobCompany } from '../models/jobCompany'

@Injectable({
  providedIn: 'root'
})
export class CompanyJobService {

  baseApiUrl: string = environment.baseApiUrl
  constructor(private http : HttpClient) { }
  getJobListings(){
    return this.http.get<jobCompany[]>(environment.baseApiUrl+'api/jobs/1');
  }
  apply(object:object){
    //return this.http.post(this.baseApiUrl+'api/jobs',);
  }
}
