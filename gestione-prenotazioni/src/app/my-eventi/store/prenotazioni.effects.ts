import { Prenotazione } from './../../models/prenotazione.model';
import { HttpClient, HttpRequest } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Effect, Actions } from '@ngrx/effects'
import { map, switchMap } from 'rxjs/operators';

import * as PrenotazioniActions from './prenotazioni.actions';

@Injectable()
export class PrenotazioniEffects {
    
    constructor(private actions$: Actions,
        private http: HttpClient){}

    @Effect()
    setPrenotazione = this.actions$.ofType(PrenotazioniActions.TRY_SET_PRENOTAZIONE).pipe(
        map((action: PrenotazioniActions.TrySetPrenotazione) => {
            return action.payload;
        }),
        switchMap((pren: Prenotazione) => {
            return this.http.post<Prenotazione>('http://localhost:57699/api/prenotazioni/set', pren);
        }),
        map((addedPren: Prenotazione) => {
            console.log(addedPren);
            return{
                type: PrenotazioniActions.SET_PRENOTAZIONE,
                payload: addedPren
            }
        })
    )

    @Effect()
    getPrenotazioni = this.actions$.ofType(PrenotazioniActions.TRY_GET_PRENOTAZIONI).pipe(
        map((action: PrenotazioniActions.TryGetPrenotazioni) => {
            return action.payload;
        }),
        switchMap((idPren: Prenotazione) => {
            return this.http.get<Prenotazione[]>('http://localhost:57699/api/prenotazioni/get/'+idPren);
        }),
        map((prenotazioni: Prenotazione[]) => {
            return{
                type: PrenotazioniActions.GET_PRENOTAZIONI,
                payload: prenotazioni
            }
        })
    )

}