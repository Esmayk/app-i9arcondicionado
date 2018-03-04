using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app_i9arcondicionado.Models
{
    public class Estado
    {
        private Decimal id;
        private String nome;
        private Char sigla;

        public Estado()
        {

        }
        public Estado(Decimal id, String nome, Char sigla)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sigla = sigla;
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
        public Char Sigla
        {
            get { return sigla; }
            set { sigla = value; }
        }
    }
}