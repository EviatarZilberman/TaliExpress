import { Component } from '@angular/core';
import { BaseComponent } from '../BaseComponent/baseComponent.component';
import { HttpClient } from '@angular/common/http';
import { HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { User } from '../../../Classes/User';
import { APIReturnKeys } from '../../../Enums/APIReturnKeys';
import { URLParametersCreator } from '../../../Classes/URLParametersCreator';

@Component({
  selector: 'login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent extends BaseComponent {
  public user: User = new User();
  constructor(private apiRequester: APIRequesterService, protected override router: Router, protected httpClient: HttpClient) {
    super(httpClient, router);
  };

  login(user: User): void | string | undefined | User {
    let params = new HttpParams()
      .set('email', user.email)
      .set('password', user.password);
    //let map = new Map();
    //map.set('email', user.email);
    //map.set('password', user.password);
    //let params = URLParametersCreator.createURLParametersFromObject(map);
    const response: any = this.apiRequester.APIReturn(params, 'login', 'login', APIReturnKeys.Get);
    return response;
  }
}
