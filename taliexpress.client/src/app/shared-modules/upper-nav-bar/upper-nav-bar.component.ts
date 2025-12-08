import { Component } from '@angular/core';
import { BaseComponent } from '../../BaseComponent/baseComponent.component';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { APIRequesterService } from '../../../../Services/APIRequesterService';
import { TransferDataService } from '../../../../Services/TransferDataService';

@Component({
  selector: 'upper-nav-bar',
  templateUrl: './upper-nav-bar.component.html',
  styleUrl: './upper-nav-bar.component.css',
  standalone: false
})
export class UpperNavBarComponent extends BaseComponent {
  override title: string = 'taliexpress.client.navbarComponent';
  constructor(private apiRequester: APIRequesterService, protected override router: Router, protected httpClient: HttpClient, private dataService: TransferDataService) {
    super(httpClient, router);
  };

  searchProduct(value: string): void {
    this.dataService.processDataParameter(value);
  }
  

  //searchProduct(description: string): void | Product[] {
  //  if (description === null) return;
  //  const map: Map<string, string> = new Map<string, string>();
  //  map.set('searchWords', description);
  //  this.searchService?.parameterObserver(map);
  //}
}
