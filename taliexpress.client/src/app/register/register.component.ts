import { Component } from '@angular/core';
import { BaseComponent } from '../BaseComponent/baseComponent.component';
import { APIRequesterComponent } from '../apirequester/apirequester.component';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { User } from '../../../Classes/User';

@Component({
  selector: 'app-register',
  standalone: false,
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})

export class RegisterComponent extends BaseComponent {
  override title: string = 'taliexpress.client.registerComponent';
  user: User = new User();

  constructor(private apiRequester: APIRequesterComponent, protected override router: Router, protected httpClient: HttpClient) {
    super(httpClient, router);

  };

  registerUser(user: User): void | string {
    if (user === null) return 'User data is null';
    this.apiRequester.CallAPI(user, 'users', 'register').subscribe({
      next: (response) => {
        console.log('Login success:', response);
        // handle login success (save token, redirect, etc.)
      },
      error: (err) => {
        console.error('Login failed:', err);
      }
    });
    return;
  }
}
