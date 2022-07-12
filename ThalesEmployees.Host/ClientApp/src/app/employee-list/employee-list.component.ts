import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { EmployeeService } from '../Services/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  valueToSearch:string = '';
  dataSource: Employee[] = [];
  displayedColumns: string[] = ['id', 'name', 'salary', 'age', 'annualSalary'];
  constructor(private employeesService: EmployeeService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getAllEmployees();
  }

  verifyNumber()
  {
    return Number.isNaN(Number(this.valueToSearch))
  }

  getEmployee(){

    if(this.valueToSearch)
    {
      this.employeesService.getById(Number.parseInt(this.valueToSearch)).subscribe({
        next: (res) => {
          this.dataSource = [];
          this.dataSource.push(res);
        },
        error: (e) => this.toastr.info(`${e.error.Exception}. Please try again.`)
      });
      return;
    }
    this.getAllEmployees();
  }

  getAllEmployees()
  {
    this.employeesService.getAll().subscribe({
      next: (res) => this.dataSource = res,
      error: (e) => this.toastr.info(`${e.error.Exception}. Please try again.`)
    });
  }

}
export class Employee
{
  id!: number;
  name!:string;
  salary!:number;
  age!:number;
  profileImage!:string;
  AnnualSalary!:number;
}
