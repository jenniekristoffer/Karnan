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


        //Visa födelsenummret på familjemedlem
        public List<Family>showBirth(string pnr)
        {
            try
            {
                newSql.conn.Open();
                string query = "SELECT birth FROM family WHERE familyid = @familyid;";

                newSql.cmd = new NpgsqlCommand(query, newSql.conn);
                newSql.cmd.Parameters.AddWithValue("familyid", pnr);

                newSql.dr = newSql.cmd.ExecuteReader();
                List<Family> fy = new List<Family>();
                Family family;

                while (newSql.dr.Read())
                {
                    family = new Family()
                    {
                        familyID = (int)newSql.dr["familyid"],
                        birth = newSql.dr["birth"].ToString(),
                    };
                    fy.Add(family);
                }
                return fy;
            }
            catch (NpgsqlException ex)
            {
                this.newSql.ex = ex.Message;
                return null;
            }
            finally
            {
                newSql.conn.Close();
            }
        }
    }
}