using System;
using System.Collections.Generic;

namespace FastMindBank.Model.Contrato
{
    public interface IFastMindBankRepository
    {
        void Add(ContaCorrente contaCorrente);
        void Save(ContaCorrente contaCorrente);
        IEnumerable<ContaCorrente> PesquisarTodasContas();
        ContaCorrente PesquisarConta(Banco banco, Agencia agencia, Int64 Conta, Int32 Digito);
    }
}
