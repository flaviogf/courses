import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Photo } from '../../photo/photo';

@Component({
  selector: 'app-photos',
  templateUrl: 'photos.component.html'
})
export class PhotosComponent implements OnChanges {

  @Input()
  public photos: Photo[] = [];

  private rows: Photo[][] = [];

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['photos']) {
      this.updateRows();
    }
  }

  private updateRows() {
    this.rows = [];
    for (let i = 0; i < this.photos.length; i += 3) {
      this.rows.push(this.photos.slice(i, i + 3));
    }
  }
}
