import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { TranscriptionService } from '../../services/transcription.service';



@Component({
  selector: 'app-user-dashboard',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './user-dashboard.component.html',
  styleUrl: './user-dashboard.component.scss'
})
export class UserDashboardComponent {
  constructor(private http: HttpClient, private router: Router, private transcriptionService: TranscriptionService) { }
  
  logs: any[] = [];
  errorMessage: string = '';
  transcriptions: any[] = [];
  showUserLogs: boolean = false;

  // Logout fonksiyonu
  /*logout() {
    localStorage.removeItem('token');

    this.router.navigate(['/login']);
  }*/
  
  selectedRole: string = 'editor';
  transcriptionText: string = 'Buraya bir transkripsiyon örneği yaz...';
  audioUrl: string = ''; 

  ngOnInit(): void {
    this.audioUrl = 'http://localhost:5004/api/testdata/audio';
    this.getTranscription();

    if (this.selectedRole === 'admin') {
      this.fetchLogs();
      this.getAllTranscriptions();
    }
    
  }

  getTranscription() {
    this.http.get<any>('http://localhost:5004/api/testdata/transcription')
      .subscribe({
        next: (data) => {
          this.transcriptionText = data.text || '';
        },
        error: (err) => {
          console.error('Transkripsiyon alınamadı:', err);
        }
      });
    }

  
    saveTranscription() {
      const transcriptionId = 1; 
      const payload = {
        text: this.transcriptionText
      };

      const token = localStorage.getItem('token'); 
      const headers = { Authorization: `Bearer ${token}` }; 
    
      this.http.put(`http://localhost:5004/api/Transcription/${transcriptionId}`, payload, { headers })
        .subscribe({
          next: () => {
            alert('Transkripsiyon başarıyla kaydedildi!');
          },
          error: (err) => {
            console.error('Kayıt sırasında hata:', err);
            alert('Kayıt sırasında hata oluştu!');
          }
        });
    }

    getAllTranscriptions() {
      this.transcriptionService.getAllTranscriptions().subscribe({
        next: (data) => {
          console.log("Transkripsiyon verisi:", data);
          this.transcriptions = data;
        },
        error: (err) => {
          console.error("Transkripsiyon verisi alınamadı:", err);
        }
      });
    }
    
    

  fetchLogs() {
    const token = localStorage.getItem('token');
    if (!token) {
      this.errorMessage = 'Token bulunamadı.';
      return;
    }
  
    this.http.get<any[]>('http://localhost:5004/api/Admin/logs', {
      headers: { Authorization: `Bearer ${token}` }
    }).subscribe({
      next: (data) => {
        console.log('Loglar alındı:', data);
        this.logs = data;
      },
      error: (err) => {
        console.error('Loglar alınamadı:', err);
        this.errorMessage = 'Loglar alınamadı: ' + err.message;
      }
    });
  }
  
}


