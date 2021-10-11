using AutoMapper;
using Consultoria.Core.Domain;
using Consultoria.Core.Shared.ModelViews;
using Consultoria.Core.Shared.ModelViews.Cliente;
using Consultoria.FakerData.ClienteData;
using Consultoria.Manager.Implemantation;
using Consultoria.Manager.Interfaces;
using Consultoria.Manager.Mappings;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Consultoria.Manager.Tests.Manager
{
    public class ClienteManagerTest
    {
        private readonly IClienteRepository clienteRepository;
        private readonly ILogger<ClienteManager> logger;
        private readonly IMapper mapper;
        private readonly IClienteManager clienteManager;
        private readonly Cliente Cliente;
        private readonly NovoCliente NovoCliente;
        private readonly AlteraCliente AlteraCliente;
        private readonly ClienteFaker ClienteFaker;
        private readonly NovoClienteFaker NovoClienteFaker;
        private readonly AlteraClienteFaker AlteraClienteFaker;

        public ClienteManagerTest()
        {
            clienteRepository = Substitute.For<IClienteRepository>();
            logger = Substitute.For<ILogger<ClienteManager>>();
            mapper = new MapperConfiguration(p => p.AddProfile<NovoClienteMappingProfile>()).CreateMapper();
            clienteManager = new ClienteManager(clienteRepository, mapper, logger);
            ClienteFaker = new ClienteFaker();
            NovoClienteFaker = new NovoClienteFaker();
            AlteraClienteFaker = new AlteraClienteFaker();

            Cliente = ClienteFaker.Generate();
            NovoCliente = NovoClienteFaker.Generate();
            AlteraCliente = AlteraClienteFaker.Generate();
        }

        [Fact]
        public async Task GetClientesAsync_Sucesso()
        {
            var listaClientes = ClienteFaker.Generate(10);
            clienteRepository.GetClientesAsync().Returns(listaClientes);
            var controle = mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteView>>(listaClientes);
            var retorno = await clienteManager.GetClientesAsync();

            await clienteRepository.Received().GetClientesAsync();
            retorno.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task GetClientesAsync_Vazio()
        {
            clienteRepository.GetClientesAsync().Returns(new List<Cliente>());

            var retorno = await clienteManager.GetClientesAsync();

            await clienteRepository.Received().GetClientesAsync();
            retorno.Should().BeEquivalentTo(new List<Cliente>());
        }

        [Fact]
        public async Task GetClienteAsync_Sucesso()
        {
            clienteRepository.GetClienteAsync(Arg.Any<int>()).Returns(Cliente);
            var controle = mapper.Map<ClienteView>(Cliente);
            var retorno = await clienteManager.GetClienteAsync(Cliente.Id);

            await clienteRepository.Received().GetClienteAsync(Arg.Any<int>());
            retorno.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task GetClienteAsync_NaoEncontrado()
        {
            clienteRepository.GetClienteAsync(Arg.Any<int>()).Returns(new Cliente());
            var controle = mapper.Map<ClienteView>(new Cliente());
            var retorno = await clienteManager.GetClienteAsync(1);

            await clienteRepository.Received().GetClienteAsync(Arg.Any<int>());
            retorno.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task InsertClienteAsync_Sucesso()
        {
            clienteRepository.InsertClienteAsync(Arg.Any<Cliente>()).Returns(Cliente);
            var controle = mapper.Map<ClienteView>(Cliente);
            var retorno = await clienteManager.InsertClienteAsync(NovoCliente);

            await clienteRepository.Received().InsertClienteAsync(Arg.Any<Cliente>());
            retorno.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task UpdateClienteAsync_Sucesso()
        {
            clienteRepository.UpdateClienteAsync(Arg.Any<Cliente>()).Returns(Cliente);
            var controle = mapper.Map<ClienteView>(Cliente);
            var retorno = await clienteManager.UpdateClienteAsync(AlteraCliente);

            await clienteRepository.Received().UpdateClienteAsync(Arg.Any<Cliente>());
            retorno.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task UpdateClienteAsync_NaoEncontrado()
        {
            clienteRepository.UpdateClienteAsync(Arg.Any<Cliente>()).ReturnsNull();

            var retorno = await clienteManager.UpdateClienteAsync(AlteraCliente);

            await clienteRepository.Received().UpdateClienteAsync(Arg.Any<Cliente>());
            retorno.Should().BeNull();
        }

        [Fact]
        public async Task DeleteClienteAsync_Sucesso()
        {
            clienteRepository.DeleteClienteAsync(Arg.Any<int>()).Returns(Cliente);
            var controle = mapper.Map<ClienteView>(Cliente);
            var retorno = await clienteManager.DeleteClienteAsync(Cliente.Id);

            await clienteRepository.Received().DeleteClienteAsync(Arg.Any<int>());
            retorno.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task DeleteClienteAsync_NaoEncontrado()
        {
            clienteRepository.DeleteClienteAsync(Arg.Any<int>()).ReturnsNull();

            var retorno = await clienteManager.DeleteClienteAsync(1);

            await clienteRepository.Received().DeleteClienteAsync(Arg.Any<int>());
            retorno.Should().BeNull();
        }
    }
}
