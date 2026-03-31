import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Store } from '../../../Classes/Common/Store';
import { OpenStoreRequest } from '../../../Classes/ApiRequests/OpenStoreRequest';
import { OpenStoreResponse } from '../../../Classes/ApiResponse/OpenStoreResponse';
import { APIReturnKeys } from '../../../Enums/APIReturnKeys';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { Router } from '@angular/router';
import { TransferDataService } from '../../../Services/TransferDataService';


@Component({
  selector: 'store',
  standalone: false,
  templateUrl: './store.component.html',
  styleUrl: './store.component.css',
})
export class StoreComponent implements OnInit {
  public store: Store = new Store();
  public hasStore!: boolean;
  constructor(private cd: ChangeDetectorRef,
    private dataPasser: TransferDataService,
    private apiRequester: APIRequesterService,
    private router: Router) { }

  ngOnInit(): void {
    this.apiRequester.APIReturn({}, 'Store', 'GetStore', APIReturnKeys.Get).subscribe({
      next: (res: Store) => {
        this.store = res;
      }
    });
  }

  openStore(): void {
    let request: OpenStoreRequest = {
      storeName: this.store.storeName,
      data: null!
    }
    const response: any = this.apiRequester.APIReturn(request, 'Store', 'OpenStore', APIReturnKeys.Post)
      .subscribe({
        next: (res: OpenStoreResponse) => {
          if (res.code === 0) {
            this.store = res.data;
            this.cd.detectChanges();
          }
        }
      }).then(() => {
        this.router.navigate(['/store'])
      });
  }

  navigateToNewProduct(): void {
    this.router.navigate(['/new-Product']);/*.then(() => {
      this.dataPasser.processDataParameter(this.keepData.user.email);
    });*/
  }
}
