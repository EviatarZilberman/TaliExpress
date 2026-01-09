
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { Product } from '../../../Classes/Common/Product';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { BaseComponent } from '../BaseComponent/baseComponent.component';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { TransferDataService } from '../../../Services/TransferDataService';
import { APIReturnKeys } from '../../../Enums/APIReturnKeys';

@Component({
  selector: 'product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  standalone: true
})
export class ProductComponent extends BaseComponent implements OnInit, OnDestroy {
  private searchSub?: Subscription;
  public searchParam: any;
  products: Product[] = [];

  constructor(
    private apiRequester: APIRequesterService,
    protected override router: Router,
    protected httpClient: HttpClient,
    private searchService: TransferDataService
  ) {
    super(httpClient, router);
  }

  ngOnInit(): void {
    this.searchService.currentDataParameter.subscribe(searchParam => this.searchParam = searchParam);
    console.log('Search param: ', this.searchParam);
  }

  private searchByTerm(params: any): void {
    this.apiRequester
      .APIReturn(params, 'SearchProducts', 'SearchByParameters', APIReturnKeys.Get)
      .subscribe({
        next: (result: Product[]) => {
          this.products = result;
          console.log('Products found:', this.products);
        },
        error: (err: any) => console.error(err)
      });
  }


  //private searchByTerm(term: string): void {
  //  this.apiRequester
  //    .APIReturn(term, 'SearchProducts', 'SearchByParameters', APIReturnKeys.Get)
  //    .subscribe({
  //      next: (result: Product[]) => {
  //        this.products = result;
  //        console.log('Products found:', this.products);
  //      }
  //      //, error: err => console.error(err)
  //    });
  //}

  ngOnDestroy(): void {
    this.searchSub?.unsubscribe();
  }
}
