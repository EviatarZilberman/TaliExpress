import { Component } from '@angular/core';
import { BaseComponent } from '../BaseComponent/baseComponent.component';
import { HttpClient } from '@angular/common/http';
import { HttpParams } from '@angular/common/http';
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
  public user: User = new User();
  constructor(private apiRequester: APIRequesterComponent, protected override router: Router, protected httpClient: HttpClient) {
    super(httpClient, router);
  };

  login(user: User): void | string | undefined | User {

    let params = new HttpParams()
      .set('email', user.email)
      .set('password', user.password);
    const response: any = this.apiRequester.APIReturn(params, 'users', 'login', 'g');
    return response;
  }
}
