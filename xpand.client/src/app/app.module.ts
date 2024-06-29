import { HttpClientModule, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PlanetsListComponent } from './planets-list/planets-list.component';
import { HeaderComponent } from './header/header.component';
import { PlanetCardComponent } from './planets-list/planet-card/planet-card.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { PlanetComponent } from './planet/planet.component';

@NgModule({
  declarations: [
    AppComponent,
    PlanetsListComponent,
    PlanetComponent,
    HeaderComponent,
    PlanetCardComponent
  ],
  imports: [
    BrowserModule, 
    AppRoutingModule
  ],
  providers: [
    provideHttpClient(),
    provideAnimationsAsync('noop')
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
