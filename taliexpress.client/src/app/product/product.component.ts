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

  searchProduct(productDescription: string): void | Product[] {
    if (productDescription === null) return;
    return this.apiRequester.APIReturn(productDescription, 'Products', 'searchProduct', 'g');
  }
}
