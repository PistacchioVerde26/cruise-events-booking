using GestionePrenotazioni.Models;
using GestionePrenotazioni.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionePrenotazioniApi.Controllers {

    [RoutePrefix("api/repliche")]
    public class ReplicheController : ApiController {

        [HttpGet]
        [Route("isalive")]
        public string IsAlive() {
            return "Repliche is alive";
        }

        [HttpGet]
        [Route("bytime")]
        public List<Replica> GetReplicheByTime() {
            List<Replica> repls = new List<Replica>();
            repls = new daoReplica().GetByTime();
            return repls;
        }

    }
}
