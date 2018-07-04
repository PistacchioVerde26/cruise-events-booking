import { Component, OnInit, OnDestroy } from '@angular/core';

import * as fromApp from './store/app.reducers';
import * as fromAuth from './auth/store/auth.reducers';
import * as ReplicheActions from './home/repliche-list/store/repliche.actions';
import * as PrenotazioniActions from './my-eventi/store/prenotazioni.actions';
import { Store } from '@ngrx/store';
import { Subscription } from 'rxjs';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy {

  title = 'app';
  authenticated: boolean = false;
  UID: number;
  authSubscription: Subscription;

  constructor(private store: Store<fromApp.AppState>) { }

  ngOnInit() {
    //Recupero gli eventi prenotabili
    this.store.dispatch(new ReplicheActions.TryGetRepliche());
    //Controllo lo stato di autenticazione
    this.authSubscription = this.store.select('auth').subscribe((state: fromAuth.State) => {
      this.authenticated = state.authenticated;
      if (this.authenticated) {
        this.UID = state.utente.id;
        this.store.dispatch(new PrenotazioniActions.TryGetPrenotazioni(this.UID));
      }

    })
  }

  ngOnDestroy() {
    this.authSubscription.unsubscribe();
  }

}
