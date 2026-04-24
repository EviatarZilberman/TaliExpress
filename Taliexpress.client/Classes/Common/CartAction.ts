import { AddToCart } from './AddToCart';
import { CartActionKeys } from '../../Enums/CartActionKeys';

export class CartAction {
  public usingClass!: undefined | AddToCart;
  public actionType!: CartActionKeys;

  constructor(usingClass: undefined | AddToCart = undefined, actionType: CartActionKeys = CartActionKeys.DisplayCart) {
    this.actionType = actionType;
    this.usingClass = usingClass;
  }
}
