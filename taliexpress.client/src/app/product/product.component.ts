//import { Component } from '@angular/core';
//import { Product } from '../../../Classes/Product';
//import { APIRequesterComponent } from '../apirequester/apirequester.component';
//import { BaseComponent } from '../BaseComponent/baseComponent.component';
//import { HttpClient } from '@angular/common/http';
//import { Router } from '@angular/router';
//import { SearchService } from '../../../Services/SearchService';

//@Component({
//  selector: 'app-product',
//  standalone: false,
//  templateUrl: './product.component.html',
//  styleUrl: './product.component.css'
//})
//export class ProductComponent extends BaseComponent {
//  private searchService: SearchService | undefined;

//  constructor(private apiRequester: APIRequesterComponent, protected override router: Router, protected httpClient: HttpClient, searchService: SearchService) {
//    super(httpClient, router);
//    this.searchService = searchService
//  }

//  public ngOnInit(): void | Product[] | undefined {
//    const result: any = this.searchProduct();
//  }

//  public searchProduct(): void | Product[] | string {
//    //public searchProduct(productDescription: string): void | Product[] {
//    //if (productDescription === null) return;
//    var result: Product[] | string | any;
//    this.searchService?.listenSearchParameter().subscribe(
//      variable => {
//        //this.data = variable;
//        result = this.apiRequester.APIReturn(this.searchService?.data, 'SearchProducts', 'SearchByParameters', 'g');
//      }
//    );
//    return result;
//  }

//  public addToCart(cartId: string, productId: string, amount: number): string {
//    if (cartId === null) return 'No cart chosen!';
//    const items: any[] = [cartId, productId, amount];
//    const result: string = this.apiRequester.APIReturn(items, 'Cart', 'AddProductToCart', 'p');

//    return result;
//  }

//  public RemoveFromCart(cartId: string, productId: string, amount: number): string {
//    if (cartId === null) return 'No cart chosen!';
//    const items: any[] = [cartId, productId, amount];
//    const result: string = this.apiRequester.APIReturn(items, 'Cart', 'RemoveProductFromCart', 'p');

//    return result;
//  }
//}


import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { Product } from '../../../Classes/Product';
import { APIRequesterComponent } from '../apirequester/apirequester.component';
import { BaseComponent } from '../BaseComponent/baseComponent.component';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { SearchService } from '../../../Services/SearchService';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  standalone: true
})
export class ProductComponent extends BaseComponent implements OnInit, OnDestroy {
  private searchSub?: Subscription;
  products: Product[] = [];

  constructor(
    private apiRequester: APIRequesterComponent,
    protected override router: Router,
    protected httpClient: HttpClient,
    private searchService: SearchService
  ) {
    super(httpClient, router);
  }

  ngOnInit(): void {
    // Subscribe ONCE
    this.searchSub = this.searchService.listenSearchParameter().subscribe(term => {
      if (term) {
        console.log('ProductComponent got search term:', term);
        this.searchByTerm(term);
      }
    });
  }

  private searchByTerm(term: string): void {
    this.apiRequester
      .APIReturn(term, 'SearchProducts', 'SearchByParameters', 'g')
      .subscribe({
        next: (result: Product[]) => {
          this.products = result;
          console.log('Products found:', this.products);
        }
        //, error: err => console.error(err)
      });
  }

  ngOnDestroy(): void {
    this.searchSub?.unsubscribe();
  }
}
