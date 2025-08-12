import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { IRedirect } from '../../../Interfaces/IRedirect';
import { Router } from '@angular/router';

@Component({
  selector: 'baseComponent',
  standalone: false,
})
export abstract class BaseComponent implements IRedirect {
  title: string = 'taliexpress.client.baseComponent';

  constructor(private http: HttpClient, private router: Router) {}


  redirectByPath(path: string): void {
    this.router.navigate([path]);
  }
}
