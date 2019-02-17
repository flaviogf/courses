import { Pipe, PipeTransform } from '@angular/core';
import { Photo } from '../photo/photo';

@Pipe({
  name: 'photoFilter'
})
export class PhotoFilterPipe implements PipeTransform {

  transform(photos: Photo[], filter: string): Photo[] {
    return photos.filter(it => it.description.toLocaleLowerCase().includes(filter.toLocaleLowerCase()));
  }
}
