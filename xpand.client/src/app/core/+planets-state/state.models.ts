import { Planet } from "../../planets/_interfaces/planet.interface";

export interface PlanetsState {
    planets?: Planet[];
    isLoadingPlanets: boolean;
    errorLoadingPlanets?: string;
}