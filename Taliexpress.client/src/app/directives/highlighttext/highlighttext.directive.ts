import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[highlighttext]',
  standalone: false,
})
export class HighlighttextDirective {

  constructor(private el: ElementRef) { }

  @HostListener('mouseenter') onMouseEnter() {
    this.el.nativeElement.style.backgroundColor = 'blue';
  }

  @HostListener('mouseleave') onMouseLeave() {
    this.el.nativeElement.style.backgroundColor = 'pink';
  }

}
