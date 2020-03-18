using AutoMapper;
using FastMindBank.AppService.Messages;
using FastMindBank.Model;
using FastMindBank.Model.Contrato;
using System.Collections.Generic;

namespace FastMindBank.AppService
{
    public class ApplicationFastMindBankService
    {
        private ServicoContaCorrente _servicoContaCorrente = new ServicoContaCorrente();
        private IFastMindBankRepository _iFastMindBankRepository;
        private readonly IMapper _mapper;

        public ApplicationFastMindBankService()
        { }

        public ApplicationFastMindBankService(ServicoContaCorrente servicoContaCorrente, IFastMindBankRepository iFastMindBankRepository, IMapper mapper)
        {
            _servicoContaCorrente = servicoContaCorrente;
            _iFastMindBankRepository = iFastMindBankRepository;
            _mapper = mapper;
        }

        public CriarContaCorrenteResponse CriarContaCorrente(CriarContaCorrenteRequest criarContaCorrenteRequest)
        {
            try
            {
                CriarContaCorrenteResponse criarContaCorrenteResponse = new CriarContaCorrenteResponse();
                ContaCorrente contaCorrente = new ContaCorrente(criarContaCorrenteRequest.Banco, criarContaCorrenteRequest.Agencia, 0, criarContaCorrenteRequest.Digito, criarContaCorrenteRequest.Saldo, new List<Lancamentos>(), criarContaCorrenteRequest.NomeCliente);
                _iFastMindBankRepository.Add(contaCorrente);
                return criarContaCorrenteResponse;
            }
            catch 
            {
                throw;
            }
        }

        public TransferenciaResponse Transferir(TransferenciaRequest transferenciaRequest)
        {
            TransferenciaResponse response = new TransferenciaResponse();
            try
            {
                _servicoContaCorrente.Transferir(transferenciaRequest.ContaCorrenteCredito, transferenciaRequest.ContaCorrenteDebito, transferenciaRequest.Montante);
                response.Successo = true;
                return response;
            }
            catch 
            {
                throw;
            }
        }

    }
}
