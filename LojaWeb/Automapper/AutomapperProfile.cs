using AutoMapper;
using LojaWeb.Models;
using LojaWeb.Models.ModeloDados;

namespace LojaWeb.Automapper
{
    //criando classe de configuracao do Automapper
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            //faz o biding entre as duas classes, Model e ViewModel
            CreateMap<ClienteModel, ClienteViewModel>().ReverseMap();
        }
    }
}
