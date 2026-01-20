import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TransferDataService {

  private dataParameter = new BehaviorSubject<any>(null); // BehaviorSubject keeps only the last parameter.
  public currentDataParameter: Observable<any> = this.dataParameter.asObservable();

  public processDataParameter(value: any) {
    this.dataParameter.next(value);
  }
}
