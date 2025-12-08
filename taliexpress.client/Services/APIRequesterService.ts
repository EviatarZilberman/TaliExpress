import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { APIReturnKeys } from '../Enums/APIReturnKeys';
import { ConfigurationService } from '../Services/ConfigurationService';

@Injectable({
  providedIn: 'root'
})

export class APIRequesterService {
  api!: string;
  constructor(private http: HttpClient, configurationService: ConfigurationService) {
    this.api = configurationService.getApiBaseUrl();
}

  private postCallAPI(item: any, controller: string, method: string): Observable<any> {
    var url: string = '';
    if (item instanceof Map) url = `${this.api}/${controller}/${item}`;
    else url = `${this.api}/${controller}/${method}`;
    const answer: any = this.http.post<any>(
      url,
      item, // pass the object directly
      {
        headers: {
          'Content-Type': 'application/json'
        }
      }
    );
    return answer;
  }

  private getCallAPI(item: any, controller: string, method: string): Observable<any> {
    const url = `${this.api}/${controller}/${method}?${item}`;
    return this.http.get<any>(url);
  }

  public APIReturn(item: any, controller: string, method: string, type: APIReturnKeys): any | undefined {
    var answer: Observable<any> = new Observable<any>();
    if (type === APIReturnKeys.Post) {
      answer = this.postCallAPI(item, controller, method);
      return this.APIReturnSubscribe(answer);
    }
    else if (type === APIReturnKeys.Post_no_subscribe) {
      answer = this.postCallAPI(item, controller, method);
      return answer;
    }
    else if (type === APIReturnKeys.Get) {
      answer = this.getCallAPI(item, controller, method);
      return this.APIReturnSubscribe(answer);
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
        alert('API failed');
      }
    });
    return undefined;
  }
}
