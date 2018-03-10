using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app_i9arcondicionado.Models
{
    public class Endereco
    {
        private Decimal id;
        private String endDescricao;
        private String complemento;
        private String bairro;
        private String cep;
        private Decimal cidadeFk;
        private Decimal pessoaFk;
        private String numero;

        public Endereco()
        {

        }

        public Endereco(Decimal id, String endDescricao, String complemento, String bairro, String cep, Decimal cidadeFk, Decimal pessoaFk, String numero)
        {
            this.Id = id;
            this.EndDescricao = endDescricao;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.Cep = cep;
            this.CidadeFk = cidadeFk;
            this.PessoaFk = pessoaFk;
            this.Numero = numero;
        }
        public Decimal Id
        {
            get { return id; }
            set { id = value; }
        }

        public String EndDescricao
        {
            get { return endDescricao; }
            set { endDescricao = value; }
        }

        public String Complemento
        {
            get { return complemento; }
            set { complemento = value; }
        }

        public String Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        public String Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        public Decimal CidadeFk
        {
            get { return cidadeFk; }
            set { cidadeFk = value; }
        }

        public Decimal PessoaFk
        {
            get { return pessoaFk; }
            set { pessoaFk = value; }
        }

        public String Numero
        {
            get { return numero; }
            set { numero = value; }
        }
    }
}