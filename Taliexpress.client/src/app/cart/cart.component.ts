import { Component, OnInit } from '@angular/core';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { BaseApiResponse } from '../../../Classes/ApiResponse/BaseApiResponse';
import { DisplayProduct } from '../../../Classes/Common/DisplayProduct';
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
  public displayProducts: DisplayProduct[] = [];
  constructor(
    private apiRequester: APIRequesterService,
    private toastr: ToastrService,
    private router: Router) {

  }

  ngOnInit(): void {
    const response: any = this.apiRequester.APIReturn(null, 'Cart', 'DisplayCart', APIReturnKeys.Post).subscribe({
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
