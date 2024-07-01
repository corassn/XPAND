import { createFeatureSelector, createSelector } from "@ngrx/store";
import { PlanetsState } from "./state.models";
import { PLANETS_FEATURE_NAME } from "../_constants/ngrx-constants";

export const selectState = createFeatureSelector<PlanetsState>(PLANETS_FEATURE_NAME);

export const selectPlanets = createSelector(
    selectState,
    (state: PlanetsState) => state.planets
);

export const selectPlanetsLoading = createSelector(
    selectState,
    (state: PlanetsState) => state.isLoadingPlanets
);

export const selectPlanetsError = createSelector(
    selectState,
    (state: PlanetsState) => state.errorLoadingPlanets
);