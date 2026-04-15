import { ChangeDetectorRef, Component, Input } from '@angular/core';
import { Product } from '../../../Classes/Common/Product';
import { APIRequesterService } from '../../../Services/APIRequesterService';
import { APIReturnKeys } from '../../../Enums/APIReturnKeys';
import { UpdateProductRequest } from '../../../Classes/ApiRequests/UpdateProductRequest';
import { BaseApiResponse } from '../../../Classes/ApiResponse/BaseApiResponse';
import { Router } from '@angular/router';

@Component({
  selector: 'store-product',
  standalone: false,
  templateUrl: './store-product.component.html',
  styleUrl: './store-product.component.css',
})
export class StoreProductComponent {
  @Input() product!: Product;

  constructor(private cd: ChangeDetectorRef,
    private apiRequester: APIRequesterService,
   private router: Router) { }

  updateProduct(product: Product): void {
    let productRequest: UpdateProductRequest = new UpdateProductRequest();
    productRequest.product = product;
    
    const response: any = this.apiRequester.APIReturn(productRequest, 'Product', 'UpdateProduct', APIReturnKeys.Post)
      .subscribe({
        next: (res: BaseApiResponse) => {
          if (res.code === 0) {
            this.cd.detectChanges();
          }
        }
      }).then(() => {
        this.router.navigate(['/store'])
      });
  }
}
