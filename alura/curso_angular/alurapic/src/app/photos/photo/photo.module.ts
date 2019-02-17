import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CardModule } from '../../shared/components/card/card.module';
import { DarkOnHoverModule } from '../../shared/directives/dark-on-hover/dark-on-hover.module';
import { PhotoComponent } from './photo.component';

@NgModule({
  declarations: [
    PhotoComponent
  ],
  imports: [
    CommonModule,
    CardModule,
    DarkOnHoverModule
  ],
  exports: [
    PhotoComponent
  ]
})
export class PhotoModule { }
