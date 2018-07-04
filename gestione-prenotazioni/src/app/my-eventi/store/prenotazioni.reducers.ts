import { Prenotazione } from './../../models/prenotazione.model';

import * as PrenotazioniActions from './prenotazioni.actions';

export interface State {
    prenotazioni: Prenotazione[]
}

const initialState = {
    prenotazioni: []
}

export function prenotazioniReducer(state=initialState, action: PrenotazioniActions.PrenotazioniActions){
    switch(action.type){
        case PrenotazioniActions.SET_PRENOTAZIONE:
            return {
                state,
                prenotazioni: [...state.prenotazioni, action.payload]
            }
        case PrenotazioniActions.GET_PRENOTAZIONI:
            return{
                state,
                prenotazioni: action.payload
            }
        default:
            return state;
    }
}