using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kärnan
{
    public class Fa_jou_emlo_unit
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
                string query = "INSERT INTO journal_employee_unit_family(employeeid, unitid, familyid, journalid) " +
                                "SELECT employeeid, unitid, familyid, journalid " +
                                "FROM employee, unit, family, journal " +
                                "WHERE employee.employeeid = @employeeid " +
                                "AND unit.unitid = @unitid " +
                                "AND family.familyid = @familyid " +
                                "AND journal.journalid = @journalid";

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




        //        INSERT INTO journal_employee_unit_family(employeeid, unitid, familyid, journalid)
        //SELECT employeeid, unitid, familyid, journalid
        //FROM employee, unit, family, journal
        //WHERE employee.employeeid = '1'
        //AND unit.unitid = '2'
        //AND family.familyid = '4'
        //AND journal.journalid = '16'
    }
}