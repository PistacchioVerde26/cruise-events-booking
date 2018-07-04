using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionePrenotazioni.Models.DAO {

    public class daoReplica {

        public Replica GetByID(int ID) {
            DataTable dt = new DataTable();
            DBEntity db = new DBEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"SELECT * 
                                              FROM repliche WHERE id_replica={0}", ID);
            Replica R = null;

            dt = db.eseguiQuery(cmd);
            if (dt.Rows.Count > 0) {
                R = new Replica();
                R.ID = (int)dt.Rows[0]["id_replica"];
                R.Data = (Int64)dt.Rows[0]["data"];
                R.Annullato = (bool)dt.Rows[0]["annullato"];
                R.IDEvento = (int)dt.Rows[0]["fk_evento"];
                R.Evento = new daoEvento().GetByID(R.IDEvento);
                R.PostiOccupati = this.GetPostiOccupati(R.ID);
            }

            return R;
        }

        public List<Replica> GetByTime() {
            DataTable dt = new DataTable();
            DBEntity db = new DBEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"SELECT * FROM repliche WHERE data > '{0}' ORDER BY data DESC",
                                           Convert.ToInt64(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds));

            List<Replica> repliche = null;

            dt = db.eseguiQuery(cmd);
            if (dt.Rows.Count > 0) {
                repliche = new List<Replica>();
                foreach (DataRow dr in dt.Rows) {
                    Replica R = new Replica();
                    R.ID = (int)dr["id_replica"];
                    R.Data = (Int64)dr["data"];
                    R.Annullato = (bool)dr["annullato"];
                    R.IDEvento = (int)dr["fk_evento"];
                    R.Evento = new daoEvento().GetByID(R.IDEvento);
                    R.PostiOccupati = this.GetPostiOccupati(R.ID);

                    repliche.Add(R);
                }
            }

            return repliche;
        }

        public int GetPostiOccupati(int ID) {
            DataTable dt = new DataTable();
            DBEntity db = new DBEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"SELECT SUM(qta) AS postioccupati
                                              FROM prenotazioni WHERE fk_replica={0}", ID);
            int postiOccupati = 0;

            dt = db.eseguiQuery(cmd);
            if (dt.Rows.Count > 0) {
                postiOccupati = dt.Rows[0].IsNull("postioccupati") ? 0 : (int)dt.Rows[0]["postioccupati"];
            }

            return postiOccupati;
        }

    }


}