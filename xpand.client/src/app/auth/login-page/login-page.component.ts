import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../shared/_services/auth.service';

@Component({
  selector: 'login-page',
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.scss'
})
export class LoginPageComponent {
  userName: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  submit(form: NgForm): void {
    if (form.invalid) {
      form.reset();
      return;
    }

    this.authService.login({ userName: this.userName, password: this.password })
      .subscribe({
        next: () => {
          form.reset();
        },
        error: error => {
          console.error('Login error:', error.message);
          form.reset();
        }
      });
  }
}
