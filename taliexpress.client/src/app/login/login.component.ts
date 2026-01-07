import { Component } from '@angular/core';
import { BaseComponent } from '../BaseComponent/baseComponent.component';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { User } from '../../../Classes/Common/User';
import { APIReturnKeys } from '../../../Enums/APIReturnKeys';
//import { URLParametersCreator } from '../../../Classes/URLParametersCreator';
import { LoginResponse } from '../../../Classes/ApiResponse/LoginResponse';
import { Observable } from 'rxjs';
import { LoginRequest } from '../../../Classes/ApiRequests/LoginRequest';

@Component({
  selector: 'login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent extends BaseComponent {
  public user: User = new User();
  constructor(protected apiRequester: APIRequesterService, protected override router: Router, protected httpClient: HttpClient) {
    super(httpClient, router);
  };

  login(user: User): void {
    let loginRequest: LoginRequest = {
      email: user.email,
      password: user.password
    }
    const response: any = this.apiRequester.login(loginRequest).subscribe({
      next: (res: LoginResponse) => {
        console.log(res.code);
        console.log(res.message);
      },
      error: err => {
        console.error("Login failed", err);
      }
    });
  }
}
