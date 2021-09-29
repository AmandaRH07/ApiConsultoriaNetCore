using Consultoria.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultoria.Manager.Interfaces
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> GetMedicosAsync();

        Task<Medico> GetMedicoAsync(int id);

        Task<Medico> InsertMedicoAsync(Medico medico);

        Task<Medico> UpdateMedicoAsync(Medico medico);

        Task DeleteMedicoAsync(int id);
    }
}
