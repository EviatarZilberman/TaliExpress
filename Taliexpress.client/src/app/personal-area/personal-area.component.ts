import { Component, OnInit } from '@angular/core';
import { KeepAliveDataService } from '../../../Services/KeepAliveDataService';

@Component({
  selector: 'personal-area',
  standalone: false,
  templateUrl: './personal-area.component.html',
  styleUrl: './personal-area.component.css',
})
export class PersonalAreaComponent implements OnInit {

  constructor(private keepData: KeepAliveDataService) { }

  ngOnInit(): void {

  }
}
