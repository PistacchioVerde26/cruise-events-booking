import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';

import * as fromApp from '../store/app.reducers';
import * as fromPrenotazioni from './store/prenotazioni.reducers';
import { Observable } from 'rxjs';
import { Prenotazione } from '../models/prenotazione.model';

@Component({
  selector: 'app-my-eventi',
  templateUrl: './my-eventi.component.html',
  styleUrls: ['./my-eventi.component.css']
})
export class MyEventiComponent implements OnInit {

  prenotazioniState: Observable<fromPrenotazioni.State>

  constructor(private store: Store<fromApp.AppState>) { }

  ngOnInit() {
    this.prenotazioniState = this.store.select('prenotazioni');
  }

}
