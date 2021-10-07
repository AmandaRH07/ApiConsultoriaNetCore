using AutoMapper;
using Consultoria.Core.Domain;
using Consultoria.Core.Shared.ModelViews;
using Consultoria.Core.Shared.ModelViews.Cliente;
using System;

namespace Consultoria.Manager.Mappings
{
    public class NovoClienteMappingProfile : Profile
    {
        public NovoClienteMappingProfile()
        {
            CreateMap<NovoCliente, Cliente>()
                .ForMember(d => d.Criacao, o=> o.MapFrom(x => DateTime.Now))
                .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));

            CreateMap<NovoEndereco, Endereco>();
            CreateMap<NovoTelefone, Telefone>();
            CreateMap<Cliente, ClienteView>();
            CreateMap<Endereco, EnderecoView>();
            CreateMap<Telefone, TelefoneView>();
        }
    }
}
