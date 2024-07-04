import { Component, OnInit } from '@angular/core';
import { AuthService } from './shared/_services/auth.service';
import { Router } from '@angular/router';
import { User } from './auth/_interfaces/user.interface';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  currentUser?: User | null;

  constructor(private authService: AuthService, private router: Router) {
  }

  ngOnInit(): void {
    this.authService.currentUser$.subscribe(user => this.currentUser = user);
    console.log(this.currentUser);

    if (!this.currentUser) {
      this.router.navigate(['/login']);
    }
  }
}
