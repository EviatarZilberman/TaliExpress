import { User } from '../../../Classes/Common/User';
import { Cart } from '../../../Classes/Common/Cart';
import { Store } from '../../../Classes/Common/Store';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })

export class KeepAliveData {
  title: string = 'taliexpress.client.KeepAliveData';
  public user!: User;
  public Cart!: Cart;
  public store!: Store;

  constructor() { }

}
