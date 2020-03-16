using FastMindBank.Model;
using FastMindBank.Model.Contrato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastMindBank.Repository
{
    public class FastMindBankRepository : IFastMindBankRepository
    {
        private FastMindBankContext context = new FastMindBankContext();

        public FastMindBankRepository()
        {

        }
        public FastMindBankRepository(FastMindBankContext ctx)
        {
            context = ctx;

        }
        public void Add(ContaCorrente contaCorrente)
        {
            context.ContaCorrente.Add(contaCorrente);

            context.SaveChanges();
            updateOrCreateTransaction(contaCorrente);
        }

        public void Save(ContaCorrente contaCorrente)
        {
            ContaCorrente conta = PesquisarConta(contaCorrente.Banco, contaCorrente.Agencia, contaCorrente.Conta, contaCorrente.Digito);
            conta.ClienteRef = contaCorrente.ClienteRef;
            conta.Saldo = contaCorrente.Saldo;

            foreach (Lancamentos lancamento in conta.Lancamentos)
                lancamento.ContaCorrente = conta;

            context.ContaCorrente.Update(conta);
            //context.SaveChanges();
            updateOrCreateTransaction(contaCorrente);
        }

        public IEnumerable<ContaCorrente> PesquisarTodasContas()
        {
            var ListaDeContas = context.ContaCorrente.Include(x => x.Lancamentos).ToList();

            foreach (ContaCorrente contaCorrente in ListaDeContas)
            {
                if (contaCorrente.Lancamentos != null)
                {
                    foreach (Lancamentos lancamentos in contaCorrente.Lancamentos)
                    {
                        lancamentos.ContaCorrente = null;
                    }
                }
            }
            return ListaDeContas;

        }

        public ContaCorrente PesquisarConta(Banco banco, Agencia agencia, Int64 conta, Int32 digito)
        {
            return context.ContaCorrente.Include(y => y.Lancamentos).Include(z => z.Agencia).Include(b => b.Banco).FirstOrDefault(x => x.Banco.CodigoBanco == banco.CodigoBanco && x.Agencia.CodigoAgencia == agencia.CodigoAgencia && x.Agencia.DigitoAgencia == agencia.DigitoAgencia && x.Conta == conta && x.Digito == digito);
        }

        private void updateOrCreateTransaction(ContaCorrente contaCorrente)
        {
            ContaCorrente conta = PesquisarConta(contaCorrente.Banco, contaCorrente.Agencia, contaCorrente.Conta, contaCorrente.Digito);
            var lancamentos = context.Lancamentos.Where(x => x.ContaCorrente.Banco == contaCorrente.Banco && x.ContaCorrente.Agencia == contaCorrente.Agencia && x.ContaCorrente.Conta == contaCorrente.Conta && x.ContaCorrente.Digito == contaCorrente.Digito).ToList();


            foreach (Lancamentos lancamento in contaCorrente.Lancamentos)
            {
                if (lancamento?.Id == null || lancamento?.Id <= 0 )
                {
                    lancamento.ContaCorrente = conta;

                    context.Lancamentos.Add(lancamento);
                    context.SaveChanges();

                }
            }

        }
    }
}
