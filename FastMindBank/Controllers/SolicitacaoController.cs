using System;
using System.Net.Http;
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


        // POST api/Transferir
        [HttpPost]
        public IActionResult Transferir([FromBody] TransferenciaRequest transferenciaRequest)
        {
            HttpRequestMessage request = new HttpRequestMessage();

            try
            {
                TransferenciaResponse response = _servicoBank.Transferir(transferenciaRequest);
                response.Mensagem = "Transferência efetuada com sucesso!";
                return Ok(response);
            }
            catch (SaldoInsuficienteException ex)
            {

                return BadRequest(ex);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex);
            }
        }
    }
}
