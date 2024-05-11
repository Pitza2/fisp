import { Component, OnInit } from '@angular/core'
import { ApplicantJobService } from '../../../services/applicant-job.service'
import { ApplicantJob } from '../../../models/ApplicantJob.model'

@Component({
  selector: 'app-applications-view',
  templateUrl: './applications-view.component.html',
  styleUrls: ['./applications-view.component.css']
})
export class ApplicationsViewComponent implements OnInit{

  applications: ApplicantJob[] = []


  constructor (private jobService: ApplicantJobService) {
  }

  ngOnInit (): void {
    this.jobService.getApplicationList().subscribe(data => {
      this.applications = data
    })
  }
}
