import { PlanetStatus } from "../../../../openapi";
import { BLUE_CSS_CLASS, EN_ROUTE, GREEN_CSS_CLASS, GREY_CSS_CLASS, NOT_OK, OK, RED_CSS_CLASS, TO_DO } from "../_constants/planet.constants";

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
                return BLUE_CSS_CLASS;
            case PlanetStatus.ToDo:
                return GREY_CSS_CLASS;
            case PlanetStatus.OK:
                return GREEN_CSS_CLASS;
            case PlanetStatus.Not_OK:
                return RED_CSS_CLASS;
        }
    }
}

export const PLANET_STATUSES: { key: number, value: string }[] = [
    { key: PlanetStatus.ToDo, value: PlanetStatusUtils.getPlanetStatusDescription(PlanetStatus.ToDo) },
    { key: PlanetStatus.EnRoute, value: PlanetStatusUtils.getPlanetStatusDescription(PlanetStatus.EnRoute) },
    { key: PlanetStatus.OK, value: PlanetStatusUtils.getPlanetStatusDescription(PlanetStatus.OK) },
    { key: PlanetStatus.Not_OK, value: PlanetStatusUtils.getPlanetStatusDescription(PlanetStatus.Not_OK) }
  ]