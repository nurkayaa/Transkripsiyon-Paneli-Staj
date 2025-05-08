import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TranscriptionService {
  private apiUrl = 'http://localhost:5004/api/Admin/logs'; 

  constructor(private http: HttpClient) {}

  getAllTranscriptions(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}`);
  }
}
