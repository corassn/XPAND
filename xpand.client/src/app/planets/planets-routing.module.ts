import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { PlanetsListComponent } from "./planets-list/planets-list.component";
import { PlanetComponent } from "./planets-list/planet/planet.component";
import { AddPlanetComponent } from "./add-planet/add-planet.component";
import { EditPlanetComponent } from "./planets-list/planet/edit-planet/edit-planet.component";

const routes: Routes = [
  {
    path: 'planets',
    component: PlanetsListComponent,
  },
  {
    path: 'planets/add',
    component: AddPlanetComponent,
  },
  {
    path: 'planet/:id/:name',
    component: PlanetComponent,
  },
  {
    path: 'planet/:id/:name/edit',
    component: EditPlanetComponent,
  },
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PlanetsRoutingModule { }