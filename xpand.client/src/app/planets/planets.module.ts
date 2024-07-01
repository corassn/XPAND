import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { RouterModule } from '@angular/router';

import { PlanetComponent } from './planets-list/planet/planet.component';
import { PlanetsListComponent } from './planets-list/planets-list.component';
import { PlanetCardComponent } from './planets-list/planet-card/planet-card.component';
import { PlanetsRoutingModule } from './planets-routing.module';

@NgModule({
  declarations: [
    PlanetComponent,
    PlanetsListComponent,
    PlanetCardComponent
  ],
  imports: [
    CommonModule,
    PlanetsRoutingModule,
    MatCardModule,
    RouterModule.forChild([
      {
        path: '',
        pathMatch: 'full',
        component: PlanetsListComponent,
      },
    ]),
  ],
  exports: [PlanetsRoutingModule]
})
export class PlanetsModule { }
