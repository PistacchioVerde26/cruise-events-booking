using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionePrenotazioni.Models {
    public class Evento {

        public int ID { get; set; }
        public string Titolo { get; set; }
        public string ImagePath { get; set; }

        public int IDLocale { get; set; }
        public Locale Locale { get; set; }

    }
}