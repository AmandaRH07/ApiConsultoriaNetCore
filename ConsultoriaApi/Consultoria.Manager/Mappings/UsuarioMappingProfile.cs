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
        }
    }
}
