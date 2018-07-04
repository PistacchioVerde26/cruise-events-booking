﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionePrenotazioni.Models {

    public class Utente {

        public int ID { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Prenotazione> Prenotazioni { get; set; }

    }

}