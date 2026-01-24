import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../BaseComponent/baseComponent.component';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { APIRequesterService } from '../../../../Services/APIRequesterService';
import { TransferDataService } from '../../../../Services/TransferDataService';
import { KeepAliveDataService } from '../../../../Services/KeepAliveDataService';

@Component({
  selector: 'upper-nav-bar',
  templateUrl: './upper-nav-bar.component.html',
  styleUrl: './upper-nav-bar.component.css',
  standalone: false
})
export class UpperNavBarComponent extends BaseComponent implements OnInit {
  override title: string = 'taliexpress.client.navbarComponent';
  constructor(private apiRequester: APIRequesterService,
    protected override router: Router,
    protected httpClient: HttpClient,
    private dataService: TransferDataService,
    public keepData: KeepAliveDataService) {
    super(httpClient, router);
  };

  searchProduct(value: string): void {
    this.router.navigate(['/product']).then(() => {
      this.dataService.processDataParameter(value);
    });
  }

  public navigateToUpdatePersonalData(): void {
    this.router.navigate(['/personal-area']);
  }

  ngOnInit(): void {
    }
  }
