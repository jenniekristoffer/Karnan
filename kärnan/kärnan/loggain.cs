using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace kärnan
{
    public class Loggain
    {
        public string user { get; set; }
        public string password { get; set; }


        SQL sql = new SQL();

        public void anvLoggin(string user, string password)
        {
            try
            {
              sql.conn.Open();
                string query = "SELECT user, password FROM loggin WHERE user";
                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("id", user);
                cmd.Parameters.AddWithValue("id", password);
                cmd.ExecuteNonQuery();

                sql.dr = sql.cmd.ExecuteReader();
                List<Loggain> ln = new List<Loggain>();
                Loggain Loggin;

                while (sql.dr.Read())
                {
                    Loggin = new Loggain()
                    {
                        user = sql.dr["user"].ToString(),
                        password = sql.dr["password"].ToString(),
                    };
                    ln.Add(Loggin);
            }
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
    }
}