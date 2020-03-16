using FastMindBank.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastMindBank.AppService.Messages
{
    public class CriarContaCorrenteResponse : ResponseBase
    {
        public ContaCorrente ContaCorrente { get; set; }
    }
}
