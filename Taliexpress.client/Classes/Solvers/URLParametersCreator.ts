import { HttpParams } from "@angular/common/http";

export class URLParametersCreator {
  public static createURLParametersFromObject(parameters: Map<string, string>): HttpParams {
    const params: HttpParams = new HttpParams();
    for (const [key, value] of parameters.entries()) {
      params.set(key, value);
    }
    return params;
  }
}
