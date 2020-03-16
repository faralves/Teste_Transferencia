using System;
using System.Collections.Generic;

namespace FastMindBank.Model
{
    public class ContaCorrente : BaseEntity
    {
        private Banco _banco;
        private Agencia _agencia;
        private decimal _saldo;
        private Int64 _conta;
        private Int32 _digito;
        private string _clienteRef;
        private IList<Lancamentos> _lancamentos;

        public ContaCorrente() 
        {
            _lancamentos = new List<Lancamentos>();
        }

        public ContaCorrente(Banco banco, Agencia agencia, Int64 conta, Int32 digito, decimal saldo, IList<Lancamentos> lancamentos, string clienteRef)
        {
            this.Banco = _banco;
            this.Agencia = _agencia;
            this.Conta = conta;
            this.Digito = digito;
            _saldo = saldo;
            _lancamentos = lancamentos;
            _clienteRef = clienteRef;
        }

        public Banco Banco
        {
            get { return _banco; }
            set { _banco = value; }
        }
        public Agencia Agencia
        {
            get { return _agencia; }
            set { _agencia = value; }
        }
        public Int64 Conta
        {
            get { return _conta; }
            set { _conta = value; }
        }
        public Int32 Digito
        {
            get { return _digito; }
            set { _digito = value; }
        }
        public decimal Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }

        public IList<Lancamentos> Lancamentos 
        {
            get { return _lancamentos; }
            set { _lancamentos = value; }
        }

        public string ClienteRef
        {
            get { return _clienteRef; }
            set { _clienteRef = value; }
        }
        public bool PodeDebitar(decimal montante)
        {
            return (Saldo >= montante);
        }
        public void Debitar(decimal montante, string referencia)
        {
            if (PodeDebitar(montante))
            {
                Saldo -= montante;
                Lancamentos = new List<Lancamentos>();
                Lancamentos.Add(new Lancamentos(0m, montante, referencia, DateTime.Now));
            }
            else
                throw new SaldoInsuficienteException();
        }
        public void Creditar(decimal montante, string refenrencia)
        {
            Saldo += montante;
            Lancamentos = new List<Lancamentos>();
            Lancamentos.Add(new Lancamentos(montante, 0m, refenrencia, DateTime.Now));
        }
        public IEnumerable<Lancamentos> GetTransactions()
        {
            return _lancamentos;
        }
    }
}
