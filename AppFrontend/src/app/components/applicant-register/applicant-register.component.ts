import { Component } from '@angular/core';
import {FormControl} from "@angular/forms";
import {Applicant} from "../../models/Applicant.model";
import {ApplicantsService} from "../../services/applicants.service";

@Component({
  selector: 'app-applicant-register',
  templateUrl: './applicant-register.component.html',
  styleUrls: ['./applicant-register.component.css']
})
export class ApplicantRegisterComponent {
username :FormControl=new FormControl('');
  link :FormControl=new FormControl('');
  pass :FormControl=new FormControl('');
  pass2 :FormControl=new FormControl('');
  constructor(private ApplicantService:ApplicantsService) {
  }
  Register():void{
    if(this.pass.value!=this.pass2.value){
      window.alert("passwords don't match");
    }else {
      var appl={
        linkedin: this.link.value,
        name: this.username.value,
        password: this.pass.value,
        id:0
      };
      console.log(JSON.stringify(appl));
      console.log(this.ApplicantService.baseApiUrl);
      this.ApplicantService.PostApplicant({
        name: this.username.value,
        linkedin: this.link.value,
        password: this.pass.value

      }).subscribe(x=>window.alert("plm"));
    }
  }
}
