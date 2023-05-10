import { Component } from '@angular/core';
import {FormControl} from "@angular/forms";
import {MatCheckboxChange} from "@angular/material/checkbox";

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})
export class RegisterPageComponent {
  isApplicant:boolean=true;
  formular:FormControl=new FormControl('');
  foo(event:MatCheckboxChange): void {
    console.log(this.isApplicant);
    this.isApplicant=!this.isApplicant;
  }
}
