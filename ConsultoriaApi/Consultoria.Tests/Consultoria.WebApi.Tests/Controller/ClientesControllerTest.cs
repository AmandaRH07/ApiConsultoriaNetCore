using Consultoria.Core.Shared.ModelViews.Cliente;
using Consultoria.FakerData.ClienteData;
using Consultoria.Manager.Interfaces;
using Consultoria.WebApi.Controller;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
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

        public ClientesControllerTest()
        {
            manager = Substitute.For<IClienteManager>();
            logger = Substitute.For<ILogger<ClientesController>>();
            controller = new ClientesController(manager, logger);

            clienteView = new ClienteViewFaker().Generate();
            listaClienteView = new ClienteViewFaker().Generate(10);
        }

        [Fact]
        public async Task Get_Clientes_OK()
        {
            var controle = new List<ClienteView>();
            listaClienteView.ForEach(p => controle.Add(p.CloneTipado()));

            manager.GetClientesAsync().Returns(listaClienteView);

            var resultado = (ObjectResult) await controller.Get();
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
            resultado.Value.Should().BeEquivalentTo(controle);
        }
    }
}
