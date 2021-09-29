using Consultoria.Core.Shared.ModelViews;
using System.Collections.Generic;

namespace Consultoria.Manager.Mappings
{
    public  class MedicoView
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CRM { get; set; }
        public ICollection<EspecialidadeView> Especialidades { get; set; }
    }
}