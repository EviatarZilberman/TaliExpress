import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { LogoutResponse } from '../Classes/ApiResponse/LogoutResponse';
import { APIRequesterService } from '../Services/APIRequesterService';
import { TransferDataService } from '../Services/TransferDataService';
import { APIReturnKeys } from '../Enums/APIReturnKeys';
import { Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private logoutTrigger = new Subject<void>();
  logout$ = this.logoutTrigger.asObservable();

  constructor(private apiRequester: APIRequesterService, private router: Router, private dataTransferer: TransferDataService) {}

  triggerLogout(): void {
    this.logoutTrigger.next();
  }

  logout(): void {
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
