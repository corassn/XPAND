import { Action, createReducer, on } from "@ngrx/store";
import { PlanetsState } from "./state.models";
import * as StateActions from './state.actions';

export const initialPlanetsState: PlanetsState = {
    planets: [],
    isLoadingPlanets: false,
    errorLoadingPlanets: undefined,
}

export const stateReducer = createReducer(
    initialPlanetsState,
    on(StateActions.getPlanets, state => ({ ...state, isLoadingPlanets: true })),
    on(StateActions.getPlanetsSuccess, (state, { planets }) => ({
        ...state,
        isLoadingPlanets: false,
        planets
    })),
    on(StateActions.getPlanetsError, (state, { error }) => ({
        ...state,
        isLoadingPlanets: false,
        errorLoadingPlanets: error
    })),
);

export function planetsReducer(state: PlanetsState | undefined, action: Action) {
    return stateReducer(state, action);
}