import { Image } from "./Image";

export class Product {
  description: string = '';
  amountInInvenotry: number = 0;
  seller: string = '';
  price: number = 0;
  images: Image = new Image();
}
