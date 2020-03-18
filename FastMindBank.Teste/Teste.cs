using System.Net;
using System.Net.Http;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;
using FastMindBank.TesteIntegracao.Fixtures;
using FastMindBank.AppService.Messages;
using FastMindBank.Model;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace FastMindBank.TesteIntegracao
{
    public class Teste  
    {
        private readonly TesteContext _testeContext;
        public Teste()
        {
            _testeContext = new TesteContext();
        }

        [Fact]
        public async Task Transferir()
        {
            TransferenciaRequest transferenciaRequest = new TransferenciaRequest();
            transferenciaRequest.ContaCorrenteCredito = new ContaCorrente()
            {
                Banco = new Banco() { CodigoBanco = 237 },
                Agencia = new Agencia() { CodigoAgencia = 1996, DigitoAgencia = 8 },
                Conta = 32961,
                Digito = 4
            };


            transferenciaRequest.ContaCorrenteDebito = new ContaCorrente()
            {
                Banco = new Banco() { CodigoBanco = 341},
                Agencia = new Agencia() { CodigoAgencia = 1234, DigitoAgencia = 5 },
                Conta = 32945,
                Digito = 1
            };

            transferenciaRequest.Montante = 879.54M;

            var jsonContent = JsonConvert.SerializeObject(transferenciaRequest);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new
            MediaTypeHeaderValue("application/json");

            string retorno = string.Empty;
            using (var client = new TesteContext().Client)
            {
                var response = await client.PostAsync("/api/solicitacao", contentString);
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                retorno = response.StatusCode.ToString();
            }

            Assert.Equal("OK",retorno);

        }
    }
}
