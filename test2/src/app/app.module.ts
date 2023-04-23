import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { StudentListComponent } from './components/Students/student-list/student-list.component';
import { AppRoutingModule } from './app-routing.module';
@NgModule({
  declarations: [
    AppComponent,
    StudentListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
