using System;
using System.Collections.Generic;
using System.Text;

namespace Consultoria.Core.Shared.ModelViews
{
    /// <summary>
    ///  Objeto utilizado para a inserção de um novo cliente.
    /// </summary>
    public class NovoCliente
    {
        public int Id { get; set; }

        /// <summary>
        /// Nome do cliente
        /// </summary>
        /// <example>João Silva</example>
        public string Nome { get; set; }
        /// <example>1980-01-01</example>
        public DateTime DataNascimento { get; set; }
        /// <example>F ou M</example>
        public SexoView Sexo { get; set; }
        /// <summary>
        /// Documento do cliente: CPF, CNF,...
        /// </summary>
        /// <example>12345678</example>
        public string Documento { get; set; }
        public NovoEndereco Endereco { get; set; }
        public ICollection<NovoTelefone> Telefones { get; set; }
    }
}
