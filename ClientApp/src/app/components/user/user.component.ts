import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Customer } from '../../models/customer';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  customers: Customer[];
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.http.get<Customer[]>('/api/users').subscribe((cList) => {
      console.log(cList);
      this.customers = cList;
    });
  }
}
