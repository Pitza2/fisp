import { Component, Input, OnInit } from '@angular/core'
import { jobCompany } from '../../models/jobCompany'
import { HttpClient } from '@angular/common/http'
import { CompanyJobService } from '../../services/company-job.service'
import { Applicant } from '../../models/Applicant.model'
import { General } from '../../models/General.model'
import { GeneralService } from '../../services/general.service'

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

  constructor (private jobservice: CompanyJobService, private general: GeneralService) {
  }

  apply () {
    this.general.GetUserData().subscribe(data => {
      this.jobservice.apply({
        company_jobRefid: this.job.id,
        applicantRefid: data.id
      }).subscribe(x => {
        console.log('ok')
      })
    })
  }
}
