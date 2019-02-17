import { Directive, ElementRef, HostListener, Renderer } from '@angular/core';

@Directive({
  selector: '[dark-on-hover]'
})
export class DarkOnHoverDirective {

  constructor(private el: ElementRef, private render: Renderer) { }

  @HostListener('mouseenter')
  private onHoverOn() {
    this.render.setElementStyle(this.el.nativeElement, 'filter', 'brightness(0.7)')
  }

  @HostListener('mouseleave')
  private onHoverOff() {
    this.render.setElementStyle(this.el.nativeElement, 'filter', 'brightness(1)')
  }
}
