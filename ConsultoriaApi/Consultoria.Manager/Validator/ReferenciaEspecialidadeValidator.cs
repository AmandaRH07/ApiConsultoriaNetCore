using Consultoria.Core.Shared.ModelViews;
using FluentValidation;

namespace Consultoria.Manager.Validator
{
    public class ReferenciaEspecialidadeValidator : AbstractValidator<ReferenciaEspecialidade>
    {
        public ReferenciaEspecialidadeValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}