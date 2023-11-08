import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { Routes } from '@angular/router'
import { RouterModule } from '@angular/router'
import { LoginPageComponent } from './components/login-page/login-page.component'
import { RegisterPageComponent } from './components/register-page/register-page.component'
import { ApplicantPageComponent } from './components/applicant-page/applicant-page.component'
import { CompanyPageComponent } from './components/company-page/company-page.component'
import { ApplicationsViewComponent } from './components/applicant-page/applications-view/applications-view.component'

const routes: Routes = [
  {
    path: '',
    component: LoginPageComponent
  },
  {
    path: 'login',
    component: LoginPageComponent
  },
  {
    path: 'register',
    component: RegisterPageComponent
  },
  {
    path: 'home/applicant/:username',
    component: ApplicantPageComponent
  },

  {
    path: 'home/company/:username',
    component: CompanyPageComponent
  },
  {
    path: 'applications/:username',
    component: ApplicationsViewComponent
  }
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule {
}
