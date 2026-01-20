import { Component } from '@angular/core';
import { BaseComponent } from '../BaseComponent/baseComponent.component';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { User } from '../../../Classes/Common/User';
import { APIReturnKeys } from '../../../Enums/APIReturnKeys';
import { LoginResponse } from '../../../Classes/ApiResponse/LoginResponse';
import { LoginRequest } from '../../../Classes/ApiRequests/LoginRequest';
import { KeepAliveDataService } from '../../../Services/KeepAliveDataService';
import { TransferDataService } from '../../../Services/TransferDataService';

@Component({
  selector: 'login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent extends BaseComponent {
  public user: User = new User();
  constructor(public dataTransferer: TransferDataService,
    protected apiRequester: APIRequesterService,
    protected override router: Router,
    protected httpClient: HttpClient,
    private keepData: KeepAliveDataService) {
    super(httpClient, router);
  };

  login(user: User): void {
    let loginRequest: LoginRequest = {
      email: user.email,
      password: user.password,
      data: null
    }
    const response: any = this.apiRequester.APIReturn(loginRequest, 'login', 'login', APIReturnKeys.Post).subscribe({
      next: (res: LoginResponse) => {
        this.keepData.user = res.data;
        this.router.navigate(['/']).then(() => {
          this.dataTransferer.processDataParameter(res.data);
        });
      },
      error: (err: any) => {
        console.error("Login failed", err);
      }
    });
  }
}
