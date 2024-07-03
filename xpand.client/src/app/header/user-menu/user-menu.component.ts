import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'user-menu',
  templateUrl: './user-menu.component.html',
  styleUrl: './user-menu.component.scss'
})
export class UserMenuComponent {

  constructor(private router: Router) {
  }

  navigateToAddPlanet(): void {
    this.router.navigate(["planets/add"]);
  }
}
