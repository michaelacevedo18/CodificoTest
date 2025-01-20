import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders,HttpParams  } from '@angular/common/http';
import { UrlConfig } from '../../Utilities/consts';
import { Observable } from 'rxjs';
import { ApiResponse } from '../Models/ApiResponse';
@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  private apiUrlTotalOrders: string = UrlConfig.URL_CUSTOMER_PREDICTIONS;
  private apiUrlCustomerOrders: string = UrlConfig.URL_CUSTOMER_ORDERS;
  private apiUrlSaveOrder: string = UrlConfig.URL_saveOrder;
  constructor(private http: HttpClient) { }

  getTotalOrdersPredictions(Name:string): Observable<ApiResponse<any[]>> {
    
    const url = `${this.apiUrlTotalOrders}?Name=${Name || ''}`; 
    return this.http.get<ApiResponse<any[]>>(url);
  }
  getOrdersByCustomerId(customerId:number): Observable<ApiResponse<any[]>> {
    const url = `${this.apiUrlCustomerOrders}?customerId=${customerId}`;
    return this.http.get<ApiResponse<any>>(url); 
  }
  saveOrder(data: any): Observable<ApiResponse<any>> {
    const url = this.apiUrlSaveOrder; 
    const payload = {    
      orderId  :0,
      employeeId: data.employeeId,
      shipperId: data.shipperId,
      customerId: data.customerId,
      orderDate: data.orderDate,
      requiredDate: data.requiredDate,
      shippedDate: data.shippedDate,
      freight: data.freight,
      orderDetails: [
        {
          productId: data.productId,
          unitPrice: data.unitPrice,
          quantity: data.quantity,
          discount: data.discount
        }
      ]
      
  };
    return this.http.post<ApiResponse<any>>(url, payload); // Enviar data en el cuerpo
  }
}
