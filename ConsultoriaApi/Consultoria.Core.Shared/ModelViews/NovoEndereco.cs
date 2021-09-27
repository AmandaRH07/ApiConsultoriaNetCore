namespace Consultoria.Core.Shared.ModelViews
{
    public class NovoEndereco
    {
        /// <example>00000000</example>
        public int CEP { get; set; }
        /// <example>SP</example>
        public string Estado { get; set; }
        /// <example>São Paulo</example>
        public string Cidade { get; set; }
        /// <example>Rua X</example>
        public string Logradouro { get; set; }
        /// <example>100</example>
        public string Numero { get; set; }
        /// <example>Apto. 1</example>
        public string Complemento { get; set; }
    }
}