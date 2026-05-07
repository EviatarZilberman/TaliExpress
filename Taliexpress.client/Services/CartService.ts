import { Injectable } from '@angular/core';
import { AddToCart } from "../Classes/Common/AddToCart";
import { ToastrService } from 'ngx-toastr';
import { BaseApiResponse } from '../Classes/ApiResponse/BaseApiResponse';
import { APIRequesterService } from '../Services/APIRequesterService';
import { APIReturnKeys } from '../Enums/APIReturnKeys';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  constructor(private toastr: ToastrService,
    private apiRequester: APIRequesterService) { }

  addToCart(id: string, amount: number): void {
    let addToCart: AddToCart = new AddToCart(id, amount);
    const response: any = this.apiRequester.APIReturn(addToCart, 'Cart', 'addToCart', APIReturnKeys.Post).subscribe({
      next: (res: BaseApiResponse) => {
        if (res.code === 0) {
          this.toastr.success(res.message, 'Success');
        }
        else {
          this.toastr.error(res.message, 'Warning');
        }
      },
      error: (err: any) => {
        this.toastr.error('Error adding to cart', 'Error');
      }
    });
  }
}
