import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Planet } from '../../../_interfaces/planet.interface';
import { PlanetsFacade } from '../../../../core/planets.facade';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-edit-planet',
  templateUrl: './edit-planet.component.html',
  styleUrl: './edit-planet.component.scss'
})
export class EditPlanetComponent implements OnInit, OnDestroy {
  planet?: Planet;

  subscription: Subscription = new Subscription();

  constructor(
    private route: ActivatedRoute,
    private planetsFacade: PlanetsFacade,) { }

  ngOnInit(): void {
    this.getPlanet();
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  getPlanet(): void {
    const planetId = this.route.snapshot.paramMap.get('id');

    this.subscription.add(this.planetsFacade.planets$.subscribe((planets) => {
      this.planet = planets?.find((p) => p.id == planetId);
    }));
  }
}
