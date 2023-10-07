import { Component } from '@angular/core';
import {FormControl} from "@angular/forms";
import {CompanyService} from "../../services/company.service";
import {GeneralService} from "../../services/general.service";
import {catchError, throwError} from "rxjs";
import {General} from "../../models/General.model";
import { ApplicantPageComponent } from '../applicant-page/applicant-page.component'

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent {
  username :FormControl=new FormControl('');
  pass :FormControl=new FormControl('');

  general:General={username:"",extra:"",isApplicant:true,id:0}
  loggedIn:boolean=false;
  constructor(private generalService:GeneralService) {
  }
  LogIn(){

    this.generalService.TryLogin(this.username.value,this.pass.value).pipe(catchError(err=>{
      const errcode=err.status;
      if(errcode==404){
        alert("user not found");
      }else
      if(errcode==400){
        alert("wrong password");
      }else {
        alert("unknown error");
      }
      return throwError(err);
    })).subscribe(data=>{this.loggedIn=true;
      console.log(data.username);
        this.general.username=data.username;
        this.general.extra=data.extra;
        this.general.isApplicant=data.isApplicant;
        this.general.id=data.id;
        ApplicantPageComponent
        window.location.href="home";
        console.log(data);
    })
  }
}
