import { Injectable } from "@angular/core";
import { BaseApiService } from "./base-api.service";
import { TeamService as TeamApi } from "../../../../openapi";
import { Observable, catchError } from "rxjs";
import { Captain } from "../../_interfaces/captain.interface";
import { Robot } from "../../_interfaces/robot.interface";

@Injectable({
    providedIn: 'root',
})
export class TeamService extends BaseApiService {
    constructor(private teamApi: TeamApi) {
        super();
    }

    getCaptainByTeamId(id: string): Observable<Captain> {
        return this.teamApi.apiTeamIdCaptainGet(id).pipe(catchError((error) => this.handleError(error)));
    }

    getRobotsByTeamId(id: string): Observable<Array<Robot>> {
        return this.teamApi.apiTeamIdRobotsGet(id).pipe(catchError((error) => this.handleError(error)));
    }
}