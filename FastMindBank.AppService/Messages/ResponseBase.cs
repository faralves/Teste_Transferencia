using System;
using System.Collections.Generic;
using System.Text;

namespace FastMindBank.AppService.Messages
{
    public class ResponseBase
    {
        public bool Successo { get; set; }
        public string Mensagem { get; set; }

    }
}
