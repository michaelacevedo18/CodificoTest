import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderformComponent } from './orderform.component';

describe('OrderformComponent', () => {
  let component: OrderformComponent;
  let fixture: ComponentFixture<OrderformComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OrderformComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
