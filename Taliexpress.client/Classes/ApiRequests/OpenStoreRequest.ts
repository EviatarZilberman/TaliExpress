import { BaseApiRequest } from "../ApiRequests/BaseApiRequest";
import { Store } from "../../Classes/Common/Store";

export class OpenStoreRequest extends BaseApiRequest<Store> {
  public storeName!: string;
  public ownerEmail!: string;
}
