import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Applicant} from "../models/Applicant.model";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class ApplicantsService {
  baseApiUrl:string=environment.baseApiUrl
  constructor(private http:HttpClient) { }
  PostApplicant(appl:Applicant){
    return this.http.post(this.baseApiUrl+"api/applicants",appl);
  }
}
