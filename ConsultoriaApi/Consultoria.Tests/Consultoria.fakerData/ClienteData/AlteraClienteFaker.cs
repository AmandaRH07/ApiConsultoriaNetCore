using Bogus;
using Consultoria.Core.Shared.ModelViews;
using Consultoria.FakerData.EndereçoData;
using Consultoria.FakerData.TelefoneData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultoria.FakerData.ClienteData
{
    public class AlteraClienteFaker : Faker<AlteraCliente>
    {
        public AlteraClienteFaker()
        {
            var id = new Faker().Random.Number(1, 100);
            RuleFor(o => o.Id, f => id);
            RuleFor(o => o.Nome, f => f.Person.FullName);
            RuleFor(o => o.Sexo, f => f.PickRandom<SexoView>());
            RuleFor(o => o.Telefones, f => new NovoTelefoneFaker().Generate(3));
            RuleFor(o => o.Endereco, f => new NovoEnderecoFaker().Generate());
        }
    }
}
