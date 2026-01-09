export abstract class BaseApiResponse<T> {
  data!: T;
  code!: number;
  message!: string;
}
