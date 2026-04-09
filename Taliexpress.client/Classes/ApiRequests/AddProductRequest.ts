import { Product } from "../Common/Product";

export class AddProductRequest {
  name: string = '';
  description: string = '';
  amountInInvenotry: number = 0;
  userId: string = '';
  price: number = 0;
  categories: string[] = [];
  asAvailable: boolean = false;
  discountId: number = 0;
}
