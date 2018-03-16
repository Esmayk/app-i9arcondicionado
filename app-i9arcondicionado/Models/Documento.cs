using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app_i9arcondicionado.Models
{
    public class Documento
    {
        private Decimal id;
        private String numeroDocumento;
        private String orgaoExpedidor;
        private DateTime dataExpedicao;
        private Decimal tipoDocumentoFk;
        private Decimal estadoFk;
        private Decimal pessoaFk;

        public Documento()
        {

        }

        public Documento(Decimal id, String numeroDocumento, String orgaoExpedidor, DateTime dataExpedicao, Decimal tipoDocumentoFk, Decimal estadoFk, Decimal pessoaFk)
        {
            this.Id = id;
            this.NumeroDocumento = numeroDocumento;
            this.OrgaoExpedidor = orgaoExpedidor;
            this.DataExpedicao = dataExpedicao;
            this.TipoDocumentoFk = tipoDocumentoFk;
            this.EstadoFk = estadoFk;
            this.PessoaFk = pessoaFk;
        }
        public Decimal Id
        {
            get { return id; }
            set { id = value; }
        }


        public String NumeroDocumento
        {
            get { return numeroDocumento; }
            set { numeroDocumento = value; }
        }


        public String OrgaoExpedidor
        {
            get { return orgaoExpedidor; }
            set { orgaoExpedidor = value; }
        }


        public DateTime DataExpedicao
        {
            get { return dataExpedicao; }
            set { dataExpedicao = value; }
        }


        public Decimal TipoDocumentoFk
        {
            get { return tipoDocumentoFk; }
            set { tipoDocumentoFk = value; }
        }


        public Decimal EstadoFk
        {
            get { return estadoFk; }
            set { estadoFk = value; }
        }

        public Decimal PessoaFk
        {
            get { return pessoaFk; }
            set { pessoaFk = value; }
        }

    }
}