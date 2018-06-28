import { Customer } from './../../models/customer';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  customer: Customer = {
    customerId: 0,
    name: '',
    email: '',
    address: '',
    aadharNo: '',
    user: { userId: 0, userName: '', password: '', mobileNo: '', role: 'customer' }
  };
  constructor(
    private router: Router,
    private http: HttpClient,
    private toastr: ToastrService
  ) {}

  ngOnInit() {}
  onSubmit() {
    this.http.post('/api/customers', this.customer).subscribe(
      (data) => {
        console.log(data);
        this.toastr.success('Registration successful');
        setTimeout((router: Router) => {
          this.router.navigate(['/login']);
        }, 5000);
      },
      (error) => {
        console.log(error);
        this.toastr.error('Failed to Register', 'Registration Failed');
      }
    );
  }
}
