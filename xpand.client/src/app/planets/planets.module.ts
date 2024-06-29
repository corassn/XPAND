import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlanetComponent } from './planets-list/planet/planet.component';
import { PlanetsListComponent } from './planets-list/planets-list.component';
import { PlanetCardComponent } from './planets-list/planet-card/planet-card.component';
import { RouterModule } from '@angular/router';
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
