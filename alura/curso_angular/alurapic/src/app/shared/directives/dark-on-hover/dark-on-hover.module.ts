import { NgModule } from '@angular/core';
import { DarkOnHoverDirective } from './dark-on-hover.directive';

@NgModule({
  declarations: [
    DarkOnHoverDirective
  ],
  exports: [
    DarkOnHoverDirective
  ]
})
export class DarkOnHoverModule { }
