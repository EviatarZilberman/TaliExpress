import { DisplayProduct } from "./DisplayProduct";

export class CartItem {
  public product: DisplayProduct = new DisplayProduct(null!);
  public amount: number = 0;
}
