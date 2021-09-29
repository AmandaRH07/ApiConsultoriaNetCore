using Consultoria.Core.Domain;
using Consultoria.Data.Context;
using Consultoria.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultoria.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ConsultoriaDbContext context;

        public ClienteRepository(ConsultoriaDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await context.Clientes
                .Include(p => p.Endereco)
                .Include(p => p.Telefones)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Cliente> GetClienteAsync(int id)
        {
            return await context.Clientes
                .Include(p => p.Endereco)
                .Include(p => p.Telefones)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Cliente> InsertClienteAsync(Cliente cliente)
        {
            await context.Clientes.AddAsync(cliente);
            await context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            var clienteConsultado = await context.Clientes.FindAsync(cliente.Id);

            if (clienteConsultado == null)
            {
                return null;
            }

            context.Entry(clienteConsultado).CurrentValues.SetValues(cliente);

            context.Clientes.Update(clienteConsultado);
            await context.SaveChangesAsync();
            return clienteConsultado;
        }

        public async Task DeleteClienteAsync(int id)
        {
            var clienteConsultado = await context.Clientes.FindAsync(id);
            context.Clientes.Remove(clienteConsultado);
            await context.SaveChangesAsync();
        }
    }
}
