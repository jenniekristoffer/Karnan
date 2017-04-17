using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kärnan
{
    public class Family
    {
        public int familyID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string birth { get; set; }

        public string showName
        {
            get
            {
                return name;

            }
        }
     
        SQL newSql = new SQL();


        //Visa namnen familjemedlem
        //public List<Family> showBirth(int pnr)
        //{
        //    try
        //    {
        //        newSql.conn.Open();
        //        string query = "SELECT DISTINCT family.name " +
        //                       "FROM family_unit " +
        //                       "JOIN unit ON family_unit.unitid = unit.unitid " +
        //                       "JOIN family ON family_unit.familyid = family.familyid " +
        //                       "WHERE unit.unitid = @unitid;";

        //        newSql.cmd = new NpgsqlCommand(query, newSql.conn);
        //        newSql.cmd.Parameters.AddWithValue("unitid", unitid);

        //        newSql.dr = newSql.cmd.ExecuteReader();
        //        List<Family> fy = new List<Family>();
        //        Family family;

        //        while (newSql.dr.Read())
        //        {
        //            family = new Family()
        //            {
        //                name = newSql.dr["name"].ToString(),
        //            };
        //            fy.Add(family);
        //        }
        //        return fy;
        //    }
        //    catch (NpgsqlException ex)
        //    {
        //        this.newSql.ex = ex.Message;
        //        return null;
        //    }
        //    finally
        //    {
        //        newSql.conn.Close();
        //    }
        //}
    }
}