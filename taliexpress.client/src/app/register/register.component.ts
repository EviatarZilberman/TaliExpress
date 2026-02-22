import { Component } from '@angular/core';
import { BaseComponent } from '../BaseComponent/baseComponent.component';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { APIReturnKeys } from '../../../Enums/APIReturnKeys';
import { ScreenMessage } from '../../../Classes/Common/ScreenMessage';
import { RegistrationUser } from '../../../Classes/Common/RegistrationUser';
import { RegisterResponse } from '../../../Classes/ApiResponse/RegisterResponse';
import { TransferDataService } from '../../../Services/TransferDataService';

@Component({
  selector: 'register',
  standalone: false,
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})

export class RegisterComponent extends BaseComponent {
  tempUser: RegistrationUser = new RegistrationUser();

  constructor(private apiRequester: APIRequesterService, protected override router: Router, protected httpClient: HttpClient, public messageService: TransferDataService) {
    super(httpClient, router);

  };

  registerUser(): void {
    this.apiRequester.APIReturn(this.tempUser, 'register', 'register', APIReturnKeys.Post).subscribe({
      next: (res: RegisterResponse) => {
        if (res.code === 0) {
          this.screenMessage = {
            title: 'Registration successful',
            message: 'Your account has been created successfully. You can now log in and start shopping!',
            color: 'green'
          };
          this.router.navigate(['/screen-message']).then(() => {
            this.messageService.processDataParameter(this.screenMessage);
          });;
        }
      }, error: (err: any) => {
        console.error("Register failed", err);
      }
    });
  }
}
