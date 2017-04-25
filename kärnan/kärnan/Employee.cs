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

        public int userpassid { get; set; }
        public string anv { get; set; }
        public string pass { get; set; }

        public override string ToString()
        {
            return name.ToString();
        }
        
        ///<summary>
        /// Metod som hämtar information om den inloggade till ett Session
        /// </summary>
        /// <param name="anv"></param>
        /// <returns>Ett objekt: Employee</returns>
        //Hämtar information om den inloggade till en session 
        public Employee logginInfo(string anv)
        {
            try
            {
                string query = "SELECT name, surname, initials" +
                               "FROM employee, userpass " +
                               "WHERE userpass.anv = @anv " +
                               "AND userpass.employeeid = employee.employeeid";

                Employee e = new Employee();
                sql.conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
                //cmd.Parameters.AddWithValue("@employeeid", employeeid);
                cmd.Parameters.AddWithValue("@anv", anv);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                List<Employee> emp = new List<Employee>();
                Employee employee;

                while (dr.Read())
                {
                    employee = new Employee()
                    {
                        name = dr["name"].ToString(),
                        surname = dr["surname"].ToString(),
                        initials = dr["initials"].ToString(),
                        employeeid = Convert.ToInt32(dr["employeeid"]),
                        anv = dr["anv"].ToString(),
                    };

                    emp.Add(employee);           
                }

                return e;
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

            //    try
            //    {
            //        sql.conn.Open();
            //        string query = "SELECT user, password FROM loggin WHERE user";
            //        NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
            //        cmd.Parameters.AddWithValue("id", user);
            //        cmd.Parameters.AddWithValue("id", password);
            //        cmd.ExecuteNonQuery();

            //        sql.dr = sql.cmd.ExecuteReader();
            //        List<Loggain> ln = new List<Loggain>();
            //        Loggain Loggin;

            //        while (sql.dr.Read())
            //        {
            //            Loggin = new Loggain()
            //            {
            //                user = sql.dr["user"].ToString(),
            //                password = sql.dr["password"].ToString(),
            //            };
            //            ln.Add(Loggin);
            //        }
            //    }
            //    catch (NpgsqlException ex)
            //    {
            //        this.sql.ex = ex.Message;
            //    }

            //    finally
            //    {
            //        sql.conn.Close();
            //    }
            //}

        }
        }
}