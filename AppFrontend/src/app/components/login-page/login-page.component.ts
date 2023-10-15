import { Component } from '@angular/core'
import { FormControl } from '@angular/forms'
import { CompanyService } from '../../services/company.service'
import { GeneralService } from '../../services/general.service'
import { catchError, throwError } from 'rxjs'
import { General } from '../../models/General.model'
import { ApplicantPageComponent } from '../applicant-page/applicant-page.component'
import { Router } from '@angular/router'

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent {
  username: FormControl = new FormControl('')
  pass: FormControl = new FormControl('')

  constructor (private generalService: GeneralService, private router: Router) {
  }

  LogIn () {

    this.generalService.TryLogin(this.username.value, this.pass.value).pipe(catchError(err => {
      const errcode = err.status
      if (errcode == 404) {
        alert('user not found')
      } else if (errcode == 400) {
        alert('wrong password')
      } else {
        alert('unknown error')
      }
      return throwError(err)
    })).subscribe(data => {
      localStorage.setItem('jwt', data)
      void this.router.navigate(['home'])
    })
  }
}
