import { BaseApiResponse } from "./BaseApiResponse";
import  { Product } from "../Common/Product";

export class SearchResponse extends BaseApiResponse {
  public products: Product[] = [];
}
