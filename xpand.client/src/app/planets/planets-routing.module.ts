import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { PlanetsListComponent } from "./planets-list/planets-list.component";
import { PlanetComponent } from "./planets-list/planet/planet.component";
import { AddPlanetComponent } from "./add-planet/add-planet.component";
import { EditPlanetComponent } from "./planets-list/planet/edit-planet/edit-planet.component";
import { AuthGuard } from "../_guards/auth.guard";

const routes: Routes = [
  { 
    path: '', 
    component: PlanetsListComponent, 
    canActivate: [AuthGuard] 
  },
  {
    path: 'planets',
    component: PlanetsListComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'planets/add',
    component: AddPlanetComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'planet/:id/:name',
    component: PlanetComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'planet/:id/:name/edit',
    component: EditPlanetComponent,
    canActivate: [AuthGuard]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PlanetsRoutingModule { }