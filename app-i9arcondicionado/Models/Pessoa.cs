using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app_i9arcondicionado.Models
{
    public class Pessoa
    {
        private Decimal id;
        private String nome;
        private String cpf;
        private String sexo;
        private DateTime nascimento;
        private String mae;
        private String pai;
        private DateTime dataCadastro;
        private String status;
        private Decimal estadoCivilFk;
        private List<Telefone> telefoneList;
        private List<Endereco> enderecoList;
        private PessoaTipo pessoaTipoFk;

        public Pessoa()
        {

        }
        public Pessoa(Decimal id, String nome, String cpf, String sexo, DateTime nascimento, String mae, String pai, DateTime dataCadastro, String status, Decimal estadoCivilFk, List<Telefone> telefoneList, List<Endereco> enderecoList, PessoaTipo pessoaTipoFk)
        {
            this.Id = id;
            this.Cpf = cpf;
            this.Sexo = sexo;
            this.Nascimento = nascimento;
            this.Mae = mae;
            this.Pai = pai;
            this.DataCadastro = dataCadastro;
            this.Status = status;
            this.EstadoCivilFk = estadoCivilFk;
            this.PessoaTipoFk = pessoaTipoFk;
        }
        public Decimal Id
        {
            get { return id; }
            set { id = value; }
        }



        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }


        public String Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }



        public String Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }



        public DateTime Nascimento
        {
            get { return nascimento; }
            set { nascimento = value; }
        }


        public String Mae
        {
            get { return mae; }
            set { mae = value; }
        }


        public String Pai
        {
            get { return pai; }
            set { pai = value; }
        }


        public DateTime DataCadastro
        {
            get { return dataCadastro; }
            set { dataCadastro = value; }
        }


        public String Status
        {
            get { return status; }
            set { status = value; }
        }

        public Decimal EstadoCivilFk
        {
            get { return estadoCivilFk; }
            set { estadoCivilFk = value; }
        }

        public List<Telefone> TelefoneList
        {
            get { return telefoneList; }
            set { telefoneList = value; }
        }

        public List<Endereco> EnderecoList
        {
            get { return enderecoList; }
            set { enderecoList = value; }
        }

        public PessoaTipo PessoaTipoFk
        {
            get { return pessoaTipoFk; }
            set { pessoaTipoFk = value; }
        }
    }
}