import { NgModule } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

@NgModule({
  providers: [CookieService],
})

export class CookiesGetterModule {
  constructor(private cookieService: CookieService) { }

  getCookie(cookieName: string) {
    const token = this.cookieService.get(cookieName);
  }

  getIdByCookie(cookieName: string) : string {
    return this.cookieService.get(cookieName);
  }

  isCookieExists(cookieName: string) : boolean {
    return this.cookieService.check(cookieName);  }
}
