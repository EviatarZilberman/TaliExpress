import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../BaseComponent/baseComponent.component';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { APIRequesterService } from '../../../../Services/APIRequesterService';
import { TransferDataService } from '../../../../Services/TransferDataService';
import { User } from '../../../../Classes/Common/User';

@Component({
  selector: 'upper-nav-bar',
  templateUrl: './upper-nav-bar.component.html',
  styleUrl: './upper-nav-bar.component.css',
  standalone: false
})
export class UpperNavBarComponent extends BaseComponent/* implements OnInit*/ {
  override title: string = 'taliexpress.client.navbarComponent';
  public user!: User;
  constructor(private apiRequester: APIRequesterService, protected override router: Router, protected httpClient: HttpClient, private dataService: TransferDataService) {
    super(httpClient, router);
  };

  searchProduct(value: string): void {
    //this.dataService.processDataParameter(value);
    this.router.navigate(['/products']).then(() => {
      this.dataService.processDataParameter(value);
    });
  }

  //ngOnInit(): void {
  //  this.dataService.currentDataParameter.subscribe(user => this.user = user);
  //  if (this.user) {
  //    console.error('The user name is: ', this.user.firstName, this.user.lastName);
  //  }
  //}
  

  //searchProduct(description: string): void | Product[] {
  //  if (description === null) return;
  //  const map: Map<string, string> = new Map<string, string>();
  //  map.set('searchWords', description);
  //  this.searchService?.parameterObserver(map);
  //}
}
