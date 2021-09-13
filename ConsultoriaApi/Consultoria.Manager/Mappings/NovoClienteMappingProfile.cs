using AutoMapper;
using Consultoria.Core.Domain;
using Consultoria.Core.Shared.ModelViews;
using System;

namespace Consultoria.Manager.Mappings
{
    public class NovoClienteMappingProfile : Profile
    {
        public NovoClienteMappingProfile()
        {
            // d = destino // o = opção // c = origem
            CreateMap<NovoCliente, Cliente>()
                .ForMember(d => d.Criacao, o=> o.MapFrom(x => DateTime.Now))
                .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));
        }
    }
}
