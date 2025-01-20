import { Injectable } from '@angular/core';
import { UrlConfig } from '../../Utilities/consts';
import { HttpClient } from '@angular/common/http';
import { ApiResponse } from '../Models/ApiResponse';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShipperService {
  private apiUrlShippers: string = UrlConfig.URL_Shippers;  
  constructor(private http: HttpClient) { }
  getShippers(): Observable<ApiResponse<any[]>> {
    return this.http.get<ApiResponse<any[]>>(this.apiUrlShippers);
  }
}
