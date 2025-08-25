import { Component } from '@angular/core';
import { BaseComponent } from '../BaseComponent/baseComponent.component';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Product } from '../../../Classes/Product';

@Component({
  selector: 'app-upper-nav-bar',
  templateUrl: './upper-nav-bar.component.html',
  styleUrl: './upper-nav-bar.component.css',
  standalone: false
})
export class UpperNavBarComponent extends BaseComponent {
  override title: string = 'taliexpress.client.navbarComponent';

  constructor(protected override router: Router, protected httpClient: HttpClient) {
    super(httpClient, router);
  };

  searchProduct(description: string): Product[] | string {
    return 'null';
  }
}
