import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-photo',
  templateUrl: './photo.component.html',
  styleUrls: ['./photo.component.css']
})
export class PhotoComponent {

  @Input()
  public url: string = '';

  @Input()
  public description: string = '';
}
