using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionePrenotazioni.Models.DAO {
    public class daoLocale {

        public Locale GetByID(int ID) {
            DataTable dt = new DataTable();
            DBEntity db = new DBEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"SELECT * 
                                              FROM locali WHERE id_locale={0}", ID);
            Locale L = null;

            dt = db.eseguiQuery(cmd);
            if (dt.Rows.Count > 0) {
                L = new Locale();
                L.ID = (int)dt.Rows[0]["id_locale"];
                L.Nome = (string)dt.Rows[0]["nome"];
                L.Luogo = (string)dt.Rows[0]["luogo"];
                L.Posti = (int)dt.Rows[0]["posti"];
            }

            return L;
        }

    }
}