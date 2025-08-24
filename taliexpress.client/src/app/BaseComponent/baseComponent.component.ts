import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { IRedirect } from '../../../Interfaces/IRedirect';

export abstract class BaseComponent implements IRedirect {
  title: string = 'taliexpress.client.baseComponent';

  constructor(protected http: HttpClient, protected router: Router) { }

  redirectByPath(path: string, modalId: string): void {
    if (modalId !== null) this.hideModal(modalId);
    this.router.navigate([path]);
  }

  showModal(id: string): void {
    const modal = document.getElementById(id);
    if (modal) {
      modal.classList.add('show');
    }
  }

  hideModal(id: string): void {
    const modal = document.getElementById(id);
    if (modal) {
      modal.classList.remove('show');
    }
  }
}
