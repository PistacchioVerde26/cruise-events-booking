import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Effect, Actions } from '@ngrx/effects'
import { map, switchMap } from 'rxjs/operators';

import * as ReplicheActions from './repliche.actions';
import { Replica } from '../../../models/replica.model';

@Injectable()
export class ReplicheEffects {

    constructor(private actions$: Actions,
                private http: HttpClient){}

    @Effect()
    getRepliche = this.actions$.ofType(ReplicheActions.TRY_GET_REPLICHE).pipe(
        switchMap((action: ReplicheActions.TryGetRepliche) => {
            return this.http.get<Replica[]>('http://localhost:57699/api/repliche/bytime');
        }),
        map((repliche: Replica[]) => {
            return {
                type: ReplicheActions.GET_REPLICHE,
                payload: repliche
            }
        })
    )

}