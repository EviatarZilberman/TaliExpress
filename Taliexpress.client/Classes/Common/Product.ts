
export class Product {
  id: string = '';
  creationDate!: Date;
  name: string = '';
  description: string = '';
  amountInInvenotry: number = 0;
  userId: string = '';
  price: number = 0;
  //images: Image = new Image();
  categories: string[] = [];
  asAvailable: boolean = false;
  discountId: number = 0;
}
