import { Component, Input } from "@angular/core";
import { Prenotazione } from "../../models/prenotazione.model";

@Component({
    selector: 'app-prenotazione',
    templateUrl: './prenotazione.component.html'
})
export class PrenotazioneComponent{

    @Input() prenotazione: Prenotazione;

}