import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { PhotoListModule } from './photo-list/photo-list.module';

@NgModule({
  imports: [
    CommonModule,
    PhotoListModule
  ]
})
export class PhotosModule { }
