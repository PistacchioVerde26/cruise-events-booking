using GestionePrenotazioni.Models;
using GestionePrenotazioni.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionePrenotazioniApi.Controllers {
    [RoutePrefix("api/prenotazioni")]
    public class PrenotazioniController : ApiController {

        [Authorize]
        [HttpPost]
        [Route("set")]
        public HttpResponseMessage SetPrenotazione([FromBody] Prenotazione newPren) {
            try {
                Prenotazione P = new daoPrenotazioni().AddPrenotazione(newPren);
                if (P.ID != -1) {
                    return Request.CreateResponse(HttpStatusCode.OK, P);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Not available");
            } catch (Exception ex) {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("get/{id}")]
        public HttpResponseMessage GetPrenotazioni(string id) {
            int uid = Convert.ToInt32(id);
            List<Prenotazione> prenotazioni = new daoPrenotazioni().GetByUtente(uid);
            if (prenotazioni != null) {
                return Request.CreateResponse(HttpStatusCode.OK, prenotazioni);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Not available");
            //try {
            //    int uid = Convert.ToInt32(id);
            //    List<Prenotazione> prenotazioni = new daoPrenotazioni().GetByUtente(uid);
            //    if (prenotazioni != null) {
            //        return Request.CreateResponse(HttpStatusCode.OK, prenotazioni);
            //    }
            //    return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Not available");
            //} catch (Exception ex) {
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            //}
        }

    }
}
