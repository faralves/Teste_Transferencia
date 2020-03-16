using FastMindBank.AppService;
using FastMindBank.AppService.Messages;
using FastMindBank.Model;
using FastMindBank.Model.Contrato;
using FastMindBank.Repository;
using System;
using System.Net;
using System.Net.Http;
using Xunit;

namespace FastMindBank.Teste
{
    public class Teste  
    {
        ApplicationFastMindBankService _servicoBank = new ApplicationFastMindBankService();
        IFastMindBankRepository _fastMindBankRepository = new FastMindBankRepository();

        public Teste()
        {
            _servicoBank = new ApplicationFastMindBankService();
        }

        [Fact]
        public void Transferir()
        {

            TransferenciaRequest transferenciaRequest = new TransferenciaRequest();
            transferenciaRequest.ContaCorrenteCredito = new ContaCorrente() { 
                                                                                Banco = new Banco() { CodigoBanco = 237 }, 
                                                                                Agencia = new Agencia() { CodigoAgencia = 1996, DigitoAgencia =8}, 
                                                                                Conta = 32961,
                                                                                Digito = 4
                                                                            };


            transferenciaRequest.ContaCorrenteDebito = new ContaCorrente()
            {
                Banco = new Banco() { CodigoBanco = 341},
                Agencia = new Agencia() { CodigoAgencia = 1234, DigitoAgencia = 4 },
                Conta = 32945,
                Digito = 1
            };
            transferenciaRequest.Montante = 879.54M;

            TransferenciaResponse response =  new TransferenciaResponse();
            response = _servicoBank.Transferir(transferenciaRequest);


            Assert.True(response.Successo);

        }
    }
}
