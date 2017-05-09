using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace kärnan
{
    public class Employee
    {
        SQL sql = new SQL();

        public int employeeid { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string initials { get; set; }
        public bool admin { get; set; }

        public int userpassid { get; set; }
        public string anv { get; set; }
        public string pass { get; set; }

        public string nameSurnameInitialsAdmin
        {
            get
            {
                return name + " " + surname + "( " + initials + ") :" + admin;
            }
        }

        //Spara ny anställd 
        public void saveEmployee(string name, string surname, string initials, bool admin)
        {
            try
            {
                sql.conn.Open();
                string query = "INSERT INTO employee(name, surname, initials, admin) " +
                               "VALUES(@name, @surname, @initials, @admin);";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("surname", surname);
                cmd.Parameters.AddWithValue("initials", initials);
                cmd.Parameters.AddWithValue("admin", admin);
                cmd.ExecuteNonQuery();
            }

            catch (NpgsqlException ex)
            {
                sql.ex = ex.Message;
            }
            sql.conn.Close();
        }

        //Visa alla anställda
        public List<Employee> showEmployee()
        {
            try
            {
                sql.conn.Open();
                string query = "SELECT employeeid, name, surname, initials, admin " +
                               "FROM employee;";

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
                string query = "DELETE FROM employee WHERE employee.employeeid = @employeeid";

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

        //Kontroller om anställd är admin 
        public bool controllEmployee()
        {
            try
            {
                sql.conn.Open();
                string query = "SELECT employeeid, pass, userpass.admin " +
                               "FROM userpass " +
                               "WHERE userpass.admin = true;";

                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);

                cmd.ExecuteNonQuery();
                return admin;
            }

            catch (NpgsqlException ex)
            {
                this.sql.ex = ex.Message;
                sql.conn.Close();
                return false;              
            }          
        }
    }
}