import { Component, OnDestroy, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { NavigationEnd, Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent implements OnInit, OnDestroy {
  showBackIcon: boolean = true;

  subscription = new Subscription();

  constructor(private location: Location, private router: Router) {
  }

  ngOnInit(): void {
    this.subscription.add(
      this.router.events.subscribe(event => {
        if (event instanceof NavigationEnd) {
          this.showBackIcon = !(
            event.urlAfterRedirects === '/planets' ||
            event.urlAfterRedirects === '/' ||
            event.urlAfterRedirects.includes('/edit') ||
            event.urlAfterRedirects.includes('/add'));
        }
      })
    );
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  navigateBack(): void {
    this.location.back();
  }
}
