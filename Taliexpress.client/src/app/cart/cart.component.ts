import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { GetDisplayCartResponse } from '../../../Classes/ApiResponse/GetDisplayCartResponse';
import { APIReturnKeys } from '../../../Enums/APIReturnKeys';
import { ToastrService } from 'ngx-toastr';
import { CartDisplayProduct } from '../../../Classes/Common/CartDisplayProduct';
import { CartItem } from '../../../Classes/Common/CartItem';


@Component({
  selector: 'cart',
  standalone: false,
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css',
})
export class CartComponent implements OnInit {
  public cartDisplayProducts: CartDisplayProduct[] = [];
  public totalPrice: number = 0;
  public productsToBuy: string[] = [];
  constructor(
    private apiRequester: APIRequesterService,
    private cd: ChangeDetectorRef,
    private toastr: ToastrService) {
  }

  ngOnInit(): void {
    const response: any = this.apiRequester.APIReturn(null, 'Cart', 'DisplayCart', APIReturnKeys.Post).subscribe({
      next: (res: GetDisplayCartResponse) => {
        if (res.code === 0) {
          this.cartDisplayProducts = this.convertCartItemsToCartDisplayProducts(res.cart.cartProducts);
          this.cd.detectChanges();
        }
      },
      error: (err: any) => {
        this.toastr.error('Error getting cart', 'Error');
      }
    });
  }

  convertCartItemsToCartDisplayProducts(cartProducts: CartItem[]): CartDisplayProduct[] {
    let result: CartDisplayProduct[] = [];
    for (let i = 0; i < cartProducts.length; i++) {
      let cartDisplayProduct: CartDisplayProduct = new CartDisplayProduct(cartProducts[i].product);
      cartDisplayProduct.productsToBuy = cartProducts[i].amount;
      result.push(cartDisplayProduct);
    }

    return result;
  }

  addOrRemoveFromPurchase(productId: string): void {
    let product = this.cartDisplayProducts.find(p => p.id === productId);
    if (!product) {
      this.toastr.error('Product not found', 'Error');
      return;
    }
    if (!this.cartDisplayProducts.find(p => p.id === productId)?.isChecked) {
      this.cartDisplayProducts.find(p => p.id === productId)!.isChecked = true;
      this.productsToBuy.push(productId);
      this.totalPrice += product!.price * product!.productsToBuy || 0;
    }
    else {
      this.cartDisplayProducts.find(p => p.id === productId)!.isChecked = false;
      this.productsToBuy = this.productsToBuy.filter(p => p !== productId);
      this.totalPrice -= product!.price * product!.productsToBuy || 0;
    }
    if (this.totalPrice < 0) this.totalPrice = 0;
  }

  payForCheckedProducts(): void {
    console.log(this.productsToBuy);
    console.log(this.totalPrice);
  }
}
