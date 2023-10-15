import { TestBed } from '@angular/core/testing';

import { ApplicantJobService } from './applicant-job.service';

describe('ApplicantJobService', () => {
  let service: ApplicantJobService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApplicantJobService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
