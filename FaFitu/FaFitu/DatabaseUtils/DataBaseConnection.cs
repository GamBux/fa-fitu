using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace FaFitu.DatabaseUtils
{
    public static class DataBaseConnection
    {
        public static NpgsqlConnection GetConnection() {
            return new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=password;Database=Fa-fitu_DB;");
        }
    }
}