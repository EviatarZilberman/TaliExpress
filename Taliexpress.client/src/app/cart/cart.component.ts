import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { TransferDataService } from '../../../Services/TransferDataService';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { AddToCart } from '../../../Classes/Common/AddToCart';
import { BaseApiResponse } from '../../../Classes/ApiResponse/BaseApiResponse';
import { CartActionKeys } from '../../../Enums/CartActionKeys';
import { APIReturnKeys } from '../../../Enums/APIReturnKeys';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'cart',
  standalone: false,
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css',
})
export class CartComponent implements OnInit {
  private productSub?: Subscription;
  //public productParam!: CartAction;

  constructor(private dataService: TransferDataService,
    private apiRequester: APIRequesterService,
    private toastr: ToastrService,
    private router: Router) {

  }

  ngOnInit(): void {
    this.productSub = this.dataService.currentDataParameter.subscribe(param => {
      if (!param) return;
      switch (param.actionType) {
        case (CartActionKeys.AddToCart):
          {
            this.addToCart(param.usingClass);
            break;
          }
        case (CartActionKeys.DisplayCart):
          {
            this.displayCart();
            break;
          }
      }
    });
  }

  ngOnDestroy(): void {
    this.productSub?.unsubscribe();
  }

  addToCart(product: AddToCart): void {
    const response: any = this.apiRequester.APIReturn(product, 'Cart', 'addToCart', APIReturnKeys.Post).subscribe({
      next: (res: BaseApiResponse) => {
        if (res.code === 0) {
          this.toastr.success(res.message, 'Success');
        }
        else {
          this.toastr.error(res.message, 'Error');
        }
      },
      error: (err: any) => {
        console.error("Adding to cart failed", err);
      }
    });
  }

  displayCart(): void {

  }
}
