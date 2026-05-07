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
    
  }

  ngOnDestroy(): void {
    this.productSub?.unsubscribe();
  }
}
