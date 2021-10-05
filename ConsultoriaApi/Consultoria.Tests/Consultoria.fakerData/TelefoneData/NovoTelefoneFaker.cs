using Bogus;
using Consultoria.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultoria.FakerData.TelefoneData
{
    public class NovoTelefoneFaker : Faker<NovoTelefone>
    {
        public NovoTelefoneFaker()
        {
            RuleFor(p => p.Numero, f => f.Person.Phone);
        }
    }
}
