using app_i9arcondicionado.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace app_i9arcondicionado.Controllers
{
    [RoutePrefix("api/i9arcondicionado")]
    public class TipoPessoaController : ApiController
    {
        private TipoPessoa tipoPessoa;
        private List<TipoPessoa> tipoPessoaList = new List<TipoPessoa>();
        private NpgsqlDataReader leitor;
        private NpgsqlCommand query;

        [HttpGet, Route("tipoPessoa")]
        public IHttpActionResult getTipoPessoa()
        {

            NpgsqlConnection conexao = new ConexaoDB().ConexaoPostgreSQL();
            if (conexao != null)
            {
                string consulta = "SELECT * FROM tipo_pessoa";
                query = new NpgsqlCommand(consulta, conexao);
                try
                {
                    leitor = query.ExecuteReader();
                    while (leitor.Read())
                    {
                        tipoPessoa = new TipoPessoa
                        {
                            Id = leitor.GetDecimal(0),
                            Descricao = leitor.GetString(1)

                        };
                        tipoPessoaList.Add(tipoPessoa);
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
            return Ok(tipoPessoa);
        }
    }
}
