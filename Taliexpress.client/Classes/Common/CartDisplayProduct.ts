import { DisplayProduct } from "./DisplayProduct";

export class CartDisplayProduct extends DisplayProduct {
  isChecked: boolean = false;

  constructor(displayProduct: DisplayProduct) {
    super(displayProduct);
   // Object.assign(this, displayProduct);
  }
}
