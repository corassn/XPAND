import { PlanetStatus } from "../../../../openapi";
import { EN_ROUTE, NOT_OK, OK, TO_DO } from "../_constants/planet.constants";

export class PlanetStatusUtils {
    static getPlanetStatusDescription(status: PlanetStatus): string {
        switch(status) {
            case PlanetStatus.EnRoute:
                return EN_ROUTE;
            case PlanetStatus.ToDo:
                return TO_DO;
            case PlanetStatus.OK:
                return OK;
            case PlanetStatus.Not_OK:
                return NOT_OK;
        }
    }

    static getPlanetStatusCssClass(status: PlanetStatus): string {
        switch(status) {
            case PlanetStatus.EnRoute:
                return 'blue';
            case PlanetStatus.ToDo:
                return 'grey';
            case PlanetStatus.OK:
                return 'green';
            case PlanetStatus.Not_OK:
                return 'red';
        }
    }
}