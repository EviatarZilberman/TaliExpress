import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ConfigurationService {
  private config: any;

  constructor(private http: HttpClient) { }

  async loadConfig() {
    const data = await firstValueFrom(this.http.get('/assets/appsettings.json'));
    this.config = data;
  }

  get(key: string): any {
    return this.config ? this.config[key] : null;
  }

  get apiBaseUrl(): string {
    return this.get('apiBaseUrl');
  }
}
