import { Cart } from "../Common/Cart";
import { BaseApiResponse } from "./BaseApiResponse";

export class GetDisplayCartResponse extends BaseApiResponse {
  public cart: Cart = new Cart();
}
