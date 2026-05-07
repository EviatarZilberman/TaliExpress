import { Component, OnInit, OnDestroy, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Subscription } from 'rxjs';
import { Product } from '../../../Classes/Common/Product';
import { DisplayProduct } from '../../../Classes/Common/DisplayProduct';
import { AdvencedSearchParameters } from '../../../Classes/Common/AdvencedSearchParameters';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { BaseComponent } from '../BaseComponent/baseComponent.component';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { TransferDataService } from '../../../Services/TransferDataService';
import { APIReturnKeys } from '../../../Enums/APIReturnKeys';
import { SearchRequest } from '../../../Classes/ApiRequests/SearchRequest';
import { AdvancedSearchRequest } from '../../../Classes/ApiRequests/AdvancedSearchRequest';
import { SearchResponse } from '../../../Classes/ApiResponse/SearchResponse';
import { QueryAranger } from '../../../Classes/Solvers/QueryAranger';
import { CartService } from '../../../Services/CartService';

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
  public displayProducts: DisplayProduct[] = [];

  constructor(
    private apiRequester: APIRequesterService,
    protected override router: Router,
    protected httpClient: HttpClient,
    private dataService: TransferDataService,
    private cd: ChangeDetectorRef,
    private cartService: CartService
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
            this.displayProducts = this.ConvertToDisplayProducts(result.products);
            this.cd.markForCheck();
          }
        },
        error: (error: any) => {
          console.log('Error fetching products:', error);
        }
      });
    }
  }

  private ConvertToDisplayProducts(products: Product[]): DisplayProduct[] {
    let productsResult: DisplayProduct[] = [];
    for (let i = 0; i < products.length; i++) {
      productsResult.push(new DisplayProduct(products[i]));
    }
    return productsResult;
  }

  increaseAmount(product: DisplayProduct): void {
    product.productsToBuy++;
  }

  decreaseAmount(product: DisplayProduct): void {
    if (product.productsToBuy > 1) product.productsToBuy--;
    }
  //private searchByTerm(params: any): void {
  //  this.apiRequester
  //    .APIReturn(params, 'SearchProducts', 'SearchByParameters', APIReturnKeys.Get)
  //    .subscribe({
  //      next: (result: Product[]) => {
  //        this.displayProducts = result;
  //        console.log('Products found:', this.displayProducts);
  //      },
  //      error: (err: any) => console.error(err)
  //    });
  //}


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
    this.cartService.addToCart(id, amount);
  }
}
