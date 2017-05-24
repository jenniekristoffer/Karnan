using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI.WebControls;

namespace kärnan
{
    public class Employee
    {
        SQL sql = new SQL();
        //Crypt crypt = new Crypt();

        public int employeeid { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string initials { get; set; }
        public bool admin { get; set; }

        public string anv { get; set; }
        public string pass { get; set; }

        public string nameSurnameInitialsAdminemployeeid
        {
            get
            {
                return name + " " + surname + "( " + initials + ") :" + admin + " " + "Användarnamn: " + employeeid;
            }
        }

        //Spara ny anställd 
        public void saveEmployee(string name, string surname, string initials, bool admin, string pass)
        {
            try
            {
                sql.conn.Open();
                string query = "INSERT INTO employee (name, surname, initials, admin, pass) " +
                               "VALUES(@name, @surname, @initials, @admin, @pass); ";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("surname", surname);
                cmd.Parameters.AddWithValue("initials", initials);
                cmd.Parameters.AddWithValue("admin", admin);
                cmd.Parameters.AddWithValue("pass", pass);
                cmd.ExecuteNonQuery();
            }

            catch (NpgsqlException ex)
            {
                sql.ex = ex.Message;
            }
            sql.conn.Close();
        }

        //Visa anställda
        public List<Employee> showEmployee()
        {
            try
            {
                sql.conn.Open();
                string query = "SELECT employeeid, name, surname, initials, admin " +
                               "FROM employee " +
                               "ORDER BY employeeid;";

                List<Employee> emp = new List<Employee>();
                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Employee e = new Employee();
                    e.employeeid = Convert.ToInt32(dr["employeeid"]);
                    e.name = dr["name"].ToString();
                    e.surname = dr["surname"].ToString();
                    e.initials = dr["initials"].ToString();
                    e.admin = Convert.ToBoolean(dr["admin"]);

                    emp.Add(e);
                }
                return emp;
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

        //Radera anställd
        public void removeEmployee(int familyid)
        {
            try
            {
                sql.conn.Open();
                string query ="DELETE FROM employee WHERE employee.employeeid = @employeeid;";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("employeeid", employeeid);

                cmd.ExecuteNonQuery();
            }

            catch (NpgsqlException ex)
            {
                this.sql.ex = ex.Message;
            }
            sql.conn.Close();
        }

        //Uppdatera anställd
        public void updateEmployee(int employeeid, string name, string surname, string initials, bool admin)
        {
            try
            {
                sql.conn.Open();

                string query = "UPDATE employee " +
                               "SET name = @name, surname = @surname, initials = @initials, admin = @admin " +
                               "WHERE employeeid = @employeeid ";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("employeeid", employeeid);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("surname", surname);
                cmd.Parameters.AddWithValue("initials", initials);
                cmd.Parameters.AddWithValue("admin", admin);

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

        ////Spara ny inloggning
        //public void saveInlogg(string pass, string anv)
        //{       
        //    try
        //    {
        //        sql.conn.Open();
        //        string query = "INSERT INTO userpass(anv, pass) " +
        //                       "VALUES(@anv, @pass);";
        //        NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
        //        cmd.Parameters.AddWithValue("pass", pass);
        //        cmd.Parameters.AddWithValue("anv", anv);
        //        cmd.ExecuteNonQuery();
        //    }

        //    catch (NpgsqlException ex)
        //    {
        //        sql.ex = ex.Message;
        //    }
        //    sql.conn.Close();
        //}

        //Uppdatera lösenord
        public void updatePassword(string pass, int employeeid)
        {
            try
            {
                sql.conn.Open();
                string query = "UPDATE userpass " +
                               "SET pass = @pass " +
                               "WHERE employeeid = @employeeid ";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("pass", pass);
                cmd.Parameters.AddWithValue("employeeid", employeeid);
                cmd.ExecuteNonQuery();
            }

            catch (NpgsqlException ex)
            {
                sql.ex = ex.Message;
            }
            sql.conn.Close();
        }

//______________________________________________________________________________________________________________________//

        //Visa senaste tillagda anställdas ID i textbox: EJ ANVÄND 
        public void showLastEmployee(int employeeid)
        {
            try
            {
                sql.conn.Open();
                string query = "SELECT employeeid FROM employee ORDER BY employeeid DESC LIMIT 1;";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("employeeid", employeeid);
                cmd.ExecuteNonQuery();
            }

            catch (NpgsqlException ex)
            {
                sql.ex = ex.Message;
            }
            sql.conn.Close();
        }

        //Kontroller om anställd är admin: EJ ANVÄND
        public void controllEmployee(int employeeid)
        {
            try
            {
                sql.conn.Open();
                //string query = "SELECT DISTINCT employee.employeeid, pass, admin " +
                //               "FROM userpass, employee " +
                //               "WHERE employee.admin = true " +
                //               "AND employee.employeeid = userpass.employeeid; ";

                string query = "SELECT DISTINCT employeeid, pass " +
               "FROM userpass " +
               "WHERE employeeid = '1' " +
               "AND employeeid = '6'; ";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);

                cmd.ExecuteNonQuery();
                //return true;
            }

            catch (NpgsqlException ex)
            {
                this.sql.ex = ex.Message;
                sql.conn.Close();
                //return null;              
            }          
        }


    }
}