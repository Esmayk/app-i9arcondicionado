using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using app_i9arcondicionado.Models;
using Newtonsoft.Json;
using Npgsql;

namespace app_i9arcondicionado.Controllers
{
    [RoutePrefix("api/i9arcondicionado")]
    public class PessoaController : ApiController
    {
        private NpgsqlDataReader leitor;
        private NpgsqlCommand query;

<<<<<<< HEAD
        [HttpDelete]
        [Route("pessoa/{id}")]
        public IHttpActionResult deletePessoa(Decimal id)
        {
            NpgsqlConnection conexao = new ConexaoDB().ConexaoPostgreSQL();
            if (conexao != null)
            {
                try
                {
                    String delete = "update pessoa set status = 'I' where pessoa_pk =" + id;
                    query = new NpgsqlCommand(delete, conexao);
                    query.ExecuteReader();

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
            return Ok("Cadastro removido com sucesso.");
        }

        [HttpGet]
        [Route("pessoa")]
=======
        [HttpGet, Route("pessoa")]
>>>>>>> 88ec84255eeaca02d57a682b58b36417c86e75fa
        public IHttpActionResult getPessoa()
        {
            List<String> jsonList = new List<string>();
            List<Object> objetos = new List<Object>();
            NpgsqlConnection conexao = new ConexaoDB().ConexaoPostgreSQL();
            if (conexao != null)
            {
                try
                {
                    String consulta = "select row_to_json(p) from ( " +
                                " select pe.pessoa_pk as id, pe.nome, pe.nascimento, " +
                                " pe.cpf, d.numero_documento as rg " +
                                " from pessoa pe " +
                                " inner join documento d on d.pessoa_fk = pe.pessoa_pk" +
                                " where pe.status = 'A' order by pe.nome)p";
                    query = new NpgsqlCommand(consulta, conexao);
                    leitor = query.ExecuteReader();
                    while (leitor.Read())
                    {
                        jsonList.Add(leitor.GetString(0));
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
            foreach(String st in jsonList)
            {
                objetos.Add(JsonConvert.DeserializeObject(st));
            }
            
            return Ok(objetos);
        }

        [HttpGet, Route("pessoa/{id}")]
        public IHttpActionResult getPessoPorId(Decimal id)
        {
            String json = null;
            NpgsqlConnection conexao = new ConexaoDB().ConexaoPostgreSQL();
            if (conexao != null)
            {
                try
                {
                    String consulta = "select row_to_json(p) " +
                                       "from( " +
                                       "  select pessoa_pk as id, nome, cpf, sexo, nascimento, mae, pai, data_cadastro as dataCadastro, status, estado_civil_fk as estadoCivilFk, " +
                                       "    ( " +
                                       "      select array_to_json(array_agg(row_to_json(te))) " +
                                       "      from(" +
                                       "        select telefone_pk as id, numero, pessoa_fk as pessoaFk, " +
                                       "        tipo_telefone_fk as tipoTelefoneFk  " +
                                       "        from telefone " +
                                       "        where telefone.pessoa_fk = pessoa.pessoa_pk  " +
                                       "      ) te " +
                                       "    ) as telefoneList, " +
                                       "      ( " +
                                       "      select array_to_json(array_agg(row_to_json(en)))  " +
                                       "      from(" +
                                       "        select endereco_pk as id, end_descricao as endDescricao, " +
                                       "        complemento, bairro, cep, cidade_fk as cidadeFk, " +
                                       "        pessoa_fk as pessoaFk, numero  " +
                                       "        from endereco  " +
                                       "        where endereco.pessoa_fk = pessoa.pessoa_pk  " +
                                       "      ) en  " +
                                       "    ) as enderecoList, " +
                                       "      ( " +
                                       "      select array_to_json(array_agg(row_to_json(doc))) " +
                                       "      from(" +
                                       "        select documento_pk as id, numero_documento as numeroDocumento, " +
                                       "        orgao_expedidor as orgaoExpedidor, data_expedicao as dataExpedicao, " +
                                       "        tipo_documento_fk as tipoDocumentoFk, estado_fk as estadoFk, " +
                                       "        pessoa_fk as pessoaFk " +
                                       "        from documento " +
                                       "        where documento.pessoa_fk = pessoa.pessoa_pk " +
                                       "      ) doc " +
                                       "    ) as documentoList, " +
                                       "    (" +
                                       "    select row_to_json(pt)" +
                                       "    from(" +
                                       "      select pessoa_tipo_pk as id, pessoa_fk as pessoaFk, tipo_pessoa_fk as tipoPessoaFk" +
                                       "      from pessoa_tipo" +
                                       "      where pessoa_tipo.pessoa_fk = pessoa.pessoa_pk" +
                                       "        )pt" +
                                       "    ) as pessoaTipoFk" +
                                       "  from pessoa  " +
                                       "  where pessoa_pk =:id  " +
                                       ") p";
                    query = new NpgsqlCommand(consulta, conexao);
                    query.Parameters.Add(new NpgsqlParameter("id", DbType.Decimal));
                    query.Parameters[0].Value = id;
                    leitor = query.ExecuteReader();
                    while (leitor.Read())
                    {
                        json = leitor.GetString(0);
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
            var result = JsonConvert.DeserializeObject<Pessoa>(json);
            return Ok(result);
        }

        [HttpPost, Route("pessoa")]
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

                    if (pessoa.DocumentoList != null)
                    {
                        foreach (Documento documento in pessoa.DocumentoList)
                        {
                            NpgsqlConnection conexao3 = new ConexaoDB().ConexaoPostgreSQL();
                            String insertEndereco = "insert into documento (numero_documento, orgao_expedidor, data_expedicao, tipo_documento_fk, estado_fk, pessoa_fk) " +
                                "values (:numeroDocumento, :orgaoExpedidor, :dataExpedicao, :tipoDocumentoFk, :estadoFk, :pessoaFk)";
                            NpgsqlCommand queryEndereco = new NpgsqlCommand(insertEndereco, conexao3);
                            queryEndereco.Parameters.Add(new NpgsqlParameter("numeroDocumento", DbType.String));
                            queryEndereco.Parameters.Add(new NpgsqlParameter("orgaoExpedidor", DbType.String));
                            queryEndereco.Parameters.Add(new NpgsqlParameter("dataExpedicao", DbType.DateTime));
                            queryEndereco.Parameters.Add(new NpgsqlParameter("tipoDocumentoFk", DbType.Decimal));
                            queryEndereco.Parameters.Add(new NpgsqlParameter("estadoFk", DbType.Decimal));
                            queryEndereco.Parameters.Add(new NpgsqlParameter("pessoaFk", DbType.Decimal));
                            queryEndereco.Parameters[0].Value = documento.NumeroDocumento;
                            queryEndereco.Parameters[1].Value = documento.OrgaoExpedidor;
                            queryEndereco.Parameters[2].Value = documento.DataExpedicao;
                            queryEndereco.Parameters[3].Value = documento.TipoDocumentoFk;
                            queryEndereco.Parameters[4].Value = documento.EstadoFk;
                            queryEndereco.Parameters[5].Value = pessoa.Id;
                            queryEndereco.ExecuteReader();
                            conexao3.Close();
                        }
                    }
                    else
                    {
                        pessoa.DocumentoList = new List<Documento>();
                    }

                    if (pessoa.PessoaTipoFk != null)
                    {
                        NpgsqlConnection conexao4 = new ConexaoDB().ConexaoPostgreSQL();
                        String insertPessoaTipo = "insert into pessoa_tipo (pessoa_fk, tipo_pessoa_fk) " +
                            "values (:pessoaFk, :tipoPessoaFk)";
                        NpgsqlCommand queryPessoaTipo = new NpgsqlCommand(insertPessoaTipo, conexao4);
                        queryPessoaTipo.Parameters.Add(new NpgsqlParameter("pessoaFk", DbType.Decimal));
                        queryPessoaTipo.Parameters.Add(new NpgsqlParameter("tipoPessoaFk", DbType.Decimal));
                        queryPessoaTipo.Parameters[0].Value = pessoa.Id;
                        queryPessoaTipo.Parameters[1].Value = pessoa.PessoaTipoFk.TipoPessoaFk;
                        queryPessoaTipo.ExecuteReader();
                        conexao4.Close();
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
