import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { OrdersService } from '../../Features/Services/orders.service';
import { Order } from '../../Features/Models/order';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { ApiResponse } from '../../Features/Models/ApiResponse';

@Component({
  selector: 'app-ordersview',
  standalone: true,
  
   imports: [CommonModule, MatTableModule, MatButtonModule,MatPaginatorModule, MatSortModule],
  templateUrl: './ordersview.component.html',
  styleUrl: './ordersview.component.css'
})
export class OrdersviewComponent implements OnInit{    
    orders: Order[] = [];    
    dataSource: MatTableDataSource<Order> = new MatTableDataSource<Order>(this.orders);
    displayedColumns: string[] = ['orderId', 'requiredDate', 'shippedDate', 'shipperName', 'shipperAddress', 'shipperCity'];

    @ViewChild(MatPaginator) paginator!: MatPaginator;
      @ViewChild(MatSort) sort!: MatSort;
  constructor(@Inject(MAT_DIALOG_DATA) public data: any, 
  
  private dialogRef: MatDialogRef<OrdersviewComponent>,
  private dataService: OrdersService
  ){
   
 }
  ngOnInit(): void {
    this.getOrdersCustomer(this.data)
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  
  
   
  getOrdersCustomer(customerId:number) {
      this.dataService.getOrdersByCustomerId(customerId).subscribe(
        (response: ApiResponse<Order[]>) => {
          if (response.result) {
            this.dataSource.data = response.result;
            console.log(this.dataSource.data )
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
    
}
