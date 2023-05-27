import { Component } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {catchError, throwError} from "rxjs";
import {CompanyService} from "../../services/company.service";

@Component({
  selector: 'app-company-register',
  templateUrl: './company-register.component.html',
  styleUrls: ['./company-register.component.css']
})
export class CompanyRegisterComponent {
  username :FormControl=new FormControl('');
  phone :FormControl=new FormControl('');
  pass :FormControl=new FormControl('');
  pass2 :FormControl=new FormControl('');
  constructor(private compService:CompanyService) {
  }
  Register() {
    if(this.pass.value!=this.pass2.value){
      window.alert("passwords don't match");
    }else {
      this.compService.PostCompany({
        name: this.username.value,
        phone: this.phone.value,
        password: this.pass.value,
      }).pipe(
        catchError(err =>{
          const errcode=err.status;
          if(errcode==400){
            alert("user already exists");
          }
          return throwError(err);
        })
      ).subscribe((data)=>{
        alert("all good");
      });
    }
  }
}
