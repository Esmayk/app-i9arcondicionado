using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app_i9arcondicionado.Models
{
    public class ConexaoDB
    {
        public NpgsqlConnection ConexaoPostgreSQL(int sistema)
        {
            conexao = "Server = localhost; Port = 5432; User Id = postgres; Password = postgres; Database = i9arcondicionado;";
            NpgsqlConnection conn = new NpgsqlConnection(String.Format(conexao));
            conn.Open();
            return conn;
        }
    }
}