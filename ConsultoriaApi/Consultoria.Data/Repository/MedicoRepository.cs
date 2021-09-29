using Consultoria.Core.Domain;
using Consultoria.Data.Context;
using Consultoria.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultoria.Data.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ConsultoriaDbContext context;

        public MedicoRepository(ConsultoriaDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Medico>> GetMedicosAsync()
        {
            return await context.Medicos
              .Include(p => p.Especialidades)
              .AsNoTracking().ToListAsync();
        }

        public async Task<Medico> GetMedicoAsync(int id)
        {
            return await context.Medicos
                .Include(p => p.Especialidades)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Medico> InsertMedicoAsync(Medico medico)
        {
            await InsertMedicoEspecilidades(medico);
            await context.Medicos.AddAsync(medico);
            await context.SaveChangesAsync();
            return medico;
        }

        private async Task InsertMedicoEspecilidades(Medico medico)
        {
            var especialidadesConsultadas = new List<Especialidade>();
            foreach (var especialidade in medico.Especialidades)
            {
                var especialidadeConsultada = await context.Especialidades.FindAsync(especialidade.Id);
                especialidadesConsultadas.Add(especialidadeConsultada);
            }
            medico.Especialidades = especialidadesConsultadas;
        }

        public async Task<Medico> UpdateMedicoAsync(Medico medico)
        {
            var medicoConsultado = await context.Medicos
                                        .Include(p => p.Especialidades)
                                        .SingleOrDefaultAsync(p => p.Id == medico.Id);
            if (medicoConsultado == null)
            {
                return null;
            }
            context.Entry(medicoConsultado).CurrentValues.SetValues(medico);
            await UpdateMedicoEspecialidades(medico, medicoConsultado);
            await context.SaveChangesAsync();
            return medicoConsultado;
        }

        private async Task UpdateMedicoEspecialidades(Medico medico, Medico medicoConsultado)
        {
            medicoConsultado.Especialidades.Clear();
            foreach (var especialidade in medico.Especialidades)
            {
                var especialidadeConsultada = await context.Especialidades.FindAsync(especialidade.Id);
                medicoConsultado.Especialidades.Add(especialidadeConsultada);
            }
        }

        public async Task DeleteMedicoAsync(int id)
        {
            var medicoConsultado = await context.Medicos.FindAsync(id);
            context.Medicos.Remove(medicoConsultado);
            await context.SaveChangesAsync();
        }
    }
}
