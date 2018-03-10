﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace app_i9arcondicionado.Controllers
{
    [RoutePrefix("api/i9arcondicionado")]
    public class PessoaController : ApiController
    {
        [HttpPost]
        [Route("pessoa")]
        public IHttpActionResult postPessoa()
        {
            return Ok("Pessoa Cadastrada Com Sucesso.");
        }
    }
}
