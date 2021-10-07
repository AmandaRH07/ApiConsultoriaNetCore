using System.Collections;
using System.Collections.Generic;

namespace Consultoria.Core.Shared.ModelViews.Usuario
{
    public class UsuarioLogado
    {
        public string Login { get; set; }
        public ICollection<FuncaoView> Funcoes{ get; set; }
        public string Token{ get; set; }
    }
}
