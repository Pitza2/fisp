import { Component, OnInit } from '@angular/core'
import { ApplicantJobService } from '../../../services/applicant-job.service'

@Component({
  selector: 'app-applications-view',
  templateUrl: './applications-view.component.html',
  styleUrls: ['./applications-view.component.css']
})
export class ApplicationsViewComponent implements OnInit{

  constructor (private applicationsService: ApplicantJobService) {
  }


  ngOnInit () {

  }
}
