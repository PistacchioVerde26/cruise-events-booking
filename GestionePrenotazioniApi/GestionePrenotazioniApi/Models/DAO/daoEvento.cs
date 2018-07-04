using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionePrenotazioni.Models.DAO {
    public class daoEvento {

        public Evento GetByID(int ID) {
            DataTable dt = new DataTable();
            DBEntity db = new DBEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"SELECT * 
                                              FROM eventi WHERE id_evento={0}", ID);
            Evento E = null;

            dt = db.eseguiQuery(cmd);
            if (dt.Rows.Count > 0) {
                E = new Evento();
                E.ID = (int)dt.Rows[0]["id_evento"];
                E.Titolo = (string)dt.Rows[0]["titolo"];
                E.ImagePath = (string)dt.Rows[0]["image"];
                E.IDLocale = (int)dt.Rows[0]["fk_locale"];
            }

            E.Locale = new daoLocale().GetByID(E.IDLocale);
            return E;
        }

    }
}