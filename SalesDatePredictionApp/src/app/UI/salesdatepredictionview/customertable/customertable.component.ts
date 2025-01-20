import { CommonModule } from '@angular/common';
import { Component, inject, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { Customer } from '../../../Features/Models/customer';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { OrdersService } from '../../../Features/Services/orders.service';
import { ApiResponse } from '../../../Features/Models/ApiResponse';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { OrdersviewComponent } from '../../ordersview/ordersview.component';
import { MatDialog } from '@angular/material/dialog';
import { OrderformComponent } from '../../orderform/orderform.component';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-customertable',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    FormsModule
  ],
  templateUrl: './customertable.component.html',
  styleUrls: ['./customertable.component.css']
})
export class CustomertableComponent implements OnInit, AfterViewInit {
  customers: Customer[] = [];
  valueSearch: string = '';
  displayedColumns: string[] = ['customerId', 'name', 'lastOrderDate', 'nextPredictedOrderDate', 'actions'];

  dataSource: MatTableDataSource<Customer> = new MatTableDataSource<Customer>(this.customers);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  readonly dialog = inject(MatDialog);

  constructor(private dataService: OrdersService) {}

  ngOnInit() {
    this.getPredictions();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  
  getPredictions() {
    this.dataService.getTotalOrdersPredictions(this.valueSearch).subscribe(
      (response: ApiResponse<Customer[]>) => {
        if (response.result) {
          this.dataSource.data = response.result;
        } else {
          this.dataSource.data = [];
          console.log('La respuesta no contiene datos, ingrese datos en el backend');
        }
      },
      (error) => {
        console.error('Error al traer data', error);
      }
    );
  }
  
  searchCustomer() {
    this.getPredictions();
  }

  
  openModalOrders(customerId: number) {
    const dialogRef = this.dialog.open(OrdersviewComponent, {
      data: customerId,
      maxWidth: 'none',
      maxHeight: 'none',
      panelClass: 'full-screen-modal'
    });
  }
  
  openModalNewOrder(customerId: number) {
    const dialogRef = this.dialog.open(OrderformComponent, {
      data: customerId,
      maxWidth: 'none',
      maxHeight: 'none',
      panelClass: 'full-screen-modal'
    });
  }
}
