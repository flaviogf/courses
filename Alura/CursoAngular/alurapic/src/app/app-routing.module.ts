import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { PhotoListComponent } from './photos/photo-list/photo-list.component';
import { PhotoResolver } from './photos/photo/photo.resolver';

const routes: Routes = [
  {
    path: 'user/:userName',
    component: PhotoListComponent,
    resolve: {
      photos: PhotoResolver
    }
  },
  {
    path: '**',
    component: NotFoundComponent
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
