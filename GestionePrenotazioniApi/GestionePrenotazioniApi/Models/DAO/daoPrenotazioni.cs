using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionePrenotazioni.Models.DAO {

    public class daoPrenotazioni {

        public Prenotazione GetByID(int ID) {
            DataTable dt = new DataTable();
            DBEntity db = new DBEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"SELECT * 
                                              FROM prenotazioni WHERE id_pren={0}", ID);
            Prenotazione P = null;

            dt = db.eseguiQuery(cmd);
            if (dt.Rows.Count > 0) {
                P = new Prenotazione();
                P.ID = (int)dt.Rows[0]["id_pren"];
                P.Biglietti = (int)dt.Rows[0]["qta"];
                P.Data = (Int64)dt.Rows[0]["data"];
                P.IDUtente = (int)dt.Rows[0]["fk_utente"];
                P.IDReplica = (int)dt.Rows[0]["fk_replica"];
            }

            P.Replica = new daoReplica().GetByID(P.IDReplica);
            return P;
        }

        public List<Prenotazione> GetByUtente(int UID) {
            DataTable dt = new DataTable();
            DBEntity db = new DBEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"SELECT * 
                                              FROM prenotazioni WHERE fk_utente={0}", UID);
            List<Prenotazione> prenotazioni = null;

            dt = db.eseguiQuery(cmd);
            if (dt.Rows.Count > 0) {
                prenotazioni = new List<Prenotazione>();
                foreach (DataRow dr in dt.Rows) {
                    Prenotazione P = new Prenotazione();
                    P.ID = (int)dr["id_pren"];
                    P.Biglietti = (int)dr["qta"];
                    P.Data = (Int64)dr["data"];
                    P.IDUtente = (int)dr["fk_utente"];
                    P.IDReplica = (int)dr["fk_replica"];
                    P.Replica = new daoReplica().GetByID(P.IDReplica);

                    prenotazioni.Add(P);
                }
            }

            return prenotazioni;
        }

        public List<Prenotazione> GetByReplica(int RID) {
            DataTable dt = new DataTable();
            DBEntity db = new DBEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"SELECT * 
                                              FROM prenotazioni WHERE fk_replica={0}", RID);
            List<Prenotazione> prenotazioni = null;

            dt = db.eseguiQuery(cmd);
            if (dt.Rows.Count > 0) {
                prenotazioni = new List<Prenotazione>();
                foreach (DataRow dr in dt.Rows) {
                    Prenotazione P = new Prenotazione();
                    P.ID = (int)dr["id_pren"];
                    P.Biglietti = (int)dr["qta"];
                    P.Data = (Int64)dr["data"];
                    P.IDUtente = (int)dr["fk_utente"];
                    P.IDReplica = (int)dr["fk_replica"];
                    P.Replica = new daoReplica().GetByID(P.IDReplica);

                    prenotazioni.Add(P);
                }
            }

            return prenotazioni;
        }

        public Prenotazione AddPrenotazione(Prenotazione P) {

            DataTable dt = new DataTable();
            DBEntity db = new DBEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            Int64 now = Convert.ToInt64(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
            cmd.CommandText = String.Format(@"INSERT INTO prenotazioni (qta, data, fk_utente, fk_replica)
                                                         VALUES({0},{1},{2},{3});SELECT SCOPE_IDENTITY()", P.Biglietti, now, P.IDUtente, P.IDReplica);

            int id = db.eseguiInsertIDreturn(cmd);

            P.ID = id;
            P.Replica = new daoReplica().GetByID(P.IDReplica);

            return P;
        }



    }

}