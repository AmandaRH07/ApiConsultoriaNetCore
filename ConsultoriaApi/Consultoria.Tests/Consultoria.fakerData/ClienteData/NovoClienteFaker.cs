using Bogus;
using Consultoria.Core.Shared.ModelViews;
using Bogus.Extensions.Brazil;
using Consultoria.FakerData.TelefoneData;
using Consultoria.FakerData.EndereçoData;

namespace Consultoria.FakerData.ClienteData
{
    public class NovoClienteFaker : Faker<NovoCliente>
    {
        public NovoClienteFaker()
        {
            RuleFor(p => p.Nome, f => f.Person.FullName);
            RuleFor(p => p.Sexo, f => f.PickRandom<SexoView>());
            RuleFor(p => p.Documento, f => f.Person.Cpf());
            RuleFor(p => p.DataNascimento, f => f.Date.Past());
            RuleFor(p => p.Telefones, f => new NovoTelefoneFaker().Generate(3));
            RuleFor(p => p.Endereco, f => new NovoEnderecoFaker().Generate());
            
        }
    }
}
