import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { UserDashboardComponent } from './pages/user-dashboard/user-dashboard.component'; // user-dashboard component import edildi

export const routes: Routes = [
  { path: '', component: LoginComponent },          // http://localhost:4200/
  { path: 'dashboard', component: UserDashboardComponent } // http://localhost:4200/dashboard
];
