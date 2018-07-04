import { Action } from '@ngrx/store';

import { Replica } from '../../../models/replica.model';

export const TRY_GET_REPLICHE = 'TRY_GET_REPLICHE';
export const GET_REPLICHE = 'GET_REPLICHE';

export class GetRepliche implements Action{
    readonly type = GET_REPLICHE;
    constructor(public payload: Replica[]){}
}

export class TryGetRepliche implements Action{
    readonly type = TRY_GET_REPLICHE;
}

export type ReplicheActions = GetRepliche | TryGetRepliche;