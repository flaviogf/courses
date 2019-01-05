import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';

@Component({
  selector: 'app-photo-filter',
  templateUrl: 'photo-filter.component.html'
})
export class PhotoFilterComponent implements OnInit {

  @Output()
  public onFilter: EventEmitter<string> = new EventEmitter<string>();

  @Input()
  public filter: string = '';

  private debounce: Subject<string> = new Subject();

  ngOnInit(): void {
    this.debounce
      .pipe(debounceTime(300))
      .subscribe(it => this.onFilter.emit(it))
  }
}
