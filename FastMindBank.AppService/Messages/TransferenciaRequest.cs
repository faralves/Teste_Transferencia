﻿using FastMindBank.Model;

namespace FastMindBank.AppService.Messages
{
    public class TransferenciaRequest
    {
        public ContaCorrente ContaCorrenteCredito { get; set; }
        public ContaCorrente ContaCorrenteDebito { get; set; }
        public decimal Montante { get; set; }
    }
}
