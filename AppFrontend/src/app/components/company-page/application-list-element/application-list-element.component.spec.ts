import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationListElementComponent } from './application-list-element.component';

describe('ApplicationListElementComponent', () => {
  let component: ApplicationListElementComponent;
  let fixture: ComponentFixture<ApplicationListElementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplicationListElementComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApplicationListElementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
