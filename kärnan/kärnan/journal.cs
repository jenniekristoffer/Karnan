using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kärnan
{
    public class Journal
    {
        SQL sql = new SQL();

        public int journalid { get; set; }
        public DateTime date { get; set; }
        public DateTime date2 { get; set; }
        public string journalnote { get; set; }
        public string incident { get; set; }

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
        public void saveJournal(string jour, string inci, DateTime date, int employeeid, int unitid, int familyid)
        {
            try
            {
                sql.conn.Open();      
                string query = "INSERT INTO journal (date, journalnote, incident, employeeid, unitid, familyid) " +
                               "VALUES(@date, @journalnote, @incident, @employeeid, @unitid, @familyid) ";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("journalnote", journalnote);
                cmd.Parameters.AddWithValue("incident", incident);
                cmd.Parameters.AddWithValue("date", date);
                cmd.Parameters.AddWithValue("employeeid", employeeid);
                cmd.Parameters.AddWithValue("unitid", unitid);
                cmd.Parameters.AddWithValue("familyid", familyid);

                cmd.ExecuteNonQuery();
            }

            catch (NpgsqlException ex)
            {
                this.sql.ex = ex.Message;         
            }
            sql.conn.Close();
        }

       //Visa rubriker på journaler
       public List<Journal> showIncident(int unitid, int familyid)
        {
         try
            {
                sql.conn.Open();
                string query = "SELECT journalid, date, incident FROM journal " +
                               "WHERE unitid = @unitid " +
                               "AND familyid = @familyid " +
                               "ORDER BY date DESC;";

                List<Journal> jc = new List<Journal>();
                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("unitid", unitid);
                cmd.Parameters.AddWithValue("familyid", familyid);

                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Journal j = new Journal();
                    j.journalid = Convert.ToInt32(dr["journalid"]);
                    j.date = Convert.ToDateTime(dr["date"]);
                    j.incident = dr["incident"].ToString();

                    jc.Add(j);    
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

        //Visa journal mellan specifika datum 
        public List<Journal> dateJournal(int familyid, int unitid, DateTime date, DateTime date2)
        {
            try
            {     
            sql.conn.Open();
                string query = "SELECT DISTINCT journal.date, incident, journalnote, familyid, unitid, journalid " +
                               "FROM journal " +
                               "WHERE journal.date " +
                               "BETWEEN @timefrom AND @timeto " +
                               "AND journal.familyid = @familyid";

            List<Journal> journalList = new List<Journal>();
            
            NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
            cmd.Parameters.AddWithValue("@timefrom", date);
            cmd.Parameters.AddWithValue("@timeto", date2);
            cmd.Parameters.AddWithValue("@familyid", familyid);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Journal j = new Journal();

                j.date = Convert.ToDateTime(dr["date"]);
                j.incident = dr["incident"].ToString();
                j.journalnote = dr["journalnote"].ToString();
                j.unitid = Convert.ToInt32(dr["unitid"]);
                j.familyid = Convert.ToInt32(dr["familyid"]);
                j.journalid = Convert.ToInt32(dr["journalid"]);

                    journalList.Add(j);
            }
                return journalList;
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