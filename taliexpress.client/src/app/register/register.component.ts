import { Component } from '@angular/core';
import { BaseComponent } from '../BaseComponent/baseComponent.component';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { User } from '../../../Classes/User';
import { APIReturnKeys } from '../../../Enums/APIReturnKeys';

@Component({
  selector: 'register',
  standalone: false,
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})

export class RegisterComponent extends BaseComponent {
  override title: string = 'taliexpress.client.registerComponent';
  user: User = new User();

  constructor(private apiRequester: APIRequesterService, protected override router: Router, protected httpClient: HttpClient) {
    super(httpClient, router);

  };

  registerUser(user: User): void | string {
    if (user === null) return 'User data is null';
    return this.apiRequester.APIReturn(user, 'users', 'register', APIReturnKeys.Post);
  }
}
