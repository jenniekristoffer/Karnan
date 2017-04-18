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
        public string journal { get; set; }
        public string incident { get; set; }

        public string journalDateIncident
        {
            get
            {
                return journal;

            }
        }

        //Spara journalanteckning
        public void saveJournal(string jour, string inci, DateTime date /*int jourid*/)
        {
            try
            {
                sql.conn.Open();

                //try
                //{         
                string query = "INSERT INTO journal (date, journal, incident) " +
                               "VALUES('2016-05-05', @journal, @incident) ";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("journal", journal);
                cmd.Parameters.AddWithValue("incident", incident);
                cmd.Parameters.AddWithValue("date", date);
                //cmd.Parameters.AddWithValue("journalid", jourid);

                cmd.ExecuteNonQuery();
            }

            catch (NpgsqlException ex)
            {
                this.sql.ex = ex.Message;
                sql.conn.Close();
            }

        }
    }
}