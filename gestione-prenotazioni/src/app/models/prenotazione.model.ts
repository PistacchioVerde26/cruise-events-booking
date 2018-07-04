import { Utente } from "./utente.model";

export class Prenotazione{

    constructor(
        public ID: number,
        public biglietti: number,
        public data: number,
        public IDUtente: number,
        public utente: Utente,
        public IDReplica?: number
    ){}

}