using Consultoria.Core.Shared.ModelViews;
using Consultoria.Core.Shared.ModelViews.Cliente;
using Consultoria.FakerData.ClienteData;
using Consultoria.Manager.Interfaces;
using Consultoria.WebApi.Controller;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Consultoria.WebApi.Tests
{
    public class ClientesControllerTest
    {
        private readonly IClienteManager manager;
        private readonly ILogger<ClientesController> logger;
        private readonly ClientesController controller;
        private readonly ClienteView clienteView;
        private readonly List<ClienteView> listaClienteView;
        private readonly NovoCliente novoCliente;

        public ClientesControllerTest()
        {
            manager = Substitute.For<IClienteManager>();
            logger = Substitute.For<ILogger<ClientesController>>();
            controller = new ClientesController(manager, logger);

            clienteView = new ClienteViewFaker().Generate();
            listaClienteView = new ClienteViewFaker().Generate(10);
            novoCliente = new NovoClienteFaker().Generate();
        }

        [Fact]
        public async Task Get_Clientes_OK()
        {
            //Arrange
            var controle = new List<ClienteView>();
            listaClienteView.ForEach(p => controle.Add(p.CloneTipado()));
            manager.GetClientesAsync().Returns(listaClienteView);

            //Act
            var result = (ObjectResult)await controller.Get();

            //Assert
            await manager.Received().GetClientesAsync();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task Get_Clientes_NotFound()
        {
            //Arrange
            manager.GetClientesAsync().Returns(new List<ClienteView>());

            //Act
            var result = (StatusCodeResult)await controller.Get();

            //Assert
            await manager.Received().GetClientesAsync();
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Get_ClienteById_OK()
        {
            manager.GetClienteAsync(Arg.Any<int>()).Returns(clienteView.CloneTipado());

            var result = (ObjectResult)await controller.Get(clienteView.Id);

            await manager.Received().GetClienteAsync(Arg.Any<int>());
            result.Value.Should().BeEquivalentTo(clienteView);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task Get_ClienteById_NotFound()
        {
            manager.GetClienteAsync(Arg.Any<int>()).Returns(new ClienteView());

            var result = (StatusCodeResult)await controller.Get(1);

            await manager.Received().GetClienteAsync(Arg.Any<int>());
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Post_Created()
        {
            manager.InsertClienteAsync(Arg.Any<NovoCliente>()).Returns(clienteView.CloneTipado());

            var result = (ObjectResult)await controller.Post(novoCliente);

            await manager.Received().InsertClienteAsync(Arg.Any<NovoCliente>());
            result.StatusCode.Should().Be(StatusCodes.Status201Created);
            result.Value.Should().BeEquivalentTo(clienteView);
        }

        [Fact]
        public async Task Put_Ok()
        {
            manager.UpdateClienteAsync(Arg.Any<AlteraCliente>()).Returns(clienteView.CloneTipado());

            var result = (ObjectResult)await controller.Put(new AlteraCliente());

            await manager.Received().UpdateClienteAsync(Arg.Any<AlteraCliente>());
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(clienteView);
        }

        [Fact]
        public async Task Put_NotFound()
        {
            manager.UpdateClienteAsync(Arg.Any<AlteraCliente>()).ReturnsNull();

            var result = (StatusCodeResult)await controller.Put(new AlteraCliente());

            await manager.Received().UpdateClienteAsync(Arg.Any<AlteraCliente>());
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Delete_Ok()
        {
            manager.DeleteClienteAsync(Arg.Any<int>()).Returns(clienteView);

            var result = (StatusCodeResult)await controller.Delete(1);

            await manager.Received().DeleteClienteAsync(Arg.Any<int>());
            result.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }

        [Fact]
        public async Task Delete_NoContent()
        {
            manager.DeleteClienteAsync(Arg.Any<int>()).ReturnsNull();

            var result = (StatusCodeResult)await controller.Delete(1);

            await manager.Received().DeleteClienteAsync(Arg.Any<int>());
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }
    }
}
