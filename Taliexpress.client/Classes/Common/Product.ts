import { Image } from "./Image";

export class Product {
  name: string = '';
  description: string = '';
  amountInInvenotry: number = 0;
  seller: string = '';
  price: number = 0;
  images: Image = new Image();
}
