import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UpperNavBarComponent } from './upper-nav-bar/upper-nav-bar.component';

@NgModule({
  declarations: [UpperNavBarComponent],
  imports: [
    CommonModule
  ],
  exports: [
    UpperNavBarComponent
  ]
})
export class SharedModulesModule { }
