using System;
using System.Collections.Generic;

namespace FastMindBank.AppService.ViewModel
{
    public class ContaCorrenteView : BaseEntityView
    {
        public BancoView Banco { get; set; }

        public AgenciaView Agencia { get; set; }

        public Int64 Conta { get; set; }

        public Int32 Digito { get; set; }

        public decimal Saldo { get; set; }

        public List<LancamentosView> Lancamentos { get; set; }

        public string NomeCliente { get; set; }

    }
}
