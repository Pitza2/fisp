import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http'
import { AppComponent } from './app.component'
import { StudentListComponent } from './components/Students/student-list/student-list.component'
import { AppRoutingModule } from './app-routing.module'
import { MainPageComponent } from './components/main-page/main-page.component'
import { MatInputModule } from '@angular/material/input'
import { MatIconModule } from '@angular/material/icon'
import { MatOptionModule } from '@angular/material/core'
import { MatSelectModule } from '@angular/material/select'
import { NgbModule } from '@ng-bootstrap/ng-bootstrap'
import { MatCheckboxModule } from '@angular/material/checkbox'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { RegisterPageComponent } from './components/register-page/register-page.component'
import { ApplicantRegisterComponent } from './components/applicant-register/applicant-register.component'
import { CompanyRegisterComponent } from './components/company-register/company-register.component'
import { MatButtonModule } from '@angular/material/button'
import { LoginPageComponent } from './components/login-page/login-page.component'
import { ApplicantPageComponent } from './components/applicant-page/applicant-page.component'
import { MatPaginatorModule } from '@angular/material/paginator'
import { MatCardModule } from '@angular/material/card'
import { MatExpansionModule } from '@angular/material/expansion'
import { JobListElementComponent } from './components/job-list-element/job-list-element.component'
import { CompanyPageComponent } from './components/company-page/company-page.component'
import { InterceptorService } from './services/interceptor.service';
import { ApplicationListElementComponent } from './components/application-list-element/application-list-element.component'
import { MatMenuModule } from '@angular/material/menu'

@NgModule({
  declarations: [
    AppComponent,
    StudentListComponent,
    MainPageComponent,
    RegisterPageComponent,
    ApplicantRegisterComponent,
    CompanyRegisterComponent,
    LoginPageComponent,
    ApplicantPageComponent,
    JobListElementComponent,
    CompanyPageComponent,
    ApplicationListElementComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    MatInputModule,
    MatIconModule,
    MatOptionModule,
    MatSelectModule,
    NgbModule,
    MatCheckboxModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    FormsModule,
    MatButtonModule,
    MatPaginatorModule,
    MatCardModule,
    MatExpansionModule,
    MatMenuModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass:InterceptorService,
      multi:true
    }],
  bootstrap: [AppComponent]
})
export class AppModule {
}
