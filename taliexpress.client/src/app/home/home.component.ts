import { Component, OnInit } from '@angular/core';
import { User } from '../../../Classes/Common/User';
import { TransferDataService } from '../../../Services/TransferDataService';
import { CookiesGetterModule } from '../../../Modules/CookiesGetterModule';

@Component({
  selector: 'home',
  standalone: false,
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  providers: [CookiesGetterModule]
})
export class HomeComponent implements OnInit {
  public user!: User;

  constructor(public dataTransferer: TransferDataService, public cookiesModule: CookiesGetterModule) { }


  ngOnInit(): void {
    this.dataTransferer.currentDataParameter.subscribe(user => this.user = user);
  }
}
