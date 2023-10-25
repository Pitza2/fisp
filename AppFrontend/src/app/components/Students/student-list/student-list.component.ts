import { Component, OnInit } from '@angular/core'
import { Student } from '../../../models/student.model'
import { StudentsService } from '../../../services/students.service'
import { Subscription } from 'rxjs'

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {
  students: Student[] = []

  constructor (private studentservice: StudentsService) {
    this.students = [{
      id: 1,
      name: 'dsadad',
      faculty: 'dasdsa'
    }]
  }

  ngOnInit (): void {

    this.studentservice.getAllStudents().subscribe(data => {
      this.students = data
    })

  }
}
