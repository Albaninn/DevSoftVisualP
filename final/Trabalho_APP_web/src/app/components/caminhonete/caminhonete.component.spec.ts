import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CaminhoneteComponent } from './caminhonete.component';

describe('CaminhoneteComponent', () => {
  let component: CaminhoneteComponent;
  let fixture: ComponentFixture<CaminhoneteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CaminhoneteComponent]
    });
    fixture = TestBed.createComponent(CaminhoneteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
