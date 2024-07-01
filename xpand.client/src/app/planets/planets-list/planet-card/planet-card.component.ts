import { Component, Input, OnInit } from '@angular/core';
import { Planet } from '../../_interfaces/planet.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { PlanetStatusUtils } from '../../_utils/planet-status.utils';

@Component({
  selector: 'planet-card',
  templateUrl: './planet-card.component.html',
  styleUrl: './planet-card.component.scss'
})
export class PlanetCardComponent implements OnInit {
  @Input() planet?: Planet;

  noDescriptionText: string = 'No description yet!';
  status: string = '';
  cssClass: string = '';

  constructor(private router: Router, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    if (this.planet) {
      this.status = PlanetStatusUtils.getPlanetStatusDescription(this.planet.status);
      this.cssClass = PlanetStatusUtils.getPlanetStatusCssClass(this.planet.status);
    }
  }

  onPlanetClick(name: string): void {
    this.router.navigate(['/planet', name], { relativeTo: this.route });
  }
}
