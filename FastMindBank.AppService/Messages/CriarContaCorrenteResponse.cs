using FastMindBank.Model;

namespace FastMindBank.AppService.Messages
{
    public class CriarContaCorrenteResponse : ResponseBase
    {
        public ContaCorrente ContaCorrente { get; set; }
    }
}
