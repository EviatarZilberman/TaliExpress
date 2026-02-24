import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ScreenMessage } from '../../../Classes/Common/ScreenMessage';
import { TransferDataService } from '../../../Services/TransferDataService';

@Component({
  selector: 'screen-message',
  standalone: false,
  templateUrl: './screenMessage.component.html',
  styleUrl: './screenMessage.component.css',
})
export class ScreenMessageComponent implements OnInit {
  screenMessage!: ScreenMessage;

  constructor(public messageService: TransferDataService,
    private cd: ChangeDetectorRef) { }

  ngOnInit(): void {
    this.messageService.currentDataParameter.subscribe(screenMessageParam => this.screenMessage = screenMessageParam);
    this.cd.markForCheck();
  }
}
