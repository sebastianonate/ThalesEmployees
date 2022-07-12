import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../employee-list/employee-list.component';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getAll():Observable<any>
  {
    return this.httpClient.get(`${this.baseUrl}api/employees`);
  }

  getById(id:number):Observable<any>
  {
    return this.httpClient.get(`${this.baseUrl}api/employees/${id}`);
  }
}
