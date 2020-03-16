using System;

namespace FastMindBank.Model
{
    public class Lancamentos : BaseEntity
    {
        public Lancamentos(decimal credito, decimal debito, string referencia, DateTime data)
        {
            this.Credito = credito;
            this.Debito = debito;
            this.Referencia = referencia;
            this.Data = data;
        }

        public Lancamentos(decimal credito, decimal debito, string referencia, DateTime data, ContaCorrente contaCorrente)
        {
            this.Credito = credito;
            this.Debito = debito;
            this.Referencia = referencia;
            this.Data = data;
            this.ContaCorrente = contaCorrente;
        }
        public decimal Credito
        { get; set; }
        public decimal Debito
        { get; set; }
        public string Referencia
        { get; set; }
        public DateTime Data
        { get; set; }
        public ContaCorrente ContaCorrente { get; set; }
    }
}
