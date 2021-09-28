using AutoMapper;
using Consultoria.Core.Domain;
using Consultoria.Core.Shared.ModelViews;

namespace Consultoria.Manager.Mappings
{
    public class NovoMedicoMappingProfile : Profile
    {
        public NovoMedicoMappingProfile()
        {
            CreateMap<NovoMedico, Medico>();
            CreateMap<Medico, MedicoView>();
            CreateMap<Especialidade, ReferenciaEspecialidade>().ReverseMap();
            CreateMap<Especialidade, EspecialidadeView>().ReverseMap();
            CreateMap<AlteraMedico, Medico>().ReverseMap();
        }
    }
}
