using app_i9arcondicionado.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace app_i9arcondicionado.Controllers
{
    [RoutePrefix("api/i9arcondicionado")]
    public class TipoTelefoneController : ApiController
    {

        private TipoTelefone tipoTelefone;
        private List<TipoTelefone> tipoTelefoneList = new List<TipoTelefone>();
        private NpgsqlDataReader leitor;
        private NpgsqlCommand query;

        [HttpGet]
        [Route("tipoTelefone")]
        public IHttpActionResult getTipoTelefone()
        {

            NpgsqlConnection conexao = new ConexaoDB().ConexaoPostgreSQL();
            if (conexao != null)
            {
                string consulta = "select * from tipo_telefone";
                query = new NpgsqlCommand(consulta, conexao);
                try
                {
                    leitor = query.ExecuteReader();
                    while (leitor.Read())
                    {
                        tipoTelefone = new TipoTelefone
                        {
                            Id = leitor.GetDecimal(0),
                            Descricao = leitor.GetString(1)
                            
                        };
                        tipoTelefoneList.Add(tipoTelefone);
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
            return Ok(tipoTelefoneList);
        }
    }
}
