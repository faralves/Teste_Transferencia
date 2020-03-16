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

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
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
            catch (SaldoInsuficienteException ex)
            {

                return request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ex) 
            {
                return request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
