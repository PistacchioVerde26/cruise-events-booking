import { Prenotazione } from "./prenotazione.model";

export class Utente{

    constructor(
        public id: number,
        public cognome: string,
        public nome: string,
        public telefono: string,
        public email: string,
        public password: string,
        public prenotazioni?: Prenotazione[]
    ){}

}