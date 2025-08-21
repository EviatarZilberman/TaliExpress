import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
//import { Component } from '@angular/core';
import { IRedirect } from '../../../Interfaces/IRedirect';

//@Component({
//  selector: 'baseComponent',
//  standalone: false,
//})
export abstract class BaseComponent implements IRedirect {
  title: string = 'taliexpress.client.baseComponent';

  constructor(protected http: HttpClient, protected router: Router) {}


  redirectByPath(path: string): void {
    this.router.navigate([path]);
  }
}
