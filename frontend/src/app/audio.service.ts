import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AudioService {

  private apiUrl = 'http://localhost:5004/api/audio';

  constructor(private http: HttpClient) { }

  getAudios(): Observable<any> {
    return this.http.get<any>(this.apiUrl);
  }
}
