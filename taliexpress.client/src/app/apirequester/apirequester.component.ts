import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class APIRequesterComponent {
  private apiUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  register(item: any, controller: string, method: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/${controller}/${method}`, item);
  }
}
