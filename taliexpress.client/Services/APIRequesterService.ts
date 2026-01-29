import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { APIReturnKeys } from '../Enums/APIReturnKeys';
import { ConfigurationService } from '../Services/ConfigurationService';
import { LoginResponse } from '../Classes/ApiResponse/LoginResponse';
import { LoginRequest } from '../Classes/ApiRequests/LoginRequest';

@Injectable({
  providedIn: 'root'
})

export class APIRequesterService {
  api!: string;
  constructor(private http: HttpClient, configurationService: ConfigurationService) {
    this.api = configurationService.getApiBaseUrl();
}

  private postCallAPI(item: any, controller: string, method: string): Observable<any> {
    let url = `${this.api}/${controller}/${method}`;
    const answer: any = this.http.post<any>(
      url,
      item/*, // pass the object directly
      {
        headers: {
          'Content-Type': 'application/json'
        }
      }*/
    );
    return answer;
  }

  private getCallAPI(item: any, controller: string, method: string): Observable<any> {
    const url = `${this.api}/${controller}/${method}?${item}`;
    return this.http.get<any>(url, { withCredentials: true });
  }

  public login(item: LoginRequest): Observable<LoginResponse> {
    const url = `${this.api}/login/login`;
    const answer: any = this.http.post<any>(
      url,
      item,
      { withCredentials: true }
    );
    return answer;
  }

  public APIReturn(item: any, controller: string, method: string, type: APIReturnKeys): any | undefined {
    //if (type === APIReturnKeys.Post) {
    // var answer = this.postCallAPI(item, controller, method);
    //  return this.APIReturnSubscribe(answer);
    //}
     if (type === APIReturnKeys.Post) {
       return this.postCallAPI(item, controller, method);
    }
    //else if (type === APIReturnKeys.Get) {
    //  answer = this.getCallAPI(item, controller, method);
    //  return this.APIReturnSubscribe(answer);
    //}
    else if (type === APIReturnKeys.Get) {
      return this.getCallAPI(item, controller, method);
    }
    return undefined;
  }

  private APIReturnSubscribe(answer: Observable<any>): JSON | undefined {
    answer.subscribe({
      next: (response) => {
        if (response === null) return undefined;
        if (typeof (response) === 'string') {
          try {
            return JSON.parse(response);
          }
          catch {
            return response;
          }
        }
      },
      error: (err) => {
        console.error('API failed to process the request. The error:', err);
      }
    });
    return undefined;
  }
}
