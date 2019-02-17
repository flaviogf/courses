import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Photo } from '../photo/photo';

@Component({
  selector: 'app-photo-list',
  templateUrl: './photo-list.component.html',
  styleUrls: ['./photo-list.component.css']
})
export class PhotoListComponent implements OnInit {

  private filter: string = '';

  private photos: Photo[] = [];

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.photos = this.route.snapshot.data['photos']
  }
}
