import { DisplayProduct } from "./DisplayProduct";
import { CartItem } from "./CartItem";

export class CartDisplayProduct extends DisplayProduct {
  isChecked: boolean = false;

  createByDisplayProduct(displayProduct: DisplayProduct): void {
    this.productsToBuy = displayProduct.productsToBuy;
    this.price = displayProduct.price;
    this.amountInInvenotry = displayProduct.amountInInvenotry;
    this.categories = displayProduct.categories;
    this.description = displayProduct.description;
    this.discountId = displayProduct.discountId;
    this.id = displayProduct.id;
    this.isAvailable = displayProduct.isAvailable;
    this.name = displayProduct.name;
    this.userId = displayProduct.userId;
  }
}
