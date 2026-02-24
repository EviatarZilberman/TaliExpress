import { Component, OnInit } from '@angular/core';
import { Product } from '../../../Classes/Common/Product';
import { TransferDataService } from '../../../Services/TransferDataService';

@Component({
  selector: 'new-product',
  standalone: false,
  templateUrl: './new-product.component.html',
  styleUrl: './new-product.component.css',
})
export class NewProductComponent implements OnInit {
  private ownerID: string = '';
  public product: Product = new Product();
  constructor(private dataPasser: TransferDataService)
  {
    this.product.seller = this.ownerID;
  }

  ngOnInit(): void {
    this.dataPasser.currentDataParameter.subscribe(userId => this.dataPasser = userId);
  }

  addProduct(): void {
    this.product.seller = this.ownerID;
  }
}
