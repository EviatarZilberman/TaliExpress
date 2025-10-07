import { Injectable } from "@angular/core";
//import { Subject } from "rxjs";
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SearchService {

  private searchParameter = new BehaviorSubject<string>(''); // BehaviorSubject keeps only the last parameter.
  public data: any;


  public listenSearchParameter(): Observable<string> {
    return this.searchParameter.asObservable();

  }


  public parameterObserver(value: any) {
    this.data = value;
    this.searchParameter.next(value);
  }
}
