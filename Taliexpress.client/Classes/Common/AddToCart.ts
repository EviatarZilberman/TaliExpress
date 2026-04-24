export class AddToCart {
  public productId: string = '';
  public amount: number = 1;

  constructor(productId: string, amount: number) {
    this.productId = productId;
    this.amount = amount;
  }
}
