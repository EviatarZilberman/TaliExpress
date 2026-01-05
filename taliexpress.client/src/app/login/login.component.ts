import { Component } from '@angular/core';
import { BaseComponent } from '../BaseComponent/baseComponent.component';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { User } from '../../../Classes/Common/User';
import { APIReturnKeys } from '../../../Enums/APIReturnKeys';
import { ComponentSubscriber } from '../../../Classes/Common/ComponentSubscriber';
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
  public componentSubscriber: ComponentSubscriber = new ComponentSubscriber();
  constructor(protected apiRequester: APIRequesterService, protected override router: Router, protected httpClient: HttpClient, componentSubscriber: ComponentSubscriber) {
    super(httpClient, router);
    this.componentSubscriber = componentSubscriber;
  };

  login(user: User): void {
    //let map = new Map();
    //map.set('email', user.email);
    //map.set('password', user.password);
    //let params = URLParametersCreator.createURLParametersFromObject(map);
    //const response: Observable<LoginResponse> = this.apiRequester.login(params);
    //const finalResponse: LoginResponse = this.componentSubscriber.subscribeData<LoginResponse>(response);
    //console.log(finalResponse.code);
    //console.log(finalResponse.message);
    //return finalResponse;
    //const response: any = this.apiRequester.APIReturn(params, 'login', 'login', APIReturnKeys.Get);
    let loginRequest: LoginRequest = {
      email: user.email,
      password: user.password
    }
    const response: any = this.apiRequester.APIReturn(loginRequest, 'login', 'login', APIReturnKeys.Post);
  }
}
