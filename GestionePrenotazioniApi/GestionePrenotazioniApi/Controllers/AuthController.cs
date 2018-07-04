using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionePrenotazioniApi.Controllers {
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController {

        [HttpGet]
        [Route("isalive")]
        public string IsAlive() {
            return "Auth is alive";
        }

        //[Authorize]
        //[HttpGet]
        //[Route("getallusers")]
        //public List<User> GetAllUsers() {

        //    return AuthManager.usersList;
        //    //return Request.CreateResponse(HttpStatusCode.OK, AuthManager.usersList);
        //}


        //[Authorize]
        //[HttpPost]
        //[Route("adduser")]
        //public HttpResponseMessage AddUser([FromBody] User _user) {
        //    try {
        //        AuthManager.usersList.Add(_user);
        //        return Request.CreateResponse(HttpStatusCode.OK, "Utente correttamente creato");
        //    } catch (Exception ex) {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
        //    }
        //}

    }
}
