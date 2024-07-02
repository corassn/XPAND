import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Planet } from '../../../_interfaces/planet.interface';
import { Subscription } from 'rxjs';
import { NgForm } from '@angular/forms';
import { UpdatePlanet } from '../../../_interfaces/update-planet.interface';
import { Location } from '@angular/common';
import { PlanetService } from '../../../../shared/_services/planet.service';
import { PlanetStatus } from '../../../../../../openapi';
import { PLANET_STATUSES } from '../../../_utils/planet-status.utils';

@Component({
  selector: 'app-edit-planet',
  templateUrl: './edit-planet.component.html',
  styleUrl: './edit-planet.component.scss'
})
export class EditPlanetComponent implements OnInit, OnDestroy {
  planet?: Planet;
  planetId: string = '';
  planetStatuses = PLANET_STATUSES;
  subscription: Subscription = new Subscription();

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private location: Location,
    private planetService: PlanetService) { }

  ngOnInit(): void {
    this.getPlanet();
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  getPlanet(): void {
    const planetId = this.route.snapshot.paramMap.get('id');

    if (!planetId) {
      return;
    }

    this.subscription.add(
      this.planetService.getPlanetById(planetId).subscribe({
        next: result => {
          this.planet = result;
          this.planetId = result.id;
        },
        error: error => {
          console.error('Error while fetching planet: ', error);
        }
      })
    );
  }

  submitForm(form: NgForm): void {
    const updateRequest: UpdatePlanet = {
      planetId: this.planet?.id || '',
      status: form.value.status || PlanetStatus.ToDo,
      description: form.value.description,
      teamId: ''
    }

    this.subscription.add(
      this.planetService.updatePlanet(this.planetId, updateRequest).subscribe({
        next: () => {
          this.navigateBack();
        },
        error: error => {
          console.error('Error while updating planet: ', error);
          this.navigateBack();
        }
      })
    )
  }

  cancelEdit(): void {
    this.navigateBack();
  }

  navigateBack(): void {
    this.location.back();
  }
}
