import { Injectable } from "@angular/core";
import { BaseApiService } from "./base-api.service";
import { PlanetService as PlanetApi } from './../../../openapi/api/planet.service';
import { Observable, catchError } from "rxjs";
import { Planet } from "../planets/_interfaces/planet.interface";
import { AddPlanet } from "../planets/_interfaces/add-planet.interface";
import { UpdatePlanet } from "../planets/_interfaces/update-planet.interface";

@Injectable({
    providedIn: 'root',
})
export class PlanetService extends BaseApiService {
    constructor(private planetApi: PlanetApi) {
        super();
    }

    getPlanetById(id: string): Observable<Planet> {
        return this.planetApi.apiPlanetsIdGet(id).pipe(catchError((error) => this.handleError(error)));
    }

    getPlanets(): Observable<Array<Planet>> {
        return this.planetApi.apiPlanetsGet().pipe(catchError((error) => this.handleError(error)));
    }

    deletePlanet(id: string): Observable<Planet> {
        return this.planetApi.apiPlanetsIdDelete(id).pipe(catchError((error) => this.handleError(error)));
    }

    addPlanet(request: AddPlanet): Observable<Planet> {
        return this.planetApi.apiPlanetsPost(request).pipe(catchError((error) => this.handleError(error)));
    }

    updatePlanet(request: UpdatePlanet): Observable<Planet> {
        return this.planetApi.apiPlanetsPut(request).pipe(catchError((error) => this.handleError(error)));
    }
}