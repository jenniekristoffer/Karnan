using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kärnan
{
    public class Client
    {
        SQL sql = new SQL();

        public int familyid { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string birth { get; set; }
        public int unitid { get; set; }
        public string unitname { get; set; }

        public string nameSurnameBirthUnitname
        {
            get
            {
                return name + " " + surname + "( " + birth + ") :" + unitname;
            }
        }
     
        //Visa födelsenummret på familjemedlem - EJ IMPLEMENTERAD
        public List<Client>showBirth(string pnr)
        {
            try
            {
                sql.conn.Open();
                string query = "SELECT birth FROM family WHERE familyid = @familyid;";

                sql.cmd = new NpgsqlCommand(query, sql.conn);
                sql.cmd.Parameters.AddWithValue("familyid", pnr);

                sql.dr = sql.cmd.ExecuteReader();
                List<Client> fy = new List<Client>();
                Client family;

                while (sql.dr.Read())
                {
                    family = new Client()
                    {
                        familyid = (int)sql.dr["familyid"],
                        birth = sql.dr["birth"].ToString(),
                    };
                    fy.Add(family);
                }
                return fy;
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

        //Visa rubriker på journaler
        public List<Client> showFamily()
        {
            try
            {
                sql.conn.Open();
                string query = "SELECT familyid, name, surname, birth, unitname " +
                               "FROM family, unit " +
                               "WHERE family.unitid = unit.unitid";

                List<Client> fy = new List<Client>();
                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);

                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Client f = new Client();
                    f.familyid = Convert.ToInt32(dr["familyid"]);
                    f.name = dr["name"].ToString();
                    f.unitname = dr["unitname"].ToString();
                    f.surname = dr["surname"].ToString();
                    f.birth = dr["birth"].ToString();

                    fy.Add(f);
                }
                return fy;
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

        //Spara ny familjemedlem till enhet 
        public void saveClient(string name, string surname, string birth, int unitid)
        {
            try
            {
                sql.conn.Open();
                string query = "INSERT INTO family(name, surname, birth, unitid) " +
                               "VALUES(@name, @surname, @birth, @unitid);";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("surname", surname);
                cmd.Parameters.AddWithValue("birth", birth);
                cmd.Parameters.AddWithValue("unitid", unitid); 
                cmd.ExecuteNonQuery();
            }

            catch (NpgsqlException ex)
            {
                sql.ex = ex.Message;
            }
            sql.conn.Close();
        }

        //Uppdatera information på familjemedlem
        public void updateFamily(int familyid, string name, string surname, string birth)
        {
            try
            {
                sql.conn.Open();

                string query = "UPDATE family " +
                               "SET name = @name, surname = @surname, birth = @birth " +
                               "WHERE familyid = @familyid ";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("familyid", familyid);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("surname", surname);
                cmd.Parameters.AddWithValue("birth", birth);

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

        //Radera familj
        public void removeFamily(int familyid)
        {
            try
            {
                sql.conn.Open();
                string query = "DELETE FROM family WHERE family.familyid = @familyid";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("familyid", familyid);

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