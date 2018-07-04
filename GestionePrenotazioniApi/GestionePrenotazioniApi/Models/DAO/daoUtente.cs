using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionePrenotazioni.Models.DAO {
    public class daoUtente {

        public Utente Login(Utente U) {
            DataTable dt = new DataTable();
            DBEntity db = new DBEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"SELECT * FROM utenti WHERE email='{0}' AND password='{1}'", U.Email, U.Password);

            dt = db.eseguiQuery(cmd);
            if (dt.Rows.Count == 1) {
                U.ID = (int)dt.Rows[0]["id_utente"];
                U.Cognome = (string)dt.Rows[0]["cognome"];
                U.Nome = (string)dt.Rows[0]["nome"];
                U.Telefono = (string)dt.Rows[0]["telefono"];
                U.Email = (string)dt.Rows[0]["email"];
                U.Password = (string)dt.Rows[0]["password"];
            } else {
                return null;
            }

            //U.Prenotazioni = new daoPrenotazioni().GetByUtente(U.ID);
            return U;
        }

        public Utente Register(Utente U) {
            DataTable dt = new DataTable();
            DBEntity db = new DBEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"INSERT INTO utenti (nome,cognome,telefono,email,password)
                                                            VALUES('{0}','{1}','{2}','{3}')",
                                                            U.Nome, U.Cognome, U.Telefono, U.Email, U.Password);

            int id = db.eseguiInsertIDreturn(cmd);
            U.ID = id;

            return U;
        }

    }
}