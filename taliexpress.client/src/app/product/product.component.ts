import { Component } from '@angular/core';
import { Product } from '../../../Classes/Product';
import { APIRequesterComponent } from '../apirequester/apirequester.component';
import { BaseComponent } from '../BaseComponent/baseComponent.component';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product',
  standalone: false,
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent extends BaseComponent {
  constructor(private apiRequester: APIRequesterComponent, protected override router: Router, protected httpClient: HttpClient) {
    super(httpClient, router);
  }

  public searchProduct(productDescription: string): void | Product[] {
    if (productDescription === null) return;
    return this.apiRequester.APIReturn(productDescription, 'SearchProducts', 'SearchByParameters', 'g');
  }

  public addToCart(cartId: string, productId: string, amount: number): string {
    if (cartId === null) return 'No cart chosen!';
    const items: any[] = [ cartId, productId, amount ];
    const result: string = this.apiRequester.APIReturn(items, 'Cart', 'AddProductToCart', 'p');

    return result;
  }

  public RemoveFromCart(cartId: string, productId: string, amount: number): string {
    if (cartId === null) return 'No cart chosen!';
    const items: any[] = [cartId, productId, amount];
    const result: string = this.apiRequester.APIReturn(items, 'Cart', 'RemoveProductFromCart', 'p');

    return result;
  }
}
