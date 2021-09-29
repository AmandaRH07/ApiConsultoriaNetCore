using Consultoria.Core.Shared.ModelViews;
using Consultoria.Manager.Mappings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultoria.Manager.Interfaces
{
    public interface IMedicoManager
    {
        Task<IEnumerable<MedicoView>> GetMedicosAsync();
        Task<MedicoView> GetMedicoAsync(int id);
        Task<MedicoView> InsertMedicoAsync(NovoMedico novoMedico);
        Task<MedicoView> UpdateMedicoAsync(AlteraMedico alteraMedico);
        Task DeleteMedicoAsync(int id);
    }
}
