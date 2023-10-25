import { Component, OnInit } from '@angular/core'
import { ApplicantJobService } from '../../services/applicant-job.service'
import { ApplicantsService } from '../../services/applicants.service'
import { CompanyJobService } from '../../services/company-job.service'
import { ApplicantJob } from '../../models/ApplicantJob.model'

@Component({
  selector: 'app-company-page',
  templateUrl: './company-page.component.html',
  styleUrls: ['./company-page.component.css']
})
export class CompanyPageComponent implements OnInit {

  applications: ApplicantJob[] = []

  constructor (private jobService: ApplicantJobService, private apservice: ApplicantsService, private compservice: CompanyJobService) {
  }

  ngOnInit (): void {
    this.jobService.getApplicationList().subscribe(data => {
      this.applications = data
    })
  }
}
