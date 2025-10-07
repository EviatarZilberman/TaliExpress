import { Component } from '@angular/core';
import { BaseComponent } from '../BaseComponent/baseComponent.component';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Product } from '../../../Classes/Product';
import { APIRequesterComponent } from '../apirequester/apirequester.component';

@Component({
  selector: 'app-upper-nav-bar',
  templateUrl: './upper-nav-bar.component.html',
  styleUrl: './upper-nav-bar.component.css',
  standalone: false
})
export class UpperNavBarComponent extends BaseComponent {
  override title: string = 'taliexpress.client.navbarComponent';

  constructor(private apiRequester: APIRequesterComponent, protected override router: Router, protected httpClient: HttpClient) {
    super(httpClient, router);
  //constructor(protected override router: Router, protected httpClient: HttpClient) {
  //  super(httpClient, router);
  };

  //searchProduct(description: string): Product[] | string {
  //  return 'null';
  //}

  searchProduct(description: string): void | Product[] {
    if (description === null) return;
    return this.apiRequester.APIReturn(description, 'SearchProducts', 'searchProduct', 'g');
  }
}
