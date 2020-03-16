using FastMindBank.Model.Contrato;

namespace FastMindBank.Model
{
    public class ServicoContaCorrente
    {
        private IFastMindBankRepository _fastMindBankRepository;

        public ServicoContaCorrente()
        {

        }

        public ServicoContaCorrente(IFastMindBankRepository bankAccountRepository)
        {
            _fastMindBankRepository = bankAccountRepository;
        }
        public void Transferir(ContaCorrente contaCorrenteCreditar, ContaCorrente contaCorrenteDebitar, decimal montante)
        {
            ContaCorrente _contaCorrenteCreditar = _fastMindBankRepository.PesquisarConta(contaCorrenteCreditar.Banco, contaCorrenteCreditar.Agencia, contaCorrenteCreditar.Conta, contaCorrenteCreditar.Digito);
            ContaCorrente _contaCorrenteDebitar = _fastMindBankRepository.PesquisarConta(contaCorrenteDebitar.Banco, contaCorrenteDebitar.Agencia, contaCorrenteDebitar.Conta, contaCorrenteDebitar.Digito);
            if (_contaCorrenteDebitar.PodeDebitar(montante))
            {
                _contaCorrenteDebitar.ClienteRef = "Recebida Transferência do Banco: " + _contaCorrenteDebitar.Banco.CodigoBanco.ToString() + " Agência: " + _contaCorrenteDebitar.Agencia.CodigoAgencia.ToString() + " Conta: " + _contaCorrenteDebitar.Conta.ToString() + "-" + _contaCorrenteDebitar.Digito.ToString();
                _contaCorrenteCreditar.Creditar(montante, _contaCorrenteDebitar.ClienteRef );

                _contaCorrenteCreditar.ClienteRef = "Transferência para o Banco: " + _contaCorrenteCreditar.Banco.CodigoBanco.ToString() + " Agência: " + _contaCorrenteCreditar.Agencia.CodigoAgencia.ToString() + " Conta: " + _contaCorrenteCreditar.Conta.ToString() + "-" + _contaCorrenteCreditar.Digito.ToString();
                _contaCorrenteDebitar.Debitar(montante,  _contaCorrenteCreditar.ClienteRef );
                _fastMindBankRepository.Save(_contaCorrenteCreditar);
                _fastMindBankRepository.Save(_contaCorrenteDebitar);
            }
            else
            {
                throw new SaldoInsuficienteException();
            }
        }
    }
}
