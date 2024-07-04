import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PlanetsModule } from '../app/planets/planets.module';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {
    path: 'planets',
    loadChildren: () => import('../app/planets/planets.module').then(m => m.PlanetsModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'login',
    loadChildren: () => import('../app/auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: '**',
    redirectTo: 'planets',
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [
    RouterModule,
    PlanetsModule
  ]
})
export class AppRoutingModule { }
