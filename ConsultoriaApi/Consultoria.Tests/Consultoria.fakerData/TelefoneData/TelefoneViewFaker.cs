using Consultoria.Core.Shared.ModelViews.Cliente;
using Bogus;

namespace Consultoria.FakerData.TelefoneData
{
    public class TelefoneViewFaker : Faker<TelefoneView>
    {
        public TelefoneViewFaker()
        {
            RuleFor(p => p.Id, f => f.Random.Number(1, 10));
            RuleFor(p => p.Numero, f => f.Person.Phone);
        }
    }
}
