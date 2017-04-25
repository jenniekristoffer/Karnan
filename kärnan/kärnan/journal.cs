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
        Family family = new Family();
        Unit unit = new Unit();
        Employee employee = new Employee();

        public int journalID { get; set; }
        public DateTime date { get; set; }
        public string journalnote { get; set; }
        public string incident { get; set; }
        public int employeeid { get; set; }

        public int unitid { get; set; }
        public int familyid { get; set; }

        public string dateIncident
        {
            get
            {
                return date.ToShortDateString() + ": " + incident;
            }
        }

        //Spara journalanteckning
        public void saveJournal(string jour, string inci, DateTime date, int employeeid)
        {
            try
            {
                sql.conn.Open();      
                string query = "INSERT INTO journal (date, journalnote, incident, employeeid) " +
                               "VALUES(@date, @journalnote, @incident, @employeeid) ";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("journalnote", journalnote);
                cmd.Parameters.AddWithValue("incident", incident);
                cmd.Parameters.AddWithValue("date", date);
                cmd.Parameters.AddWithValue("employeeid", employeeid);

                cmd.ExecuteNonQuery();
            }

            catch (NpgsqlException ex)
            {
                this.sql.ex = ex.Message;         
            }
            sql.conn.Close();
        }

      //Visa rubriker på journaler
       public List<journalClass> showIncident(int unitid, int familyid)
        {
            try
            {
                sql.conn.Open();
                string query = "SELECT date, incident FROM journal " +
                               "WHERE unitid = @unitid " +
                               "AND familyid = @familyid";

                List<journalClass> jc = new List<journalClass>();
                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("unitid", unitid);
                cmd.Parameters.AddWithValue("familyid", familyid);

                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    journalClass j = new journalClass();
                    j.date = Convert.ToDateTime(dr["date"]);
                    j.incident = dr["incident"].ToString();

                    jc.Add(j);
                    //cmd.ExecuteNonQuery();
                }
                return jc;
            }

            catch (NpgsqlException ex)
            {
                this.sql.ex = ex.Message;
                return null;
            }

            finally
            {
                sql.conn.Close();
            }

        }
    }
}