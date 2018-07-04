using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionePrenotazioni.Models.DAO {

    public class DBEntity {
        SqlConnection conn = new SqlConnection();

        private void ApriConnessione() {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            if (conn.State == ConnectionState.Open) {
                conn.Close();
            }
            conn.Open();
        }
        private void ChiudiConnessione() {
            if (conn.State == ConnectionState.Open) {
                conn.Close();
            }
        }
        public DataTable eseguiQuery(SqlCommand cmd) {
            cmd.Connection = conn;
            DataTable dt = new DataTable();
            ApriConnessione();
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = cmd;
            DA.Fill(dt);
            ChiudiConnessione();
            return dt;

        }
        public void eseguiQueryNOreturn(SqlCommand cmd) {
            cmd.Connection = conn;
            ApriConnessione();
            cmd.ExecuteNonQuery();
            ChiudiConnessione();
        }

        public int eseguiInsertIDreturn(SqlCommand cmd) {
            cmd.Connection = conn;
            ApriConnessione();
            decimal insertedID = (decimal)cmd.ExecuteScalar();
            ChiudiConnessione();
            return Decimal.ToInt32(insertedID);
        }

    }
}