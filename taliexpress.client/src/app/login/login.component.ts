import { Component } from '@angular/core';
import { BaseComponent } from '../BaseComponent/baseComponent.component';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { APIRequesterComponent } from '../apirequester/apirequester.component';
import { User } from '../../../Classes/User';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent extends BaseComponent {
  constructor(private apiRequester: APIRequesterComponent, protected override router: Router, protected httpClient: HttpClient) {
    super(httpClient, router);
  };

  login(userName: string, password: string): void | string | undefined {
    const user: User = {
      email: userName,
      password: password,
      firstName: '',
      lastName: '',
      phoneNumber: '',
      tempPassword: ''
    }
    const answer: string = this.apiRequester.CallAPI(user, 'users', 'register');
    if (answer === 'err') {
      return alert('Error calling API');
    }
    else {
      return answer;
    }
    return undefined;
    //  .subscribe({
    //  next: (response) => {
    //    console.log('Response from API:', response);
    //    alert(response.message);
    //  },
    //  error: (err) => {
    //    console.error('Error from API:', err);
    //    alert('Registration failed');
    //  }
    //});
  }
}
