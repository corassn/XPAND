import { Component, OnDestroy } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';
import { PLANET_STATUSES } from '../_utils/planet-status.utils';
import { AddPlanet } from '../_interfaces/add-planet.interface';
import { PlanetStatus } from '../../../../openapi';
import { PlanetService } from '../../shared/_services/planet.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-add-planet',
  templateUrl: './add-planet.component.html',
  styleUrl: './add-planet.component.scss'
})
export class AddPlanetComponent implements OnDestroy {
  planetStatuses = PLANET_STATUSES;

  subscription: Subscription = new Subscription();

  constructor(private planetService: PlanetService, private location: Location) {
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  submitForm(form: NgForm): void {
    if (form.invalid) {
      form.reset();
      return;
    }

    const addRequest: AddPlanet = {
      name: form.value.name,
      status: form.value.status || PlanetStatus.ToDo,
      description: form.value.description,
      teamId: ''
    }

    this.subscription.add(
      this.planetService.addPlanet(addRequest).subscribe({
        next: () => {
          this.navigateBack();
        },
        error: error => {
          console.error('Error while updating planet: ', error);
          this.navigateBack();
        }
      })
    );
  }

  cancelAdd(): void {
    this.navigateBack();
  }

  navigateBack(): void {
    this.location.back();
  }
}
