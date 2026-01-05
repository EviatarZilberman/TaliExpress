import { Component } from '@angular/core';
import { BaseComponent } from '../BaseComponent/baseComponent.component';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { User } from '../../../Classes/Common/User';
import { APIReturnKeys } from '../../../Enums/APIReturnKeys';
import { RegisreationUser } from '../../../Classes/Common/RegisreationUser';

@Component({
  selector: 'register',
  standalone: false,
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})

export class RegisterComponent extends BaseComponent {
  override title: string = 'taliexpress.client.registerComponent';
  tempUser!: RegisreationUser;

  constructor(private apiRequester: APIRequesterService, protected override router: Router, protected httpClient: HttpClient) {
    super(httpClient, router);

  };

  registerUser(tempUser: RegisreationUser): void {
    //if (user === null) return 'User data is null';
    this.apiRequester.APIReturn(tempUser, 'register', 'register', APIReturnKeys.Post);
  }
}
