using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kärnan
{
    public class Alltables
    {
        SQL sql = new SQL();

        public int familyid { get; set; }
        public int journalid { get; set; }
        public int employeeid { get; set; }
        public int unitid { get; set; }
   
        //Spara till sammanslagen tabell 
        public void saveAllInfo(int familyid, int unitid, int employeeid, int journalid)
        {
            try
            {
                sql.conn.Open();
                string query = "INSERT INTO alltables(employeeid, unitid, familyid, journalid) " +
                                "VALUES(@employeeid, @unitid, @familyid, @journalid) ";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("employeeid", employeeid);
                cmd.Parameters.AddWithValue("unitid", unitid);
                cmd.Parameters.AddWithValue("familyid", familyid);
                cmd.Parameters.AddWithValue("journalid", journalid);

                cmd.ExecuteNonQuery();
            }

            catch (NpgsqlException ex)
            {
                this.sql.ex = ex.Message;
            }
            sql.conn.Close();
        }


        //Hämtar den senast sparade journalen  
        public int getLastJournal()
        {
            try
            {
                sql.conn.Open();
                string query = "SELECT journalid from journal " +
                               "ORDER BY journalid " + 
                               "DESC LIMIT 1 ";                   

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);

                cmd.ExecuteNonQuery();
                return journalid;
            }

            catch (NpgsqlException ex)
            {
                this.sql.ex = ex.Message;
                return 0;          
            }
         finally
            {
                 sql.conn.Close();
         
            }

      
        }   

    }
}