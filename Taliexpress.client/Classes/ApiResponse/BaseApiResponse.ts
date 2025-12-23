export class BaseApiResponse<T> {
  Data!: T;
  code!: number;
  message!: string;
}
