import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class APIRequesterComponent {
  private apiUrl = 'http://localhost:5001';

  constructor(private http: HttpClient) { }

  private postCallAPI(item: any, controller: string, method: string): Observable<any> {
    const url: string = `${this.apiUrl}/${controller}/${method}`;
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

  public APIReturn(item: any, controller: string, method: string, type: string): any | undefined {
    var answer: Observable<any> = new Observable<any>();
    if (type === 'p') {
      answer = this.postCallAPI(item, controller, method);
    }
    else if (type === 'g') {
      answer = this.getCallAPI(item, controller, method);
    }
    return answer.subscribe({
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
  }
}
