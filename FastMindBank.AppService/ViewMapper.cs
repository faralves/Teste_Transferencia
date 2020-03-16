using AutoMapper;
using FastMindBank.Model;
using FastMindBank.AppService.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

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
