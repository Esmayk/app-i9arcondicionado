using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app_i9arcondicionado.Models
{
    public class Cidade
    {
        private Decimal id;
        private String nome;
        private Decimal estadoFk;

        public Cidade()
        {

        }

        public Cidade(Decimal id, String nome, Decimal estadoFk)
        {
            this.Id = id;
            this.nome = nome;
            this.estadoFk = estadoFk;
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
        public Decimal EstadoFk
        {
            get { return estadoFk; }
            set { estadoFk = value; }
        }

    }
}