import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { CORE_FEATURE_NAME, PLANETS_FEATURE_NAME } from './_constants/ngrx-constants';
import { CoreStateEffects } from './+state/state.effects';
import { PlanetsStateEffects } from './+planets-state/state.effects';
import { planetsReducer } from './+planets-state/state.reducer';
import { coreReducer } from './+state/state.reducer';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    StoreModule.forFeature(CORE_FEATURE_NAME, coreReducer),
    EffectsModule.forFeature([CoreStateEffects]),
    StoreModule.forFeature(PLANETS_FEATURE_NAME, planetsReducer),
    EffectsModule.forFeature([PlanetsStateEffects]),
  ]
})
export class CoreModule { }
