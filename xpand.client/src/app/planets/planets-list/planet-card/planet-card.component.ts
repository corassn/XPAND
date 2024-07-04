import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Planet } from '../../_interfaces/planet.interface';
import { Router } from '@angular/router';
import { PlanetStatusUtils } from '../../_utils/planet-status.utils';
import { TeamService } from '../../../shared/_services/team.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'planet-card',
  templateUrl: './planet-card.component.html',
  styleUrl: './planet-card.component.scss'
})
export class PlanetCardComponent implements OnInit, OnDestroy {
  @Input() planet?: Planet;

  noDescriptionText: string = 'No description yet!';
  status: string = '';
  cssClass: string = '';
  captainName?: string;
  robotNames?: string[];

  subscription = new Subscription();

  constructor(private router: Router, private teamService: TeamService) {
  }

  ngOnInit(): void {
    if (this.planet) {
      this.status = PlanetStatusUtils.getPlanetStatusDescription(this.planet.status);
      this.cssClass = PlanetStatusUtils.getPlanetStatusCssClass(this.planet.status);
      this.getCaptainInvolved(this.planet.teamId || '');
      this.getRobotsInvolved(this.planet.teamId || '');
    }
  }

  ngOnDestroy(): void {
      this.subscription.unsubscribe();
  }

  getCaptainInvolved(teamId: string): void {
    if(!teamId) {
      return;
    }

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
    if(!teamId) {
      return;
    }

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

  planetClick(planet: Planet): void {
    this.router.navigate(['planet', planet.id, planet.name]);
  }
}
