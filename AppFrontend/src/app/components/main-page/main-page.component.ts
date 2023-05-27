import { Component } from '@angular/core';
import {MatCheckboxChange} from "@angular/material/checkbox";
import {FormControl} from "@angular/forms";

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent {
isApplicant:boolean=true;
formular:FormControl=new FormControl('');
  foo(event:MatCheckboxChange): void {
    console.log(this.isApplicant);
    this.isApplicant=!this.isApplicant;
  }

}
