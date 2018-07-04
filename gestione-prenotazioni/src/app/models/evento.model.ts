import { Locale } from "./locale.model";

export class Evento{
    constructor(
        public ID: number,
        public titolo: string,
        public descrizione: string,
        public imagePath: string,
        public IDLocale: number,
        public locale: Locale
    ){}
}
