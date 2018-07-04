import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Effect, Actions } from '@ngrx/effects'
import { map, switchMap } from 'rxjs/operators';

import * as AuthActions from './auth.actions';
import { Router } from '@angular/router';

@Injectable()
export class AuthEffects {

    constructor(private actions$: Actions,
        private http: HttpClient,
        private router: Router) { }

    @Effect()
    authLogin = this.actions$.ofType(AuthActions.TRY_LOGIN).pipe(
        map((action: AuthActions.TryLogin) => {
            return action.payload;
        }),
        switchMap((authData: { email: string, password: string }) => {
            const authString = `userName=${authData.email}&password=${authData.password}&grant_type=password`;
            return this.http.post('http://localhost:57699/token', authString);
        }),
        map((response) => {
            this.router.navigate(['/']);
            return {
                type: AuthActions.LOGIN,
                payload: response
            }
        })
    )

}