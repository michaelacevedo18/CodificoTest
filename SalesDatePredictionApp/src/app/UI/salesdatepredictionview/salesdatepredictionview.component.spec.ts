import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalesdatepredictionviewComponent } from './salesdatepredictionview.component';

describe('SalesdatepredictionviewComponent', () => {
  let component: SalesdatepredictionviewComponent;
  let fixture: ComponentFixture<SalesdatepredictionviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SalesdatepredictionviewComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SalesdatepredictionviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
