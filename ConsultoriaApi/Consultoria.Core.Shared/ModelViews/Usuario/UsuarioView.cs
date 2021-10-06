using System.Collections.Generic;

namespace Consultoria.Core.Shared.ModelViews.Usuario
{
    public class UsuarioView
    {
        public string Login { get; set; }
        public ICollection<FuncaoView> Funcoes { get; set; }
    }
}
