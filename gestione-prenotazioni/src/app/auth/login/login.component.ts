import { Component } from "@angular/core";
import { NgForm } from '@angular/forms';

import * as fromApp from '../../store/app.reducers';
import { Store } from "@ngrx/store";

import * as AuthActions from '../store/auth.actions';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html'
})
export class LoginComponent{

    constructor(private store: Store<fromApp.AppState>){}

    onLogin(form: NgForm){;
        const email = form.value.email;
        const password = form.value.password;
        this.store.dispatch(new AuthActions.TryLogin({email, password}))
    }

}
