using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionePrenotazioni.Models {
    public class Prenotazione {

        public int ID { get; set; }
        public int Biglietti { get; set; }
        public Int64 Data { get; set; }
        public int IDUtente { get; set; }

        public int IDReplica { get; set; }
        public Replica Replica { get; set; }

    }
}