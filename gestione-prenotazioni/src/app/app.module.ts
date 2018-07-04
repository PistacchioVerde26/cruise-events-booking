import { PrenotazioniEffects } from './my-eventi/store/prenotazioni.effects';
import { AuthEffects } from './auth/store/auth.effects';
import { reducers } from './store/app.reducers';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { AppRouterModule } from './app-router.module';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './auth/login/login.component';
import { ReplicheListComponent } from './home/repliche-list/repliche-list.component';
import { ReplicaComponent } from './home/repliche-list/replica/replica.component';
import { MyEventiComponent } from './my-eventi/my-eventi.component';
import { StoreModule } from '@ngrx/store';
import { FormsModule } from '@angular/forms';
import { EffectsModule } from '@ngrx/effects';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReplicheEffects } from './home/repliche-list/store/repliche.effects';
import { AuthGuard } from './auth/auth-guard.service';
import { AuthInterceptor } from './auth/auth.interceptor';
import { PrenotazioneComponent } from './my-eventi/prenotazione/prenotazione.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    LoginComponent,
    ReplicheListComponent,
    ReplicaComponent,
    MyEventiComponent,
    PrenotazioneComponent
  ],
  imports: [
    BrowserModule,
    AppRouterModule,
    FormsModule,
    HttpClientModule,
    StoreModule.forRoot(reducers),
    EffectsModule.forRoot([AuthEffects, ReplicheEffects, PrenotazioniEffects])
  ],
  providers: [AuthGuard, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
