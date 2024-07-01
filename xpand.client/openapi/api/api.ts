export * from './planet.service';
import { PlanetService } from './planet.service';
export * from './team.service';
import { TeamService } from './team.service';
export const APIS = [PlanetService, TeamService];
