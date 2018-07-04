import { Evento } from "./evento.model";

export class Replica{

    constructor(
        public id: number,
        public data,
        public annullato: boolean,
        public postiOccupati: number,
        public IdEvento: number,
        public evento: Evento
    ){
        this.data = new Date(this.data * 1000).toDateString();
        console.log(this);
    }

}