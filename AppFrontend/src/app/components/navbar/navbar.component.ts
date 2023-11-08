import { ChangeDetectionStrategy, Component, Injectable, OnInit } from '@angular/core'
import { settings } from 'eslint-config-standard-with-typescript'
import { Router } from '@angular/router'
import { GeneralService } from '../../services/general.service'
import { General } from '../../models/General.model'


@Injectable({
  providedIn: 'root'
})
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit{
  buttonList: { text: string, href: string }[] = [
    { text: 'login', href: 'login' },
  ]
  constructor (private readonly router: Router, private readonly general: GeneralService) {
  }
  public show = true;
  addButton(oj: { text: string, href: string } ):void {
    this.buttonList.push(oj)
    console.log(this.buttonList)
  }

  ngOnInit () {

    this.general.GetUserData().subscribe(data=>{

      if (data.isApplicant){
        this.addButton({ text: 'home', href: 'home/applicant/:username' })
        this.addButton({ text: 'applications', href: 'applications/:username' })
      }else {
        this.addButton({ text: 'home', href: 'home/company/:username' })
      }
    })

  }
}
