import { Injectable } from '@angular/core';
import { UrlConfig } from '../../Utilities/consts';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../Models/ApiResponse';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrlProducts: string = UrlConfig.URL_Products;
  
  constructor(private http: HttpClient) { }

  getProducts(): Observable<ApiResponse<any[]>> {
    return this.http.get<ApiResponse<any[]>>(this.apiUrlProducts);
  }
  
}
