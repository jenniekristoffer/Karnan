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
        public string unitname { get; set; }

        SQL sql = new SQL();

        public string unitName
        {
            get
            {
                return unitname ;

            }
        }

        SQL newSql = new SQL();

        //Visa namn på unit
        public List<Unit> showUnit()
        {
            try
            {
                sql.conn.Open();
                string query = "SELECT unitid, unitname " +
                               "FROM unit ORDER BY unitid";

                List<Unit> u = new List<Unit>();
                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);

                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Unit unit = new Unit();
                    unit.unitID = Convert.ToInt32(dr["unitid"]);
                    unit.unitname = dr["unitname"].ToString();

                    u.Add(unit);
                }
                return u;
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


        //Lägg till ny enhet 
        public void saveUnit(string unitname)
        {
            try
            {
                sql.conn.Open();
                string query = "INSERT INTO unit (unitname) " +
                               "VALUES(@unitname) ";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("unitname", unitname);

                cmd.ExecuteNonQuery();
            }

            catch (NpgsqlException ex)
            {
                this.sql.ex = ex.Message;
            }
            sql.conn.Close();
        }

        //Uppdatera namn på enhet
        public void updateUnit(int unitid, string unitname)
        {
            try
            {
                sql.conn.Open();

                string query = "UPDATE unit " +
                            "SET unitname = @unitname " +
                            "WHERE unitid = @unitid ";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("unitid", unitid);
                cmd.Parameters.AddWithValue("unitname", unitname);

                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                this.sql.ex = ex.Message;
            }
            finally
            {
                sql.conn.Close();
            }
        }

        //Radera enhet 
        public void removeUnit(int unitid)
        {
            try
            {
                sql.conn.Open();
                string query = "DELETE FROM unit WHERE unit.unitid = @unitid";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("unitid", unitid);

                cmd.ExecuteNonQuery();
            }

            catch (NpgsqlException ex)
            {
                this.sql.ex = ex.Message;
            }
            sql.conn.Close();
        }
    }
}