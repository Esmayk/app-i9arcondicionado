using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app_i9arcondicionado.Models
{
    public class TipoTelefone
    {
        private Decimal id;
        private String descricao;

        public TipoTelefone()
        {

        }
        public TipoTelefone(Decimal id, String descricao)
        {
            this.Id = id;
            this.Descricao = descricao;
        }
        public Decimal Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
    }
}