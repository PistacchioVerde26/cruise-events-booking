using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionePrenotazioni.Models {
    public class Locale {

        public int ID { get; set; }
        public string Nome { get; set; }
        public string Luogo { get; set; }
        public int Posti { get; set; }

    }
}