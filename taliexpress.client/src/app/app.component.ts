import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BaseComponent } from './BaseComponent/baseComponent.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  standalone: false
})
export class AppComponent extends BaseComponent {

  constructor(http: HttpClient, router: Router)
  {
    super(http, router);
  }
}
