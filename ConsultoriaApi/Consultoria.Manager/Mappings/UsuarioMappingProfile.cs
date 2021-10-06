using AutoMapper;
using Consultoria.Core.Domain;
using Consultoria.Core.Shared.ModelViews.Usuario;

namespace Consultoria.Manager.Mappings
{
    public class UsuarioMappingProfile : Profile
    {
        public UsuarioMappingProfile()
        {
            CreateMap<Usuario, UsuarioView>().ReverseMap();
            CreateMap<Usuario, NovoUsuario>().ReverseMap();
            CreateMap<Usuario, UsuarioLogado>().ReverseMap();
            CreateMap<Funcao, FuncaoView>().ReverseMap();
            CreateMap<Funcao, ReferenciaFuncao>().ReverseMap();
        }
    }
}
