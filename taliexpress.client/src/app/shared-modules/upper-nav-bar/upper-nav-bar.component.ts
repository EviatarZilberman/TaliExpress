import { Component } from '@angular/core';
import { BaseComponent } from '../../BaseComponent/baseComponent.component';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Product } from '../../../../Classes/Product';
import { APIRequesterComponent } from '../../apirequester/apirequester.component';
import { SearchService } from '../../../../Services/SearchService';

@Component({
  selector: 'app-upper-nav-bar',
  templateUrl: './upper-nav-bar.component.html',
  styleUrl: './upper-nav-bar.component.css',
  standalone: false
})
export class UpperNavBarComponent extends BaseComponent {
  override title: string = 'taliexpress.client.navbarComponent';
  private searchService: SearchService | undefined;
  constructor(private apiRequester: APIRequesterComponent, protected override router: Router, protected httpClient: HttpClient, searchService: SearchService) {
    super(httpClient, router);
    this.searchService = searchService;
  };

  searchProduct(description: string): void | Product[] {
    if (description === null) return;
    const map: Map<string, string> = new Map<string, string>();
    map.set('searchWords', description);
    this.searchService?.parameterObserver(map);
  }
}
