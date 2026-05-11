import { User } from "../Common/User";
import { CartData } from "../Common/CartData";
import { StoreData } from "../Common/StoreData";
import { BaseApiResponse } from "./BaseApiResponse";

export class LoginResponse extends BaseApiResponse {
  user: User = new User();
  cartData: CartData = new CartData();
  storeData: StoreData = new StoreData();
}
