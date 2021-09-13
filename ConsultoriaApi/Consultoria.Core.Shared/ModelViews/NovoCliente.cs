using System;
using System.Collections.Generic;
using System.Text;

namespace Consultoria.Core.Shared.ModelViews
{
    public class NovoCliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public string Telefone { get; set; }
        public string Documento { get; set; }
    }
}
