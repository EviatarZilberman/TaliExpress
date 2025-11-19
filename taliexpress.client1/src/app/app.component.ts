import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BaseComponent } from './BaseComponent/baseComponent.component';

interface Nav {
  link: string,
  name: string,
  exact: boolean
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  standalone: false
})
export class AppComponent extends BaseComponent {
  nav: Nav[] = [{
    link: '/',
    name: 'Home',
    exact: true
  },
    {
      link: '/badroute',
      name: 'Bad Route',
      exact: true
    }]
  constructor(http: HttpClient, router: Router)
  {
    super(http, router);
  }
}
