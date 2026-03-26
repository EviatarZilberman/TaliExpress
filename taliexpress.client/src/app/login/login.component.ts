import { Component } from '@angular/core';
import { BaseComponent } from '../BaseComponent/baseComponent.component';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { APIReturnKeys } from '../../../Enums/APIReturnKeys';
import { LoginResponse } from '../../../Classes/ApiResponse/LoginResponse';
import { LoginRequest } from '../../../Classes/ApiRequests/LoginRequest';
import { TransferDataService } from '../../../Services/TransferDataService';


@Component({
  selector: 'login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent extends BaseComponent /*implements OnInit*/ {
  public loginRequest: LoginRequest = new LoginRequest();
  constructor(public dataTransferer: TransferDataService,
    protected apiRequester: APIRequesterService,
    protected override router: Router,
    protected httpClient: HttpClient) {
    super(httpClient, router);
  };

/*  ngOnInit(): void {
    this.authenticationService.logout$.subscribe(() => {
    this.logout(); // your existing function
  });
  }*/

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
}
