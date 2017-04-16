using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kärnan
{
    public class SQL
    {
        public NpgsqlDataReader dr;
        public NpgsqlCommand cmd;
        public string ex { get; set; }

        public NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=karnan; UserId=karnan; Password=Sundsvall123; SslMode=Require;");
    }
}