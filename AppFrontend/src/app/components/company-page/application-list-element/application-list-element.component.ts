import { Component, Input, OnInit, ViewChild } from '@angular/core'
import { ApplicantJob } from '../../../models/ApplicantJob.model'
import { ApplicantsService } from '../../../services/applicants.service'
import { CompanyService } from '../../../services/company.service'
import { Applicant } from '../../../models/Applicant.model'
import { Company } from '../../../models/Company.model'
import { jobCompany } from '../../../models/jobCompany'
import { CompanyJobService } from '../../../services/company-job.service'
import { catchError, throwError } from 'rxjs'
import { MatMenuTrigger } from '@angular/material/menu'
import { ApplicantJobService } from '../../../services/applicant-job.service'

@Component({
  selector: 'app-application-list-element',
  templateUrl: './application-list-element.component.html',
  styleUrls: ['./application-list-element.component.css']
})
export class ApplicationListElementComponent implements OnInit {
  @Input() application: ApplicantJob = {
    applicantRefid: -1,
    company_jobRefid: -1,
    status: 0,
    id: 0
  }

  applicant: Applicant = {
    name: '',
    linkedin: '',
    password: ''
  }

  company: Company = {
    name: '',
    phone: '',
    password: ''
  }

  companyJob: jobCompany = {
    id: 0,
    companyRefid: 0,
    companyName: '',
    jobTitle: '',
    jobDescription: ''
  }

  statusString = 'pending'

  constructor (
    private applicantService: ApplicantsService,
    private companyService: CompanyService,
    private companyJobService: CompanyJobService,
    private jobService: ApplicantJobService) {
  }

  statuses: string[] = ['pending', 'accepted', 'rejected']

  ngOnInit (): void {

    this.applicantService.getById(this.application.applicantRefid).subscribe(data => {
      this.applicant = data
    })
    this.companyJobService.getById(this.application.company_jobRefid).subscribe(data => {
      this.companyJob = data
    })

    console.log(this.application)
    switch (this.application.status) {
      case 0: {
        this.statusString = 'pending'
        break
      }
      case 1: {
        this.statusString = 'accepted'
        break
      }
      default: {
        this.statusString = 'rejected'
        break
      }
    }
  }
  updateApplication(): void{
    this.jobService.updateStatus({id: this.application.id,status:this.statusString})
  }
}
