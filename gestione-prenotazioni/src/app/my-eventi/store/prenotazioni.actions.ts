import { Prenotazione } from './../../models/prenotazione.model';
import { Action } from '@ngrx/store';

export const TRY_GET_PRENOTAZIONI = 'TRY_GET_PRENOTAZIONI';
export const GET_PRENOTAZIONI = 'GET_PRENOTAZIONI';
export const TRY_SET_PRENOTAZIONE = 'TRY_SET_PRENOTAZIONE';
export const SET_PRENOTAZIONE = 'SET_PRENOTAZIONE';
export const UPDATE_PRENOTAZIONE = 'UPDATE_PRENOTAZIONE';

export class TryGetPrenotazioni implements Action {
    readonly type = TRY_GET_PRENOTAZIONI;
    constructor(public payload: number) { }
}

export class GetPrenotazioni implements Action {
    readonly type = GET_PRENOTAZIONI;
    constructor(public payload: Prenotazione[]) { }
}

export class TrySetPrenotazione implements Action {
    readonly type = TRY_SET_PRENOTAZIONE;
    constructor(public payload: Prenotazione) { }
}

export class SetPrenotazione implements Action {
    readonly type = SET_PRENOTAZIONE;
    constructor(public payload: Prenotazione) { }
}

export class UpdatePrenotazione implements Action {
    readonly type = UPDATE_PRENOTAZIONE;
    constructor(public payload: { idUtente: number, prenotazione: Prenotazione }) { }
}

export type PrenotazioniActions = TryGetPrenotazioni |
    GetPrenotazioni |
    TrySetPrenotazione |
    SetPrenotazione |
    UpdatePrenotazione;

