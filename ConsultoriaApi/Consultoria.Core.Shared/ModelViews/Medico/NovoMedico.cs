using System.Collections.Generic;

namespace Consultoria.Core.Shared.ModelViews
{
    public class NovoMedico
    {
        public string Nome { get; set; }
        public int CRM { get; set; }

        public ICollection<ReferenciaEspecialidade> Especialidades { get; set; }
    }
}
