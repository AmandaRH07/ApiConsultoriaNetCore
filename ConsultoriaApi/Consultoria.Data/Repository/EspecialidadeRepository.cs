using Consultoria.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Consultoria.Manager.Interfaces
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly ConsultoriaDbContext context;

        public EspecialidadeRepository(ConsultoriaDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await context.Especialidades.AnyAsync(p => p.Id == id);
        }
    }
}
