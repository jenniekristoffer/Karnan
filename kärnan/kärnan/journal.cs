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

        public string journalDateIncident
        {
            get
            {
                return journalnote;

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

        ////Spara till sammanslagen tabell 
        //public void saveAllInfo(int fam, int uni, int employ, int journ)
        //{
        //    int f = family.familyID;
        //    int u = unit.unitID;
        //    int e = employee.employeeid;

        //    try
        //    {
        //        sql.conn.Open();
        //        string query = "INSERT INTO journal_employee_unit_family(employeeid, unitid, familyid, journalid) " +
        //                        "SELECT employeeid, unitid, familyid, journalid " +
        //                        "FROM employee, unit, family, journal " +
        //                        "WHERE employee.employeeid = @employeeid " +
        //                        "AND unit.unitid = @unitid " +
        //                        "AND family.familyid = @familyid " +
        //                        "AND journal.journalid = @journalid";

        //        NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
        //            cmd.Parameters.AddWithValue("employeeid", employ);
        //            cmd.Parameters.AddWithValue("unitid", uni);
        //            cmd.Parameters.AddWithValue("familyid", fam);
        //            cmd.Parameters.AddWithValue("journalid", journ);

        //            cmd.ExecuteNonQuery();
        //        }

        //        catch (NpgsqlException ex)
        //        {
        //            this.sql.ex = ex.Message;
        //        }
        //        sql.conn.Close();
        //    }
    }
}