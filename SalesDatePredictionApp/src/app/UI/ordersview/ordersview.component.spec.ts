import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrdersviewComponent } from './ordersview.component';

describe('OrdersviewComponent', () => {
  let component: OrdersviewComponent;
  let fixture: ComponentFixture<OrdersviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OrdersviewComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrdersviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
