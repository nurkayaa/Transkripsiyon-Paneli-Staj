import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router'; 
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private http: HttpClient, private router: Router) {}

  login() {
    const body = {
      username: this.username,
      password: this.password
    };

    this.http.post<any>('http://localhost:5004/api/login', body).subscribe({
      next: (response) => {
        console.log("Gelen cevap:", response); 
        localStorage.setItem('token', response.token);
        this.router.navigate(['/dashboard']);
      },
      error: (error) => {
        this.errorMessage = 'Geçersiz kullanıcı adı veya şifre';
      }
    });
  }
}
