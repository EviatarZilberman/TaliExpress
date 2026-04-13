import { ChangeDetectorRef, Component, Input } from '@angular/core';
import { Product } from '../../../Classes/Common/Product';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { APIReturnKeys } from '../../../Enums/APIReturnKeys';

@Component({
  selector: 'store-product',
  standalone: false,
  templateUrl: './store-product.component.html',
  styleUrl: './store-product.component.css',
})
export class StoreProductComponent {
  @Input() product!: Product;

  constructor(private cd: ChangeDetectorRef,
              private apiRequester: APIRequesterService,) { }

  updateProduct(product: Product): void {
    const response: any = this.apiRequester.APIReturn(request, 'Store', 'OpenStore', APIReturnKeys.Post)
      .subscribe({
        next: (res: OpenStoreResponse) => {
          if (res.code === 0) {
            this.store = res.data;
            this.cd.detectChanges();
          }
        }
      }).then(() => {
        this.router.navigate(['/store'])
      });
  }
}
