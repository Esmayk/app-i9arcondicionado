using app_i9arcondicionado.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace app_i9arcondicionado.Controllers
{
    [RoutePrefix("api/i9arcondicionado")]
    public class CidadeController : ApiController
    {
        private Cidade cidade;
        private List<Cidade> cidadeList = new List<Cidade>();
        private NpgsqlDataReader leitor;
        private NpgsqlCommand query;

        [HttpGet]
        [Route("cidade/{estadoFk}")]
        public IHttpActionResult getCidadePorEstado(Decimal estadoFk)
        {
            NpgsqlConnection conexao = new ConexaoDB().ConexaoPostgreSQL();
            if (conexao != null)
            {
                string consulta = "select * from cidade where estado_fk =:estadoFk";
                query = new NpgsqlCommand(consulta, conexao);
                query.Parameters.Add(new NpgsqlParameter("estadoFk", DbType.Decimal));
                query.Parameters[0].Value = estadoFk;
                query.ExecuteReader();
                try
                {
                    while (leitor.Read())
                    {
                        cidade = new Cidade
                        {
                            Id = leitor.GetDecimal(0),
                            Nome = leitor.GetString(1),
                            EstadoFk = leitor.GetDecimal(2)
                        };
                        cidadeList.Add(cidade);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conexao.Close();
                }
            }
            else
            {
                throw new Exception("Conexão é nula");
            }
            return Ok(cidadeList);
        }
    }
}
