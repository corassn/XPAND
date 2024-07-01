import { Component, OnInit } from '@angular/core';
import { Planet } from '../../_interfaces/planet.interface';
import { ActivatedRoute } from '@angular/router';
import { PlanetService } from '../../../_services/planet.service';
import { PlanetStatusUtils } from '../../_utils/planet-status.utils';

@Component({
  selector: 'planet',
  templateUrl: './planet.component.html',
  styleUrl: './planet.component.scss'
})
export class PlanetComponent implements OnInit {
  planet?: Planet;
  noneText = 'none';
  noDescriptionText = 'No description yet!';
  status: string = '';
  cssClass: string = '';
  //a loading spinner would be great as future improvement

  constructor(private route: ActivatedRoute, private planetService: PlanetService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const planetId = params.get('id');
      if (planetId) {
        this.getPlanet(planetId);
      }
    });
  }

  getPlanet(id: string): void {
    this.planetService.getPlanetById(id).subscribe({
      next: result => {
        this.planet = result;
        this.status = PlanetStatusUtils.getPlanetStatusDescription(this.planet.status);
        this.cssClass = PlanetStatusUtils.getPlanetStatusCssClass(this.planet.status);
      },
      error: error => {
        console.error('Error fetching planet: ', error);
      }
    });
  }
}
