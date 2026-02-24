import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { KeepAliveDataService } from '../../../Services/KeepAliveDataService';
import { Store } from '../../../Classes/Common/Store';
import { Product } from '../../../Classes/Common/Product';
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
  constructor(public keepData: KeepAliveDataService,
    private cd: ChangeDetectorRef,
    private dataPasser: TransferDataService,
    private apiRequester: APIRequesterService,
    private router: Router) { }

  ngOnInit(): void {
  }

  openStore(): void {
    let request: OpenStoreRequest = {
      storeName: this.store.storeName,
      ownerEmail: this.keepData.user.email,
      data: null!
    }
    const response: any = this.apiRequester.APIReturn(request, 'Store', 'OpenStore', APIReturnKeys.Post)
      .subscribe({
        next: (res: OpenStoreResponse) => {
          if (res.code === 0) {
            this.keepData.store = this.store;
            this.cd.detectChanges();
          }
        }
      }).then(() => {
        this.router.navigate(['/store'])
      });
  }

  navigateToNewProduct(): void {
    this.router.navigate(['/addProduct']).then(() => {
      this.dataPasser.processDataParameter(this.keepData.user.email);
    });
  }
}
