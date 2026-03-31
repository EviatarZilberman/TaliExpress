import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../BaseComponent/baseComponent.component';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { APIRequesterService } from '../../../../Services/APIRequesterService';
import { TransferDataService } from '../../../../Services/TransferDataService';
import { KeepAliveDataService } from '../../../../Services/KeepAliveDataService';
import { AuthenticationService } from '../../../../Services/AuthenticationService';
import { APIReturnKeys } from '../../../../Enums/APIReturnKeys';
import { IsConnectedResponse } from '../../../../Classes/ApiResponse/IsConnectedResponse';

@Component({
  selector: 'upper-nav-bar',
  templateUrl: './upper-nav-bar.component.html',
  styleUrl: './upper-nav-bar.component.css',
  standalone: false
})
export class UpperNavBarComponent extends BaseComponent implements OnInit {
  public isConnected: boolean = false;

  constructor(private apiRequester: APIRequesterService,
    protected override router: Router,
    private cd: ChangeDetectorRef,
    protected httpClient: HttpClient,
    private dataService: TransferDataService,
    public keepData: KeepAliveDataService,
    public authenticationService: AuthenticationService) {
    super(httpClient, router);
  };

  searchProduct(value: string): void {
    this.router.navigate(['/product']).then(() => {
      this.dataService.processDataParameter(value);
    });
  }

  public navigateToUpdatePersonalData(): void {
    this.router.navigate(['/personal-area']);
  }

  public navigateToStore(): void {
    this.router.navigate(['/store']);
  }

  ngOnInit(): void {
    this.dataService.currentDataParameter.subscribe(isConnected => this.isConnected = isConnected);
      if (!this.isConnected) {
      this.apiRequester.APIReturn({}, 'Accounts', 'isConnected', APIReturnKeys.Post).subscribe({
        next: (res: IsConnectedResponse) => {
          if (res.code === 0) {
            this.isConnected = res.isConnected;
          }
        },
        error: (err: any) => {
          console.error("Login failed", err);
        }
      });
    }
    this.cd.detectChanges();
  }

  onSubmitLogout(): void {
    this.hideModal('logout')
    this.authenticationService.logout();
  }
}
