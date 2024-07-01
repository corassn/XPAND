import { Injectable } from "@angular/core";
import { BaseApiService } from "./base-api.service";
import { PlanetService as PlanetApi } from './../../../openapi/api/planet.service';
import { Observable, catchError } from "rxjs";
import { AddPlanetDto, PlanetDto, UpdatePlanetDto } from "../../../openapi";
import { environment } from "../../environments/environment";
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root',
})
export class PlanetService extends BaseApiService {
    constructor(private planetApi: PlanetApi, private http: HttpClient) {
        super();
    }

    private apiUrl = `${environment.apiUrl}/planets`

    getPlanetById(id: string): Observable<PlanetDto> {
        return this.planetApi.apiPlanetsIdGet(id).pipe(catchError((error) => this.handleError(error)));
    }

    getPlanets(): Observable<Array<PlanetDto>> {
        return this.planetApi.apiPlanetsGet().pipe(catchError((error) => this.handleError(error)));
        //return this.http.get<PlanetDto[]>(this.apiUrl);
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