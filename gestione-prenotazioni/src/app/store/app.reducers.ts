import { ActionReducerMap } from '@ngrx/store';

import * as fromAuth from '../auth/store/auth.reducers';
import * as fromRepliche from '../home/repliche-list/store/repliche.reducers';
import * as fromPrenotazioni from '../my-eventi/store/prenotazioni.reducers';

export interface AppState {
    auth: fromAuth.State,
    repliche: fromRepliche.State,
    prenotazioni: fromPrenotazioni.State
}

export const reducers: ActionReducerMap<AppState> = {
    auth: fromAuth.authReducer,
    repliche: fromRepliche.replicheReducer,
    prenotazioni: fromPrenotazioni.prenotazioniReducer
}