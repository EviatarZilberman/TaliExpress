import { Component } from '@angular/core';
import { BaseComponent } from '../BaseComponent/baseComponent.component';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { User } from '../../../Classes/Common/User';
import { APIReturnKeys } from '../../../Enums/APIReturnKeys';
import { LoginResponse } from '../../../Classes/ApiResponse/LoginResponse';
import { LogoutResponse } from '../../../Classes/ApiResponse/LogoutResponse';
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
  public loginRequest: LoginRequest = new LoginRequest();
  constructor(public dataTransferer: TransferDataService,
    protected apiRequester: APIRequesterService,
    protected override router: Router,
    protected httpClient: HttpClient) {
    super(httpClient, router);
  };

  login(loginRequest: LoginRequest): void {
    const response: any = this.apiRequester.APIReturn(this.loginRequest, 'login', 'login', APIReturnKeys.Post).subscribe({
      next: (res: LoginResponse) => {
        if (res.code === 0) {
          this.router.navigate(['/']).then(() => {
            this.dataTransferer.processDataParameter(true);
          });
        }
      },
      error: (err: any) => {
        console.error("Login failed", err);
      }
    });
  }

  logout(): void{
    const response: any = this.apiRequester.APIReturn(null, 'login', 'logout', APIReturnKeys.Get).subscribe({
      next: (res: LogoutResponse) => {
        if (res.code === 0) {
          this.router.navigate(['/']).then(() => {
            this.dataTransferer.processDataParameter(false);
          });
        }
      },
      error: (err: any) => {
        console.error("Logout failed", err);
      }
    });
  }
}
