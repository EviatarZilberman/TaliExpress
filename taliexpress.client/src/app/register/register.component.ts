import { Component } from '@angular/core';
import { BaseComponent } from '../BaseComponent/baseComponent.component';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { User } from '../../../Classes/Common/User';
import { APIReturnKeys } from '../../../Enums/APIReturnKeys';
import { RegistrationUser } from '../../../Classes/Common/RegistrationUser';

@Component({
  selector: 'register',
  standalone: false,
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})

export class RegisterComponent extends BaseComponent {
  override title: string = 'taliexpress.client.registerComponent';
  tempUser: RegistrationUser = new RegistrationUser();

  constructor(private apiRequester: APIRequesterService, protected override router: Router, protected httpClient: HttpClient) {
    super(httpClient, router);

  };

  registerUser(): void {
    this.apiRequester.APIReturn(this.tempUser, 'register', 'register', APIReturnKeys.Post);
  }
}
