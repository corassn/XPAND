import { Component, OnInit } from '@angular/core';
import { PlantesFacade } from '../../core/planets.facade';

@Component({
  selector: 'planets-list',
  templateUrl: './planets-list.component.html',
  styleUrl: './planets-list.component.scss'
})
export class PlanetsListComponent implements OnInit {
  planets$ = this.planetsFacade.planets$;

  constructor(private planetsFacade: PlantesFacade) { }

  ngOnInit(): void {
    this.planetsFacade.getPlanets();
  }
}
