import { Product } from '../Common/Product';

export class Store {
  public userId: string = "";
  public id: string = "";
  public products: Product[] = [];
  public shipTo: string[] = [];
  public creationDate!: Date;
  public storeName: string = "";
}
