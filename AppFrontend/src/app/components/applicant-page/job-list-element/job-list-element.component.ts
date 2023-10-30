import { Component, Input, OnInit } from '@angular/core'
import { jobCompany } from '../../../models/jobCompany'
import { HttpClient } from '@angular/common/http'
import { CompanyJobService } from '../../../services/company-job.service'
import { Applicant } from '../../../models/Applicant.model'
import { General } from '../../../models/General.model'
import { GeneralService } from '../../../services/general.service'
import { catchError, throwError } from 'rxjs'
import { ApplicantJobService } from '../../../services/applicant-job.service'

@Component({
  selector: 'app-job-list-element',
  templateUrl: './job-list-element.component.html',
  styleUrls: ['./job-list-element.component.css']
})
export class JobListElementComponent {
  @Input() job: jobCompany = {
    jobDescription: '',
    jobTitle: '',
    companyName: '',
    id: 0,
    companyRefid: 0
  }

  user: General = {
    username: '',
    extra: '',
    isApplicant: true,
    id: 0
  }

  constructor (private jobService: ApplicantJobService, private general: GeneralService) {
  }

  apply () {
    this.general.GetUserData().subscribe(data => {
      this.jobService.apply({
        company_jobRefid: this.job.id,
        applicantRefid: data.id,
        status: 0,
        id: -1
      }).pipe(catchError(err => {
        const errcode = err.status
        if (errcode == 400) {
          alert('Deja ai aplicat la acest job')
        }
        return throwError(err)
      })).subscribe(x => {

        window.alert('ai aplicat cu succes')
      })
    })
  }
}
