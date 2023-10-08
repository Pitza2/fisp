import { Component, Input, OnInit } from '@angular/core'
import { jobCompany } from '../../models/jobCompany'
import { HttpClient } from '@angular/common/http'
import { CompanyJobService } from '../../services/company-job.service'
import { Applicant } from '../../models/Applicant.model'

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
    companyRefId: 0
  }

  @Input() applicant: Applicant = {
    linkedin: '',
    name: '',
    password: ''
  }

  constructor (private jobservice: CompanyJobService) {
  }

  apply () {
    //this.jobservice.apply()
  }
}
