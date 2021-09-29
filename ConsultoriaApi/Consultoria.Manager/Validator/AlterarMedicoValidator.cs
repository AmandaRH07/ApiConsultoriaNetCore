using Consultoria.Core.Shared.ModelViews;
using Consultoria.Manager.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultoria.Manager.Validator
{
    public class AlterarMedicoValidator :  AbstractValidator<AlteraMedico>
    {
        public AlterarMedicoValidator(IEspecialidadeRepository especialidadeRepository)
        {
            RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
            Include(new NovoMedicoValidator(especialidadeRepository));
        }
    }
}
