using app_i9arcondicionado.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace app_i9arcondicionado.Controllers
{
    [RoutePrefix("api/i9arcondicionado")]
    public class TipoDocumentoController : ApiController
    {
        private TipoDocumento tipoDocumento;
        private List<TipoDocumento> tipoPessoaList = new List<TipoDocumento>();
        private NpgsqlDataReader leitor;
        private NpgsqlCommand query;

        [HttpGet]
        [Route("tipoDocumento")]
        public IHttpActionResult getTipoDocumento()
        {

            NpgsqlConnection conexao = new ConexaoDB().ConexaoPostgreSQL();
            if (conexao != null)
            {
                string consulta = "select * from tipo_documento";
                query = new NpgsqlCommand(consulta, conexao);
                try
                {
                    leitor = query.ExecuteReader();
                    while (leitor.Read())
                    {
                        tipoDocumento = new TipoDocumento
                        {
                            Id = leitor.GetDecimal(0),
                            Descricao = leitor.GetString(1)

                        };
                        tipoPessoaList.Add(tipoDocumento);
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
            return Ok(tipoDocumento);
        }
    }
}
