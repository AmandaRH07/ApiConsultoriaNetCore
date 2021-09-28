using System.Threading.Tasks;

namespace Consultoria.Manager.Interfaces
{
    public interface IEspecialidadeRepository
    {
        Task<bool> ExisteAsync(int id);

    }
}
