import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-add-planet',
  templateUrl: './add-planet.component.html',
  styleUrl: './add-planet.component.scss'
})
export class AddPlanetComponent {

  submitForm(form: NgForm): void {
    // const updateRequest: UpdatePlanet = {
    //   planetId: this.planet?.id || '',
    //   status: form.value.status || PlanetStatus.ToDo,
    //   description: form.value.description,
    //   teamId: ''
    // }

    // this.subscription.add(
    //   this.planetService.updatePlanet(this.planetId, updateRequest).subscribe({
    //     next: () => {
    //       this.navigateBack();
    //     },
    //     error: error => {
    //       console.error('Error while updating planet: ', error);
    //       this.navigateBack();
    //     }
    //   })
    // )
  }
}
