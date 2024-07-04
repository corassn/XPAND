import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../shared/_services/auth.service';

@Component({
  selector: 'user-menu',
  templateUrl: './user-menu.component.html',
  styleUrl: './user-menu.component.scss'
})
export class UserMenuComponent {

  constructor(private router: Router, private authService: AuthService) {
  }

  logout(): void {
    this.authService.logout();
  }

  navigateToAddPlanet(): void {
    this.router.navigate(["planets/add"]);
  }
}
