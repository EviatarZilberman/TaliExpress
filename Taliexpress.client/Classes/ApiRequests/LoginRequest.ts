import { BaseApiRequest } from "./BaseApiRequest";

export class LoginRequest extends BaseApiRequest<null> {
  email: string = "";
  password: string = "";
  }
