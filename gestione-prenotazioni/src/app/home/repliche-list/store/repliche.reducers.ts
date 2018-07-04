import * as ReplicheActions from './repliche.actions';
import { Replica } from "../../../models/replica.model";

export interface State {
    repliche: Replica[];
}

const initialState = {
    repliche: []
}

export function replicheReducer(state = initialState, action: ReplicheActions.ReplicheActions){
    switch(action.type){
        case ReplicheActions.GET_REPLICHE:
            return{
                ...state,
                repliche: [...action.payload]
            }
        default:
            return state;
    }
}

