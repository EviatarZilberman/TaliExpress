import { Product } from "./Product";

export class DisplayProduct extends Product {
  productsToBuy: number = 1;

  constructor(product: Product) {
    super();
    Object.assign(this, product);
  }
}
