import { Component, Input } from '@angular/core';
import { Planet } from '../../_interfaces/planet.interface';

@Component({
  selector: 'planet',
  templateUrl: './planet.component.html',
  styleUrl: './planet.component.scss'
})
export class PlanetComponent {
  @Input() planet?: Planet;
}
