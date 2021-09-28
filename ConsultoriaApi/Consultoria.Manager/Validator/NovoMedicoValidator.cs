using Consultoria.Core.Shared.ModelViews;
using FluentValidation;

namespace Consultoria.Manager.Validator
{
    public class NovoMedicoValidator : AbstractValidator<NovoMedico>
    {
        public NovoMedicoValidator()
        {
            RuleFor(p => p.Nome).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(p => p.CRM).NotNull().NotEmpty().GreaterThan(0);
            RuleForEach(p => p.Especialidades).SetValidator(new ReferenciaEspecialidadeValidator());
        }
    }
}
