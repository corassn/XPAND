import { Component, OnDestroy, OnInit } from '@angular/core';
import { Planet } from '../../_interfaces/planet.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { PlanetService } from '../../../shared/_services/planet.service';
import { PlanetStatusUtils } from '../../_utils/planet-status.utils';
import { TeamService } from '../../../shared/_services/team.service';
import { Subscription } from 'rxjs';
import { PlanetsFacade } from '../../../core/planets.facade';

@Component({
  selector: 'planet',
  templateUrl: './planet.component.html',
  styleUrl: './planet.component.scss'
})
export class PlanetComponent implements OnInit, OnDestroy {
  planet?: Planet;
  noneText = 'none';
  noDescriptionText = 'No description yet!';
  status: string = '';
  cssClass: string = '';
  robotNames?: string[];
  captainName?: string;
  //a loading spinner would be great as future improvement

  subscription: Subscription = new Subscription();

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private planetService: PlanetService,
    private teamService: TeamService) { }

  ngOnInit(): void {
    this.getPlanetDetails();
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  getPlanetDetails(): void {
    const planetId = this.route.snapshot.paramMap.get('id');

    if (!planetId) {
      return;
    }

    this.subscription.add(
      this.planetService.getPlanetById(planetId).subscribe({
        next: result => {
          this.planet = result;

          if (this.planet) {
            this.status = PlanetStatusUtils.getPlanetStatusDescription(this.planet.status);
            this.cssClass = PlanetStatusUtils.getPlanetStatusCssClass(this.planet.status);
          }

          if (this.planet?.teamId) {
            this.getRobotsInvolved(this.planet.teamId);
            this.getCaptainInvolved(this.planet.teamId);
          }
        },
        error: error => {
          console.error('Error while fetching planet: ', error);
        }
      })
    );
  }

  getCaptainInvolved(teamId: string): void {
    this.subscription.add(
      this.teamService.getCaptainByTeamId(teamId).subscribe({
        next: result => {
          this.captainName = result.name;
        },
        error: error => {
          console.error('Error fetching the captain: ', error);
        }
      })
    );
  }

  getRobotsInvolved(teamId: string): void {
    this.subscription.add(
      this.teamService.getRobotsByTeamId(teamId).subscribe({
        next: result => {
          this.robotNames = result.map((r) => r.name);
        },
        error: error => {
          console.error('Error fetching the robots: ', error);
        }
      })
    );
  }

  //the delete proces could be managed in the store of the application
  deletePlanet(id: string): void {
    this.subscription.add(
      this.planetService.deletePlanet(id).subscribe({
        next: () => {
          this.router.navigate(['/planets']);
        },
        error: error => {
          console.error('Error deleting planet: ', error);
        }
      })
    );
  }

  navigateToEdit(planet: Planet): void {
    this.router.navigate(['planet', planet.id, planet.name, 'edit']);
  }
}
