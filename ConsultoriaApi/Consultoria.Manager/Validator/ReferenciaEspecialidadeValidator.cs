using Consultoria.Core.Shared.ModelViews;
using Consultoria.Manager.Interfaces;
using FluentValidation;
using System.Threading.Tasks;

namespace Consultoria.Manager.Validator
{
    public class ReferenciaEspecialidadeValidator : AbstractValidator<ReferenciaEspecialidade>
    {
        private readonly IEspecialidadeRepository especialidadeRepository;

        public ReferenciaEspecialidadeValidator(IEspecialidadeRepository especialidadeRepository)
        {
            this.especialidadeRepository = especialidadeRepository;
            RuleFor(p => p.Id).NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .MustAsync(async (id, cancelar) => {
                        return await ExisteNaBase(id);
                })
                .WithMessage("Especialidade não cadastrada");
        }

        private async Task<bool> ExisteNaBase(int id)
        {
            return await especialidadeRepository.ExisteAsync(id);
        }
    }
}