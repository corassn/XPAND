import { Injectable } from "@angular/core";
import { BaseApiService } from "./base-api.service";
import { PlanetService as PlanetApi } from './../../../openapi/api/planet.service';
import { Observable, catchError } from "rxjs";
import { AddPlanetDto, PlanetDto, UpdatePlanetDto } from "../../../openapi";

@Injectable({
    providedIn: 'root',
})
export class PlanetService extends BaseApiService {
    constructor(private planetApi: PlanetApi) {
        super();
    }

    getPlanetById(id: string): Observable<PlanetDto> {
        return this.planetApi.apiPlanetsIdGet(id).pipe(catchError((error) => this.handleError(error)));
    }

    getPlanets(): Observable<Array<PlanetDto>> {
        return this.planetApi.apiPlanetsGet().pipe(catchError((error) => this.handleError(error)));
    }

    deletePlanet(id: string): Observable<PlanetDto> {
        return this.planetApi.apiPlanetsIdDelete(id).pipe(catchError((error) => this.handleError(error)));
    }

    addPlanet(request: AddPlanetDto): Observable<PlanetDto> {
        return this.planetApi.apiPlanetsPost(request).pipe(catchError((error) => this.handleError(error)));
    }

    updatePlanet(request: UpdatePlanetDto): Observable<PlanetDto> {
        return this.planetApi.apiPlanetsPut(request).pipe(catchError((error) => this.handleError(error)));
    }
}