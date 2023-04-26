import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Student} from "../models/student.model";
import {Observable} from "rxjs";
import {map} from "rxjs/operators"
@Injectable({
  providedIn: 'root'
})
export class StudentsService {
baseApiUrl:string=environment.baseApiUrl
  constructor(private http : HttpClient) { }
  getAllStudents(){
   return this.http.get<Student[]>(environment.baseApiUrl+'api/students');
  }
}
