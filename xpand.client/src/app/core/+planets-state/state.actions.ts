import { createAction, props } from "@ngrx/store";
import { GET_PLANETS, GET_PLANETS_ERROR, GET_PLANETS_SUCCESS } from "../_constants/ngrx.constants";
import { Planet } from "../../planets/_interfaces/planet.interface";

export const getPlanets = createAction(GET_PLANETS);
export const getPlanetsSuccess = createAction(GET_PLANETS_SUCCESS, props<{ planets: Planet[]}>());
export const getPlanetsError = createAction(GET_PLANETS_ERROR, props<{ error: string}>());