import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Company} from "../models/Company.model";
import {environment} from "../../environments/environment";
import {General} from "../models/General.model";
import {login} from "../models/login.model";

@Injectable({
  providedIn: 'root'
})
export class GeneralService {

  baseApiUrl:string=environment.baseApiUrl
  constructor(private http : HttpClient) { }
  TryLogin(username:string,pass:string){

    const lg:login={username:username,password:pass};

    return this.http.post<General>(this.baseApiUrl+"api/general",lg);
  }
}
