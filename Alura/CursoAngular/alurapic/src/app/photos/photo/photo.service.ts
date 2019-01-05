import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Photo } from './photo';

@Injectable({ providedIn: 'root' })
export class PhotoService {

  constructor(private httpClient: HttpClient) { }

  public listFrom(userName: string): Observable<Photo[]> {
    return this.httpClient.get<Photo[]>(`http://localhost:3000/${userName}/photos`);
  }
}
