import { DisplayProduct } from "./DisplayProduct";
import { CartItem } from "./CartItem";

export class CartDisplayProduct extends DisplayProduct {
  isChecked: boolean = false;

  createByCartItem(cartItem: CartItem): void {
    this.productsToBuy = cartItem.amount;
    this.price = cartItem.product.price;
    this.amountInInvenotry = cartItem.product.amountInInvenotry;
    this.categories = cartItem.product.categories;
    this.description = cartItem.product.description;
    this.discountId = cartItem.product.discountId;
    this.id = cartItem.product.id;
    this.isAvailable = cartItem.product.isAvailable;
    this.name = cartItem.product.name;
    this.userId = cartItem.product.userId;
  }

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
