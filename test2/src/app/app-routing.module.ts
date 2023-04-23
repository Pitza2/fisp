import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {Routes} from "@angular/router";
import {StudentListComponent} from "./components/Students/student-list/student-list.component";


const routes : Routes =[
  {
    path:'',
    component:StudentListComponent
  }
]
@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class AppRoutingModule { }
