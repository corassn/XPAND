import { PlanetDto } from "../../../../openapi";
import { Planet } from "../../planets/_interfaces/planet.interface";

export interface PlanetsState {
    planets?: PlanetDto[];
    isLoadingPlanets: boolean;
    errorLoadingPlanets?: string;
}