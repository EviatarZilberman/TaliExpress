import { BaseApiResponse } from "../ApiResponse/BaseApiResponse";
import { LoginResponse } from "../ApiResponse/LoginResponse";
import { Observable } from 'rxjs';
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})

export class ComponentSubscriber {
  loginResponse!: LoginResponse;
  public subscribeData<LoginResponse>(data: Observable<LoginResponse>) : any {
    return data.subscribe({
      next: (response: any) => {
        this.loginResponse = response;
      }
    });
    return this.loginResponse;
  }
}
