using Consultoria.Core.Shared.ModelViews;
using FluentValidation;
using System;

namespace Consultoria.Manager.Validator
{
    public class AlteraClienteValidator : AbstractValidator<AlteraCliente>
    {
        public AlteraClienteValidator()
        {
            RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
            Include(new NovoClienteValidator());
        }

        private void Include(NovoClienteValidator novoClienteValidator)
        {
            return;
        }
    }
}
