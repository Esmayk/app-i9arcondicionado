using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using app_i9arcondicionado.Models;
using Npgsql;

namespace app_i9arcondicionado.Controllers
{
    [RoutePrefix("api/i9arcondicionado")]
    public class PessoaController : ApiController
    {
        private Pessoa pessoa;
        private List<Pessoa> cidadeList = new List<Pessoa>();
        private NpgsqlDataReader leitor;
        private NpgsqlCommand query;

        [HttpPost]
        [Route("pessoa")]
        public IHttpActionResult postPessoa(Pessoa pessoa)
        {
            NpgsqlConnection conexao = new ConexaoDB().ConexaoPostgreSQL();
            if (conexao != null)
            {
                try
                {
                    string insertPessoa = "insert into pessoa (nome, cpf, sexo, nascimento, mae, pai, data_cadastro, status, estado_civil_fk) " +
                    "values(:nome, :cpf, :sexo, :nascimento, :mae, :pai, :dataCadastro, :status, :estadoCivilFk)";
                    query = new NpgsqlCommand(insertPessoa, conexao);
                    query.Parameters.Add(new NpgsqlParameter("nome", DbType.String));
                    query.Parameters.Add(new NpgsqlParameter("cpf", DbType.String));
                    query.Parameters.Add(new NpgsqlParameter("sexo", DbType.String));
                    query.Parameters.Add(new NpgsqlParameter("nascimento", DbType.DateTime));
                    query.Parameters.Add(new NpgsqlParameter("mae", DbType.String));
                    query.Parameters.Add(new NpgsqlParameter("pai", DbType.String));
                    query.Parameters.Add(new NpgsqlParameter("dataCadastro", DbType.DateTime));
                    query.Parameters.Add(new NpgsqlParameter("status", DbType.String));
                    query.Parameters.Add(new NpgsqlParameter("estadoCivilFk", DbType.Decimal));
                    query.Parameters[0].Value = pessoa.Nome;
                    query.Parameters[1].Value = pessoa.Cpf;
                    query.Parameters[2].Value = pessoa.Sexo;
                    query.Parameters[3].Value = pessoa.Nascimento;
                    query.Parameters[4].Value = pessoa.Mae;
                    query.Parameters[5].Value = pessoa.Pai;
                    query.Parameters[6].Value = DateTime.Now;
                    query.Parameters[7].Value = pessoa.Status;
                    query.Parameters[8].Value = pessoa.EstadoCivilFk;
                    query.ExecuteReader();

                    pessoa.Id = pessoaId();

                    if (pessoa.TelefoneList != null)
                    {
                        
                        foreach (Telefone telefone in pessoa.TelefoneList)
                        {
                            NpgsqlConnection conexao1 = new ConexaoDB().ConexaoPostgreSQL();
                            String insertTelefone = "insert into telefone (numero, pessoa_fk, tipo_telefone_fk) values (:numero, :pessoaFk, :tipoTelefoneFk)";
                            NpgsqlCommand queryTelefone = new NpgsqlCommand(insertTelefone, conexao1);
                            queryTelefone.Parameters.Add(new NpgsqlParameter("numero", DbType.String));
                            queryTelefone.Parameters.Add(new NpgsqlParameter("pessoaFk", DbType.Decimal));
                            queryTelefone.Parameters.Add(new NpgsqlParameter("tipoTelefoneFk", DbType.Decimal));
                            queryTelefone.Parameters[0].Value = telefone.Numero;
                            queryTelefone.Parameters[1].Value = pessoa.Id;
                            queryTelefone.Parameters[2].Value = telefone.TipoTelefoneFk;
                            queryTelefone.ExecuteReader();
                            conexao1.Close();
                        }
                    }
                    else
                    {
                        pessoa.TelefoneList = new List<Telefone>();
                    }

                    if (pessoa.EnderecoList != null)
                    {
                        foreach (Endereco endereco in pessoa.EnderecoList)
                        {
                            NpgsqlConnection conexao2 = new ConexaoDB().ConexaoPostgreSQL();
                            String insertEndereco = "insert into endereco (end_descricao, complemento, bairro, cep, cidade_fk, pessoa_fk, numero) " +
                                "values (:endDescricao, :complemento, :bairro, :cep, :cidadeFk, :pessoaFk, :numero)";
                            NpgsqlCommand queryEndereco = new NpgsqlCommand(insertEndereco, conexao2);
                            queryEndereco.Parameters.Add(new NpgsqlParameter("endDescricao", DbType.String));
                            queryEndereco.Parameters.Add(new NpgsqlParameter("complemento", DbType.String));
                            queryEndereco.Parameters.Add(new NpgsqlParameter("bairro", DbType.String));
                            queryEndereco.Parameters.Add(new NpgsqlParameter("cep", DbType.String));
                            queryEndereco.Parameters.Add(new NpgsqlParameter("cidadeFk", DbType.Decimal));
                            queryEndereco.Parameters.Add(new NpgsqlParameter("pessoaFk", DbType.Decimal));
                            queryEndereco.Parameters.Add(new NpgsqlParameter("numero", DbType.String));
                            queryEndereco.Parameters[0].Value = endereco.EndDescricao;
                            queryEndereco.Parameters[1].Value = endereco.Complemento;
                            queryEndereco.Parameters[2].Value = endereco.Bairro;
                            queryEndereco.Parameters[3].Value = endereco.Cep;
                            queryEndereco.Parameters[4].Value = endereco.CidadeFk;
                            queryEndereco.Parameters[5].Value = pessoa.Id;
                            queryEndereco.Parameters[6].Value = endereco.Numero;
                            queryEndereco.ExecuteReader();
                            conexao2.Close();
                        }
                    }
                    else
                    {
                        pessoa.EnderecoList = new List<Endereco>();
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

            return Ok("Pessoa Cadastrada Com Sucesso.");
        }
        private Decimal pessoaId()
        {
            NpgsqlConnection conexao = new ConexaoDB().ConexaoPostgreSQL();
            Nullable<Decimal> pessoaId = null;
            if (conexao != null)
            {
                String consulta = "select max(pessoa_pk) from pessoa";
                query = new NpgsqlCommand(consulta, conexao);
                try
                {
                    leitor = query.ExecuteReader();
                    while (leitor.Read())
                    {
                        pessoaId = leitor.GetDecimal(0);
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
            return (Decimal)pessoaId;
        }
    }
}
