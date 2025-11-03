import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
//import { URLParametersCreator } from '../Classes/URLParametersCreator';
import { APIReturnKeys } from '../Enums/APIReturnKeys';

@Injectable({
  providedIn: 'root'
})

export class APIRequesterService {
  private apiUrl = 'http://localhost:5001';

  constructor(private http: HttpClient) { }

  private postCallAPI(item: any, controller: string, method: string): Observable<any> {
    var url: string = '';
    if (item instanceof Map) url = `${this.apiUrl}/${controller}/${item}`;
    else url = `${this.apiUrl}/${controller}/${method}`;
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
    const url = `${this.apiUrl}/${controller}/${method}?${item}`;
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
