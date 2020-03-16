using System;

namespace FastMindBank.Model
{
    public class SaldoInsuficienteException : ApplicationException
    {
        public SaldoInsuficienteException()
        {

        }

        public SaldoInsuficienteException(string message) : base(message)
        {

        }

        public SaldoInsuficienteException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
