using Consultoria.Core.Domain;
using Consultoria.Data.Context;
using Consultoria.Data.Repository;
using Consultoria.FakerData.ClienteData;
using Consultoria.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using System.Linq;
using Xunit;
using Consultoria.FakerData.TelefoneData;

namespace Consultoria.Manager.Tests.Repository
{
    public class ClienteRepositoryTest : IDisposable
    {
        private readonly IClienteRepository clienteRepository;
        private readonly ConsultoriaDbContext context;
        private readonly Cliente cliente;
        private ClienteFaker clienteFaker;

        public ClienteRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ConsultoriaDbContext>();
            optionsBuilder.UseInMemoryDatabase("Db_Teste");

            context = new ConsultoriaDbContext(optionsBuilder.Options);
            clienteRepository = new ClienteRepository(context);

            clienteFaker = new ClienteFaker();
            cliente = clienteFaker.Generate();
        }

        private async Task<List<Cliente>> InsereRegistros()
        {
            var clientes = clienteFaker.Generate(100);
            foreach (var cli in clientes)
            {
                cli.Id = 0;
                await context.Clientes.AddAsync(cli);
            }
            await context.SaveChangesAsync();
            return clientes;
        }

        [Fact]
        public async Task GetClientesAsync_ComRetorno()
        {
            var registros = await InsereRegistros();
            var retorno = await clienteRepository.GetClientesAsync();

            retorno.Should().HaveCount(registros.Count);
            retorno.First().Endereco.Should().NotBeNull();
            retorno.First().Telefones.Should().NotBeNull();
        }

        [Fact]
        public async Task GetClientesAsync_Vazio()
        {
            var retorno = await clienteRepository.GetClientesAsync();
            retorno.Should().HaveCount(0);
        }

        [Fact]
        public async Task GetClienteAsync_Encontrado()
        {
            var registros = await InsereRegistros();
            var retorno = await clienteRepository.GetClienteAsync(registros.First().Id);

            retorno.Should().BeEquivalentTo(registros.First());
        }

        [Fact]
        public async Task GetClienteAsync_NaoEncontrado()
        {
            var retorno = await clienteRepository.GetClienteAsync(1);
            retorno.Should().BeNull();
        }

        [Fact]
        public async Task InsereClienteAsync_Sucesso()
        {
            var retorno = await clienteRepository.InsertClienteAsync(cliente);
            retorno.Should().BeEquivalentTo(cliente);
        }

        [Fact]
        public async Task UpdateClienteAsync_Sucesso()
        {
            var registros = await InsereRegistros();
            var clienteAlterado = clienteFaker.Generate();
            clienteAlterado.Id = registros.First().Id;
            var retorno = await clienteRepository.UpdateClienteAsync(clienteAlterado);
            retorno.Should().BeEquivalentTo(clienteAlterado);
        }

        [Fact]
        public async Task UpdateClienteAsync_AddTelefone()
        {
            var registros = await InsereRegistros();
            var clienteAlterado = registros.First();
            clienteAlterado.Telefones.Add(new TelefoneFaker(clienteAlterado.Id).Generate());
            var retorno = await clienteRepository.UpdateClienteAsync(clienteAlterado);
            retorno.Should().BeEquivalentTo(clienteAlterado);

        }

        [Fact]
        public async Task UpdateClienteAsync_RemoveTelefone()
        {
            var registros = await InsereRegistros();
            var clienteAlterado = registros.First();
            clienteAlterado.Telefones.Remove(clienteAlterado.Telefones.First());
            var retorno = await clienteRepository.UpdateClienteAsync(clienteAlterado);
            retorno.Should().BeEquivalentTo(clienteAlterado);
        }

        [Fact]
        public async Task UpdateClienteAsync_RemoveTodosTelefone()
        {
            var registros = await InsereRegistros();
            var clienteAlterado = registros.First();
            clienteAlterado.Telefones.Clear();
            var retorno = await clienteRepository.UpdateClienteAsync(clienteAlterado);
            retorno.Should().BeEquivalentTo(clienteAlterado);
        }

        [Fact]
        public async Task UpdateClienteAsync_NaoEncontrado()
        {
            var retorno = await clienteRepository.UpdateClienteAsync(cliente);
            retorno.Should().BeNull();
        }

        [Fact]
        public async Task DeleteClienteAsync_Sucesso()
        {
            var registros = await InsereRegistros();
            var retorno = await clienteRepository.DeleteClienteAsync(registros.First().Id);
            retorno.Should().BeEquivalentTo(registros.First());
        }

        [Fact]
        public async Task DeleteClienteAsync_NaoEncontrado()
        {
            var retorno = await clienteRepository.DeleteClienteAsync(1);
            retorno.Should().BeNull();
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }
    }
}
