using Consultoria.Core.Shared.ModelViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultoria.Manager.Validator
{
    public class NovoTelefoneValidator : AbstractValidator<NovoTelefone>
    {
        public NovoTelefoneValidator()
        {
           RuleFor(x => x.Numero).Matches("[1-9][0-9]{10}")
                .WithMessage("O telefone tem que ter o formato [1-9][0-9]{10}");

        }
    }
}
