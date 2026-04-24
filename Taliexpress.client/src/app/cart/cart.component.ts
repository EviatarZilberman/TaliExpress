import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { TransferDataService } from '../../../Services/TransferDataService';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { CartAction } from '../../../Classes/Common/CartAction';
import { AddToCart } from '../../../Classes/Common/AddToCart';
import { BaseApiResponse } from '../../../Classes/ApiResponse/BaseApiResponse';
import { CartActionKeys } from '../../../Enums/CartActionKeys';
import { APIReturnKeys } from '../../../Enums/APIReturnKeys';
import { Router } from '@angular/router';



@Component({
  selector: 'app-cart',
  standalone: false,
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css',
})
export class CartComponent implements OnInit {
  private productSub?: Subscription;
  public productParam!: CartAction;

  constructor(private searchService: TransferDataService,
    private apiRequester: APIRequesterService,
    private router: Router) {

  }

  ngOnInit(): void {
    this.searchService.currentDataParameter.subscribe(ProductParam => this.productParam = ProductParam);
    switch (this.productParam.actionType) {
      case (CartActionKeys.AddToCart):
        {
          if (this.productParam.usingClass instanceof AddToCart) {
            this.addToCart(this.productParam.usingClass);
          }
          break;
        }
      case (CartActionKeys.DisplayCart):
        {
          break;
        }
    }
  }

  ngOnDestroy(): void {
    this.productSub?.unsubscribe();
  }

  addToCart(product: AddToCart): void {
    const response: any = this.apiRequester.APIReturn(product, 'Cart', 'AddToCart', APIReturnKeys.Post).subscribe({
      next: (res: BaseApiResponse) => {
        if (res.code === 0) {
          //this.router.navigate(['/']).then(() => {
          //});
        }
      },
      error: (err: any) => {
        console.error("Login failed", err);
      }
    });
  }
}
