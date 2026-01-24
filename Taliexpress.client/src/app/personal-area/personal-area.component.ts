import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { KeepAliveDataService } from '../../../Services/KeepAliveDataService';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { User } from '../../../Classes/Common/User';
import { PersonalAreaUpdateRequest } from '../../../Classes/ApiRequests/PersonalAreaUpdateRequest';
import { PersonalAreaUpdateResponse } from '../../../Classes/ApiResponse/PersonalAreaUpdateResponse';
import { APIReturnKeys } from '../../../Enums/APIReturnKeys';
import { BaseComponent } from '../BaseComponent/baseComponent.component';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'personal-area',
  standalone: false,
  templateUrl: './personal-area.component.html',
  styleUrl: './personal-area.component.css',
})
export class PersonalAreaComponent extends BaseComponent implements OnInit {
  user!: User;

  constructor(private keepData: KeepAliveDataService,
    private apiRequester: APIRequesterService,
    private cd: ChangeDetectorRef,
    override http: HttpClient,
    override router: Router)
  {
    super(http, router);
  }

  ngOnInit(): void {
    if (this.keepData.user) {
      this.user = this.keepData.user;
    }
    else {
      this.user = new User();
    }
  }

  updateUser(): void {
    if (!this.user && !this.keepData.user) return;

    let request: PersonalAreaUpdateRequest = {
      firstName: this.user.firstName,
      lastName: this.user.lastName,
      phoneNumber: this.user.phoneNumber,
      originEmail: this.keepData.user.email
    }
    const response: any = this.apiRequester.APIReturn(request, 'Accounts', 'UpdateAccount', APIReturnKeys.Post)
      .subscribe({
        next: (res: PersonalAreaUpdateResponse) => {
          if (res.code === 0) {
            this.user.firstName = request.firstName;
            this.user.lastName = request.lastName;
            this.user.phoneNumber = request.phoneNumber;
            this.keepData.user = this.user;
          }
        }
      }).then(() => {
        this.router.navigate(['/'])
      });
  }

  openStore(): void {

  }
}
