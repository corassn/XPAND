import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { Observable } from "rxjs";
import { Planet } from "../planets/_interfaces/planet.interface";
import * as StateActions from './+planets-state/state.actions';
import { selectPlanets, selectPlanetsError, selectPlanetsLoading } from "./+planets-state/state.selectors";

@Injectable({ providedIn: 'root' })
export class PlantesFacade {
    constructor(private readonly store: Store) { }

    planets$: Observable<Planet[] | undefined> = this.store.select(selectPlanets);
    isLoadingPlanets$: Observable<boolean> = this.store.select(selectPlanetsLoading);
    errorLoadingPlanets$: Observable<string | undefined> = this.store.select(selectPlanetsError);

    getPlanets(): void {
        this.store.dispatch(StateActions.getPlanets());
    }
}
