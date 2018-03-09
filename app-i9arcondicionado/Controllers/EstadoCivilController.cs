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
    public class EstadoCivilController : ApiController
    {
        private EstadoCivil estadoCivil;
        private List<EstadoCivil> estadoCivilList = new List<EstadoCivil>();
        private NpgsqlDataReader leitor;
        private NpgsqlCommand query;

        [HttpGet]
        [Route("estadoCivil")]
        public IHttpActionResult getEstadoCivil()
        {
            NpgsqlConnection conexao = new ConexaoDB().ConexaoPostgreSQL();
            if (conexao != null)
            {
                string consulta = "select * from estado_civil";
                query = new NpgsqlCommand(consulta, conexao);
                try
                {
                    leitor = query.ExecuteReader();
                    while (leitor.Read())
                    {
                        estadoCivil = new EstadoCivil
                        {
                            Id = leitor.GetDecimal(0),
                            Descricao = leitor.GetString(1),
                            
                        };
                        estadoCivilList.Add(estadoCivil);
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
            return Ok(estadoCivilList);
        }
    }
}
