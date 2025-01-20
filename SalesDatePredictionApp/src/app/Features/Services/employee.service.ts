import { Injectable } from '@angular/core';
import { UrlConfig } from '../../Utilities/consts';
import { HttpClient } from '@angular/common/http';
import { ApiResponse } from '../Models/ApiResponse';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
private apiUrlEmployes: string = UrlConfig.URL_Employees;  
  constructor(private http: HttpClient) { }
  getEmployees(): Observable<ApiResponse<any[]>> {
    return this.http.get<ApiResponse<any[]>>(this.apiUrlEmployes);
  }
}
