using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace app_i9arcondicionado.Models
{
    public class ConexaoDB
    {
        public NpgsqlConnection ConexaoPostgreSQL()
        {
            string conexao = "Server = ec2-54-243-239-66.compute-1.amazonaws.com;"
                + " Port = 5432; User Id = pmdgqafszklnso;"
                + "Password = 7889cd6c2ee04fe7cbfd4dd90658aa049d16108f40f7d18590906a0d82a816c4; Database = dafssd0gq2qou5;";
            NpgsqlConnection conn = new NpgsqlConnection(String.Format(conexao));
            conn.Open();
            return conn;
        }

    }
}