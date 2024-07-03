import { provideHttpClient } from '@angular/common/http';
import { NgModule, isDevMode } from '@angular/core';
import { BrowserModule, DomSanitizer } from '@angular/platform-browser';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { MatIconModule, MatIconRegistry } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PlanetsModule } from './planets/planets.module';
import { HeaderComponent } from './header/header.component';
import { CoreModule } from './core/core.module';
import { UserMenuComponent } from './header/user-menu/user-menu.component';
import { SharedModule } from './shared/shared.module';
import { AuthModule } from './auth/auth.module';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    UserMenuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    PlanetsModule,
    CoreModule,
    MatIconModule,
    MatButtonModule,
    MatMenuModule,
    BrowserAnimationsModule,
    SharedModule,
    AuthModule,
    StoreModule.forRoot({}, {}),
    EffectsModule.forRoot([]),
    StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: !isDevMode() }),
  ],
  providers: [
    provideHttpClient(),
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(private matIconRegistry: MatIconRegistry, private domSanitizer: DomSanitizer) {
    this.matIconRegistry.addSvgIcon(`chevron-down`, this.domSanitizer.bypassSecurityTrustResourceUrl('./assets/images/chevron-down.svg'));
    this.matIconRegistry.addSvgIcon(`chevron-left`, this.domSanitizer.bypassSecurityTrustResourceUrl('./assets/images/chevron-left.svg'));
    this.matIconRegistry.addSvgIcon(`more-vert`, this.domSanitizer.bypassSecurityTrustResourceUrl('./assets/images/more-vert.svg'));
  }
}
