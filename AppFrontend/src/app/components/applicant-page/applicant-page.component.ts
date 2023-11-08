import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core'
import { jobCompany } from '../../models/jobCompany'
import { CompanyJobService } from '../../services/company-job.service'
import { NavbarComponent } from '../navbar/navbar.component'
import { GeneralService } from '../../services/general.service'
@Component({
  selector: 'app-applicant-page',
  templateUrl: './applicant-page.component.html',
  styleUrls: ['./applicant-page.component.css']
})
export class ApplicantPageComponent implements OnInit {
  joblistings: jobCompany[] = []
  panelOpenState: boolean = false
  @ViewChild('childRef') navbar: NavbarComponent;


  constructor (private jobservice: CompanyJobService, private generalService: GeneralService) {

  }

  ngOnInit (): void {
    this.jobservice.getJobListings().subscribe(data => {
      this.joblistings = data
    })
  }
}
