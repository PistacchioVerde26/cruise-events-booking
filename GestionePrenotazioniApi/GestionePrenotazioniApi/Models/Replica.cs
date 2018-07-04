using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionePrenotazioni.Models {
    public class Replica {

        public int ID { get; set; }
        public Int64 Data { get; set; }
        public bool Annullato { get; set; }
        
        public int PostiOccupati { get; set; }

        public int IDEvento { get; set; }
        public Evento Evento { get; set; }

    }
}