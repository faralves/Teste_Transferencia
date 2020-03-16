using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FastMindBank.AppService;
using FastMindBank.AppService.Messages;
using FastMindBank.Model;
using Microsoft.AspNetCore.Mvc;

namespace FastMindBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoController : ControllerBase
    {
        ApplicationFastMindBankService _servicoBank = new ApplicationFastMindBankService();

        public SolicitacaoController(ApplicationFastMindBankService servicoBank)
        {
            _servicoBank = servicoBank;
        }


        // POST api/values
        [HttpPost]
        public HttpResponseMessage Transferir([FromBody] TransferenciaRequest transferenciaRequest)
        {
            HttpRequestMessage request = new HttpRequestMessage();

            try
            {
                TransferenciaResponse response = _servicoBank.Transferir(transferenciaRequest);
                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (SaldoInsuficienteException )
            {

                return request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ) 
            {
                return request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
