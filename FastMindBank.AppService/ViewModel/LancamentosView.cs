using System;
using System.Collections.Generic;
using System.Text;

namespace FastMindBank.AppService.ViewModel
{
    public class LancamentosView : BaseEntityView
    {
        public decimal Credito
        { get; set; }
        public decimal Debito
        { get; set; }
        public string Referencia
        { get; set; }
        public DateTime Data
        { get; set; }
        public ContaCorrenteView ContaCorrente { get; set; }
    }
}