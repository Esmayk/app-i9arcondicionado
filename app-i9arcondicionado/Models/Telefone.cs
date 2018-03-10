using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app_i9arcondicionado.Models
{
    public class Telefone
    {
        private Decimal id;
        private String numero;
        private Decimal pessoaFk;
        private Decimal tipoTelefoneFk;

        public Telefone()
        {

        }

        public Telefone(Decimal id, String numero, Decimal pessoaFk, Decimal tipoTelefoneFk)
        {
            this.id = id;
            this.numero = numero;
            this.pessoaFk = pessoaFk;
            this.tipoTelefoneFk = tipoTelefoneFk;
        }

        public Decimal Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public Decimal PessoaFk
        {
            get { return pessoaFk; }
            set { pessoaFk = value; }
        }
        public Decimal TipoTelefoneFk
        {
            get { return tipoTelefoneFk; }
            set { tipoTelefoneFk = value; }
        }
    }
}