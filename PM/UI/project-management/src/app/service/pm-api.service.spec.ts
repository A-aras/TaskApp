import { TestBed, inject } from '@angular/core/testing';

import { PmApiService } from './pm-api.service';

describe('PmApiService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PmApiService]
    });
  });

  it('should be created', inject([PmApiService], (service: PmApiService) => {
    expect(service).toBeTruthy();
  }));
});
