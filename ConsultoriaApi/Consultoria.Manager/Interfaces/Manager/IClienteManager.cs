using Consultoria.Core.Shared.ModelViews;
using Consultoria.Core.Shared.ModelViews.Cliente;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultoria.Manager.Interfaces
{
    public interface IClienteManager
    {
        Task<ClienteView> GetClienteAsync(int id);

        Task<IEnumerable<ClienteView>> GetClientesAsync();

        Task<ClienteView> InsertClienteAsync(NovoCliente cliente);

        Task<ClienteView> UpdateClienteAsync(AlteraCliente cliente);
        Task<ClienteView> DeleteClienteAsync(int id);
    }
}
