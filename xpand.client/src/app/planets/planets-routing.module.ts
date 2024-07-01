import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { PlanetsListComponent } from "./planets-list/planets-list.component";
import { PlanetComponent } from "./planets-list/planet/planet.component";

const routes: Routes = [
  {
    path: '',
    component: PlanetsListComponent,
  },
  {
    path: 'planets',
    component: PlanetsListComponent,
  },
  {
    path: 'planet/:id/:name',
    component: PlanetComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PlanetsRoutingModule { }