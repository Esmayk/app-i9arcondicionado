using app_i9arcondicionado.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace app_i9arcondicionado.Controllers
{
    [RoutePrefix("api/i9arcondicionado")]
    public class EstadoController : ApiController
    {
        private Estado estado;
        private List<Estado> estadoList = new List<Estado>();
        private NpgsqlDataReader leitor;
        private NpgsqlCommand query;
        
        [HttpGet]
        [Route("estado")]
        public IHttpActionResult getEstados()
        {
            NpgsqlConnection conexao = new ConexaoDB().ConexaoPostgreSQL();
            List<Object> lista = new List<Object>();
            if (conexao != null)
            {
                string consulta = "SELECT * FROM estado";
                query = new NpgsqlCommand(consulta, conexao);
                try
                {
                    leitor = query.ExecuteReader();
                    while (leitor.Read())
                    {
                          estado = new Estado
                     {
                         Id = leitor.GetDecimal(0),
                         Nome = leitor.GetString(1),
                         Sigla = leitor.GetString(2)
                    };
                        estadoList.Add(estado);

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

            return Ok(lista);
        }
    }
}
