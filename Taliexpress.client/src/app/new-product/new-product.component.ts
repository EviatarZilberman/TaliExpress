import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Product } from '../../../Classes/Common/Product';
import { TransferDataService } from '../../../Services/TransferDataService';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { APIReturnKeys } from '../../../Enums/APIReturnKeys';
import { AddProductRequest } from '../../../Classes/ApiRequests/AddProductRequest';
import { BaseApiResponse } from '../../../Classes/ApiResponse/BaseApiResponse';
import { BaseComponent } from '../../../src/app/BaseComponent/baseComponent.component';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'new-product',
  standalone: false,
  templateUrl: './new-product.component.html',
  styleUrl: './new-product.component.css',
})
export class NewProductComponent extends BaseComponent implements OnInit {
  private ownerID: string = '';
  public productRequest: AddProductRequest = new AddProductRequest();

  public constructor(private cd: ChangeDetectorRef, public dataPasser: TransferDataService, private apiRequester: APIRequesterService, private httpClient: HttpClient, router: Router) {
    super(httpClient, router);
  }

  ngOnInit(): void {
    this.dataPasser.currentDataParameter.subscribe(userId => this.ownerID = userId);
  }

  addProduct(): void {
    this.productRequest.userId = this.ownerID;
    this.apiRequester.APIReturn(this.productRequest, 'Product', 'addProduct', APIReturnKeys.Post).subscribe({
      next: (res: BaseApiResponse) => {
        if (res.code === 0) {
          this.navigateTo('/store');
        } else {
          this.screenMessage.message = res.message;
          this.cd.detectChanges();
        }
      },
      error: (err: any) => {
        console.log("FULL ERROR:", err);
        console.log("VALIDATION ERRORS:", err.error.errors);
      }
    });
  }
}
