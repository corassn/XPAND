import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { PlanetService } from "../../shared/_services/planet.service";
import * as StateActions from './state.actions';
import { catchError, map, switchMap } from "rxjs";
import { PlanetsState } from "./state.models";
import { Store } from "@ngrx/store";

@Injectable()
export class PlanetsStateEffects {
    constructor(
        private actions$: Actions,
        private planetService: PlanetService,
        private store: Store<PlanetsState>,
    ) { }

    planets$ = createEffect(() =>
        this.actions$.pipe(
            ofType(StateActions.getPlanets),
            switchMap(() => {
                return this.planetService
                    .getPlanets()
                    .pipe(map((response) => StateActions.getPlanetsSuccess({ planets: response })));
            }),
            catchError((error, caught) => {
                console.log(error);
                this.store.dispatch(StateActions.getPlanetsError({error: error.message }));
                return caught;
            })
        ))
}