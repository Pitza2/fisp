import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {Router, Routes} from "@angular/router";
import {RouterModule} from "@angular/router";
import {StudentListComponent} from "./components/Students/student-list/student-list.component";
import{LoginPageComponent} from "./components/login-page/login-page.component";
import {RegisterPageComponent} from "./components/register-page/register-page.component";

const routes : Routes =[
  {
    path:'',component:LoginPageComponent
  },
  {
    path:'login',component:LoginPageComponent
  },
  {
    path:'register',component:RegisterPageComponent
  }
]
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[
    RouterModule
  ]
})
export class AppRoutingModule { }
