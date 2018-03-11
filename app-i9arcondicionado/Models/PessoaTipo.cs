using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app_i9arcondicionado.Models
{
    public class PessoaTipo
    {
        private Decimal id;
        private Decimal pessoaFk;
        private Decimal tipoPessoaFk;
        
        public PessoaTipo()
        {

        }

        public PessoaTipo(Decimal id, Decimal pessoaFk, Decimal tipoPessoaFk)
        {
            this.Id = id;
            this.PessoaFk = pessoaFk;
            this.TipoPessoaFk = tipoPessoaFk;
        }
        public Decimal Id
        {
            get { return id; }
            set { id = value; }
        }


        public Decimal PessoaFk
        {
            get { return pessoaFk; }
            set { pessoaFk = value; }
        }

        public Decimal TipoPessoaFk
        {
            get { return tipoPessoaFk; }
            set { tipoPessoaFk = value; }
        }

    }
}