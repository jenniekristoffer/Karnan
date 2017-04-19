using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kärnan
{
    public class journalClass
    {
        SQL sql = new SQL();

        public int journalID { get; set; }
        public DateTime date { get; set; }
        public string journalnote { get; set; }
        public string incident { get; set; }

        public string journalDateIncident
        {
            get
            {
                return journalnote;

            }
        }

        //Spara journalanteckning
        public void saveJournal(string jour, string inci, DateTime date)
        {
            try
            {
                sql.conn.Open();

                //try
                //{         
                string query = "INSERT INTO journal (date, journalnote, incident) " +
                               "VALUES(@date, @journalnote, @incident) ";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("journalnote", journalnote);
                cmd.Parameters.AddWithValue("incident", incident);
                cmd.Parameters.AddWithValue("date", date);
                //cmd.Parameters.AddWithValue("journalid", journalID);

                cmd.ExecuteNonQuery();
            }

            catch (NpgsqlException ex)
            {
                this.sql.ex = ex.Message;         
            }
            sql.conn.Close();
        }
    }
}