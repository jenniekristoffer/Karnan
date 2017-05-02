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

        SQL sql = new SQL();

        public string unitName
        {
            get
            {
                return name ;

            }
        }

        SQL newSql = new SQL();

        //Lägg till ny enhet 
        public void saveUnit(string name)
        {
            try
            {
                sql.conn.Open();
                string query = "INSERT INTO unit (name) " +
                               "VALUES(@name) ";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("name", name);

                cmd.ExecuteNonQuery();
            }

            catch (NpgsqlException ex)
            {
                this.sql.ex = ex.Message;
            }
            sql.conn.Close();
        }

        //Uppdatera namn på enhet
        public void updateUnit(int unitid, string name)
        {
            try
            {
                sql.conn.Open();

                string query = "UPDATE unit " +
                            "SET name = @name " +
                            "WHERE unitid = @unitid ";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("unitid", unitid);
                cmd.Parameters.AddWithValue("name", name);

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

        // Radera enhet 
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