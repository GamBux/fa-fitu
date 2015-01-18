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
        public static int ExecuteNonQuery(string operation) {
            NpgsqlConnection conn = DataBaseConnection.GetConnection();
            NpgsqlCommand Command = new NpgsqlCommand(operation, conn);

            conn.Open();
            int ret = Command.ExecuteNonQuery();
            conn.Close();

            return ret;
        }

        /// <summary>
        /// use connection.close() after reading from reader!!!
        /// </summary>
        /// <returns></returns>
        public static Tuple<NpgsqlConnection,NpgsqlDataReader> ExecuteReader(string operation)
        {
            NpgsqlConnection conn = DataBaseConnection.GetConnection();
            NpgsqlCommand Command = new NpgsqlCommand(operation, conn);
            conn.Open();
            NpgsqlDataReader rd = Command.ExecuteReader();
            return new Tuple<NpgsqlConnection, NpgsqlDataReader>(conn, rd);
           
        }
    }
}