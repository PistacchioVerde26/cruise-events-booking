import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { Component, OnInit, Input } from '@angular/core';

import * as fromApp from '../../../store/app.reducers';
import * as fromAuth from '../../../auth/store/auth.reducers';
import * as PrenotazioniActions from '../../../my-eventi/store/prenotazioni.actions'
import { Store } from '@ngrx/store';
import { Utente } from '../../../models/utente.model';
import { Prenotazione } from './../../../models/prenotazione.model';
import { Replica } from '../../../models/replica.model';

@Component({
  selector: 'app-replica',
  templateUrl: './replica.component.html',
  styleUrls: ['./replica.component.css']
})
export class ReplicaComponent implements OnInit {

  @Input() replica: Replica;
  authState: Observable<fromAuth.State>;

  constructor(private store: Store<fromApp.AppState>) { }

  ngOnInit() {
    this.authState = this.store.select('auth');
  }

  onSubmit(form: NgForm) {
    const biglietti = form.value.biglietti;

    if (biglietti > 0) {
      let user: Utente;
      const subs = this.authState.subscribe(state => {
        return user = state.utente;
      })

      const newPren = new Prenotazione(-1, biglietti, -1, user.id, user, this.replica.id);
      this.store.dispatch(new PrenotazioniActions.TrySetPrenotazione(newPren));

      subs.unsubscribe();
    }
  }

}
