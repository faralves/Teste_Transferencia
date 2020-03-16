using FastMindBank.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastMindBank.AppService.Messages
{
    public class CriarContaCorrenteRequest
    {
        public Banco Banco { get; set; }

        public Agencia Agencia { get; set; }

        public Int32 Digito { get; set; }

        public string ClienteRef { get; set; }

        public decimal Saldo { get; set; }
    }
}
