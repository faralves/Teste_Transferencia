using AutoMapper;
using FastMindBank.Model;
using FastMindBank.AppService.ViewModel;

namespace FastMindBank.AppService
{
    public class ViewMapper : Profile
    {
        public ViewMapper()
        {
            CreateMap<Banco, BancoView >();
            CreateMap<Agencia, AgenciaView >();
            CreateMap<ContaCorrente, ContaCorrenteView >();
            CreateMap<Lancamentos, LancamentosView>();
        }
    }
}
