import * as AuthActions from './auth.actions';
import { Utente } from './../../models/utente.model';

export interface State{
    token: string,
    authenticated: boolean,
    utente: Utente
}

const initialState = {
    token: null,
    authenticated: false,
    utente: null
}

export function authReducer(state = initialState, action: AuthActions.AuthActions){
    switch(action.type){
        case AuthActions.LOGIN:
            const user = new Utente(
                action.payload.ID,
                action.payload.cognome,
                action.payload.nome,
                action.payload.telefono,
                action.payload.email,
                action.payload.password
            )
            return {
                ...state,
                authenticated: true,
                token: action.payload.access_token,
                utente: user
            }
        case AuthActions.LOGOUT:
            return {
                ...state,
                authenticated: false,
                token: null,
                utente: null
            }
        default:
            return state;
    }
}