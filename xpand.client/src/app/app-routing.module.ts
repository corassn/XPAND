import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PlanetsModule } from '../app/planets/planets.module';
import { AuthModule } from './auth/auth.module';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'planets',
  },
  {
    path: 'planets',
    loadChildren: () => import('../app/planets/planets.module').then(m => m.PlanetsModule)
  },
  {
    path: 'login',
    loadChildren: () => import('../app/auth/auth.module').then(m => m.AuthModule)
  },
  { path: '**', redirectTo: 'planets' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [
    RouterModule,
    PlanetsModule
  ]
})
export class AppRoutingModule { }
