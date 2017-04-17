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
        public void saveJournal(string jour, string inci, DateTime date, int jourid)
        {
            try
            {
                sql.conn.Open();

                //try
                //{         
                string query = "INSERT INTO journal (journalid, date, journal, incident) " +
                               "VALUES(@journalid,'2016-05-05', @journal, @incident) ";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("journal", journal);
                cmd.Parameters.AddWithValue("incident", incident);
                cmd.Parameters.AddWithValue("date", date);
                cmd.Parameters.AddWithValue("journalid", jourid);

                cmd.ExecuteNonQuery();
            }

            catch (NpgsqlException ex)
            {
                this.sql.ex = ex.Message;
                sql.conn.Close();
            }
        }    

            //catch (NpgsqlException ex)
            //{
            //    this.sql.ex = ex.Message;
            //    return;
            //}
            //finally
            //{
            //     sql.conn.Close();
            //}
           
               



            //try
            //{
            //    conn.Open();
            //    string sql = "SELECT * FROM frånvaro WHERE barnid = @barnid";

            //    NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            //    cmd.Parameters.AddWithValue("barnid", barnid);

            //    NpgsqlDataReader dr = cmd.ExecuteReader();

            //    BindingList<frånvaro> fv = new BindingList<frånvaro>();
            //    frånvaro frånvaro;

            //    while (dr.Read())
            //    {
            //        frånvaro = new frånvaro()
            //        {
            //            frånvaroid = (int)dr["frånvaroid"],
            //            orsak = dr["orsak"].ToString(),
            //            starttid = dr["starttid"].ToString(),
            //            sluttid = dr["sluttid"].ToString(),
            //            datum = (DateTime)dr["datum"],
            //            heldag = (bool)dr["heldag"],
            //        };

            //    }
            //    dr.Close();
            //    return fv;
            //}
            //catch (NpgsqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    return null;
            //}
            //finally
            //{
            //    conn.Close();
            //}


        //}

    }
}