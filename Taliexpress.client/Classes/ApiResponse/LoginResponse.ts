import { User } from "../Common/User";
import { Cart } from "../Common/Cart";
import { Store } from "../Common/Store";
import { BaseApiResponse } from "./BaseApiResponse";

export class LoginResponse extends BaseApiResponse {
  user: User = new User();
  cart: Cart = new Cart();
  store: Store = new Store();
}
