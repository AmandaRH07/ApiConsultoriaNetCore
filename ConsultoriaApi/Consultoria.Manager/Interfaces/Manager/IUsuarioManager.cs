using Consultoria.Core.Domain;
using Consultoria.Core.Shared.ModelViews.Usuario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultoria.Manager.Interfaces.Manager
{
    public interface IUsuarioManager
    {
        Task<IEnumerable<UsuarioView>> GetAsync();
        Task<UsuarioView> GetAsync(string login);
        Task<UsuarioView> InsertAsync(Usuario usuario);
        Task<UsuarioView> UpdateAsync(Usuario  usuario);
        Task<bool> ValidaSenhaAsync(Usuario usuario);
    }
}
