export * from './account.service';
import { AccountService } from './account.service';
export * from './planet.service';
import { PlanetService } from './planet.service';
export * from './team.service';
import { TeamService } from './team.service';
export const APIS = [AccountService, PlanetService, TeamService];
