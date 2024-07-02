import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { PlanetComponent } from './planets-list/planet/planet.component';
import { PlanetsListComponent } from './planets-list/planets-list.component';
import { PlanetCardComponent } from './planets-list/planet-card/planet-card.component';
import { PlanetsRoutingModule } from './planets-routing.module';
import { AddPlanetComponent } from './add-planet/add-planet.component';
import { EditPlanetComponent } from './planets-list/planet/edit-planet/edit-planet.component';

@NgModule({
  declarations: [
    PlanetComponent,
    PlanetsListComponent,
    PlanetCardComponent,
    AddPlanetComponent,
    EditPlanetComponent
  ],
  imports: [
    CommonModule,
    PlanetsRoutingModule,
    MatCardModule,
    MatButtonModule,
    FormsModule,
    ReactiveFormsModule,
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
