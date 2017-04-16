using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kärnan
{
    public class Unit
    {
        public int unitID { get; set; }
        public string name { get; set; }

        public string unitName
        {
            get
            {
                return /*unitID + " " +*/ name ;

            }
        }

        SQL newSql = new SQL();

        //Visa namnen på enhet
        public List<Unit> showUnit()
        {
            //int unitid = unitID;

            try
            {
                newSql.conn.Open();
                string query = "SELECT name FROM unit";
                newSql.cmd = new NpgsqlCommand(query, newSql.conn);
                //newSql.cmd.Parameters.AddWithValue("name", name);

                newSql.dr = newSql.cmd.ExecuteReader();
                List<Unit> ut = new List<Unit>();
                Unit unit;

                while (newSql.dr.Read())
                {
                    unit = new Unit()
                    {
                        name = newSql.dr["name"].ToString(),
                        //unitID = (int)newSql.dr["unitid"],
                    };
                    ut.Add(unit);
                }
                return ut;
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