import { Injectable } from "@angular/core";
//import { Subject } from "rxjs";
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SearchService {

  private searchParameter = new BehaviorSubject<any>(null); // BehaviorSubject keeps only the last parameter.


  public listenSearchParameter(): Observable<any> {
    return this.searchParameter.asObservable();

  }


  public parameterObserver(value: any) {
    this.searchParameter.next(value);
  }
}
