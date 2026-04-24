import { Component, OnInit, OnDestroy, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Subscription } from 'rxjs';
import { Product } from '../../../Classes/Common/Product';
import { AdvencedSearchParameters } from '../../../Classes/Common/AdvencedSearchParameters';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { BaseComponent } from '../BaseComponent/baseComponent.component';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { TransferDataService } from '../../../Services/TransferDataService';
import { APIReturnKeys } from '../../../Enums/APIReturnKeys';
import { CartActionKeys } from '../../../Enums/CartActionKeys';
import { SearchRequest } from '../../../Classes/ApiRequests/SearchRequest';
import { AdvancedSearchRequest } from '../../../Classes/ApiRequests/AdvancedSearchRequest';
import { SearchResponse } from '../../../Classes/ApiResponse/SearchResponse';
import { QueryAranger } from '../../../Classes/Solvers/QueryAranger';
import { AddToCart } from '../../../Classes/Common/AddToCart';
import { CartAction } from '../../../Classes/Common/CartAction';

@Component({
  selector: 'product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  standalone: true,
  imports: [CommonModule]
})
export class ProductComponent extends BaseComponent implements OnInit, OnDestroy {
  private searchSub?: Subscription;
  public searchParam!: string | AdvencedSearchParameters;
  products: Product[] = [];

  constructor(
    private apiRequester: APIRequesterService,
    protected override router: Router,
    protected httpClient: HttpClient,
    private dataService: TransferDataService,
    private cd: ChangeDetectorRef
  ) {
    super(httpClient, router);
  }

  ngOnInit(): void {
    this.dataService.currentDataParameter.subscribe(searchParam => this.searchParam = searchParam);

    if (this.searchParam !== null) {
      const map: Map<string, any> = new Map<string, any>();
      map.set('name', this.searchParam);
      const query: string = QueryAranger.Arange(map);
      let searchRequest!: SearchRequest | AdvancedSearchRequest;
      //if (typeof this.searchParam === 'string') {
      //  searchRequest = new SearchRequest();
      //  searchRequest.name = this.searchParam;
      //}
      //else {
      //  searchRequest = new AdvancedSearchRequest();
      //  //searchRequest.AdvancedSearchRequest = this.searchParam;
      //}
      const answer = this.apiRequester.APIReturn(query, 'SearchProducts', 'SearchProducts', APIReturnKeys.Get);
      answer.subscribe({
        next: (result: SearchResponse) => {
          if (result.code === 0) {
            this.products = result.products;
            this.cd.markForCheck();
          }
        },
        error: (error: any) => {
          console.log('Error fetching products:', error);
        }
      });
    }
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

  addToCart(id: string, amount: number): void {
    let addToCart: AddToCart = new AddToCart(id, amount);
    let cartAction: CartAction = new CartAction(addToCart, CartActionKeys.AddToCart);
    this.dataService.processDataParameter(cartAction);
  }
}
