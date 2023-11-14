import { TestBed } from '@angular/core/testing';

import { CaminhoneteService } from './caminhonete.service';

describe('CaminhoneteService', () => {
  let service: CaminhoneteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CaminhoneteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
