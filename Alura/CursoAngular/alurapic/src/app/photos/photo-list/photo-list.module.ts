import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { PhotoModule } from '../photo/photo.module';
import { PhotoFilterPipe } from './photo-filter.pipe';
import { PhotoFilterComponent } from './photo-filter/photo-filter.component';
import { PhotoListComponent } from './photo-list.component';
import { PhotosComponent } from './photos/photos.component';

@NgModule({
  declarations: [
    PhotosComponent,
    PhotoFilterPipe,
    PhotoListComponent,
    PhotoFilterComponent
  ],
  imports: [
    HttpClientModule,
    CommonModule,
    PhotoModule
  ]
})
export class PhotoListModule { }
