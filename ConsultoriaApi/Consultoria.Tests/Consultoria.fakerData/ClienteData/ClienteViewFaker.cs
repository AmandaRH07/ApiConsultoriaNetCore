using Bogus;
using Bogus.Extensions.Brazil;
using Consultoria.Core.Shared.ModelViews;
using Consultoria.Core.Shared.ModelViews.Cliente;
using Consultoria.FakerData.EndereçoData;
using Consultoria.FakerData.TelefoneData;

namespace Consultoria.FakerData.ClienteData
{
    public class ClienteViewFaker : Faker<ClienteView>
    {
        public ClienteViewFaker()
        {
            var id = new Faker().Random.Number(1, 9999);
            RuleFor(p => p.Id, f => id);
            RuleFor(p => p.Nome, f => f.Person.FullName);
            RuleFor(p => p.Sexo, f => f.PickRandom<SexoView>());
            RuleFor(p => p.Documento, f => f.Person.Cpf());
            RuleFor(p => p.Criacao, f => f.Date.Past());
            RuleFor(p => p.UltimaAtualizacao, f => f.Date.Past());
            RuleFor(p => p.Telefones, f => new TelefoneViewFaker().Generate(3));
            RuleFor(p => p.Endereco, f => new EnderecoViewFaker().Generate());
        }
    }
}
