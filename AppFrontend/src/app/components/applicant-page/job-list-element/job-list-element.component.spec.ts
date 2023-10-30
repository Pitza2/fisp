import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobListElementComponent } from './job-list-element.component';

describe('JobListElementComponent', () => {
  let component: JobListElementComponent;
  let fixture: ComponentFixture<JobListElementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JobListElementComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JobListElementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
