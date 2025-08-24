import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class APIRequesterComponent {
  private apiUrl = 'https://localhost:5001';

  constructor(private http: HttpClient) { }

  CallAPI(item: any, controller: string, method: string): Observable<any> {
    // No need to stringify manually; HttpClient does it for you
    const answer: any = this.http.post<any>(
      `${this.apiUrl}/${controller}/${method}`,
      item, // pass the object directly
      {
        headers: {
          'Content-Type': 'application/json'
        }
      }
    );
    return answer;
  }
}
