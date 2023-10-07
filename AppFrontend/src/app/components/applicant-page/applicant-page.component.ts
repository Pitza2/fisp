import { Component, Input, OnInit } from '@angular/core'
import { jobCompany } from '../../models/jobCompany'
import {CompanyJobService } from '../../services/company-job.service'
import { Applicant } from '../../models/Applicant.model'
import { GeneralService } from '../../services/general.service'
import { General } from '../../models/General.model'

@Component({
  selector: 'app-applicant-page',
  templateUrl: './applicant-page.component.html',
  styleUrls: ['./applicant-page.component.css']
})
export class ApplicantPageComponent implements OnInit{
joblistings:jobCompany[]=[];
  panelOpenState: boolean=false;


  constructor (private jobservice:CompanyJobService)  {

  }

  ngOnInit():void{
  this.jobservice.getJobListings().subscribe(data=>{
    this.joblistings=data;

  });
}
}
