import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromStore from '../../store/app.reducers';
import * as fromRepliche from './store/repliche.reducers';
import * as ReplicheActions from './store/repliche.actions';

@Component({
  selector: 'app-repliche-list',
  templateUrl: './repliche-list.component.html',
  styleUrls: ['./repliche-list.component.css']
})
export class ReplicheListComponent implements OnInit {

  replicheState: Observable<fromRepliche.State>;

  constructor(private store: Store<fromStore.AppState>) { }

  ngOnInit() {
    this.replicheState = this.store.select('repliche');
  }

}
