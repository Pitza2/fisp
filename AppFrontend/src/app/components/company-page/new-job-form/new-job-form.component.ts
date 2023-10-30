import { Component, Input, NgModule, OnChanges, SimpleChanges } from '@angular/core'
import { FormControl, FormGroup, ReactiveFormsModule, Validators, FormBuilder } from '@angular/forms'
import { CompanyJobService } from '../../../services/company-job.service'

@Component({
  selector: 'app-new-job-form',
  templateUrl: './new-job-form.component.html',
  styleUrls: ['./new-job-form.component.css']
})
export class NewJobFormComponent {
  constructor (private readonly fb: FormBuilder, private readonly companyJobService: CompanyJobService) {
  }
  jobForm = this.fb.group({
    jobTitle: ['', Validators.required],
    jobDescription: ['', Validators.required]
  })

  onSubmit () {
    this.companyJobService.AddJob({
      jobTitle: this.jobForm.value.jobTitle,
      jobDescription: this.jobForm.value.jobDescription
    }).subscribe(x => {
      this.jobForm.reset()
    })
  }
}
