import { Product } from '../Common/Product';

export class Store {
  public storeOwner!: string;
  public products!: Product[];
  public openDate!: Date;
  public storeName!: string;
}
