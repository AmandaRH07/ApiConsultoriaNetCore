using Bogus;
using Consultoria.Core.Domain;

namespace Consultoria.FakerData.TelefoneData
{
    public class TelefoneFaker : Faker<Telefone>
    {
        public TelefoneFaker(int clientId)
        {
            RuleFor(o => o.ClienteId, f => clientId);
            RuleFor(o => o.Numero, f => f.Person.Phone);
        }
    }
}
