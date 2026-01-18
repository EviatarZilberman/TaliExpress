import { Product } from '../Common/Product';

export class Store {
  public owner!: string;
  public products!: Product[];
  public openDate!: Date;
}
