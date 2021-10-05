using System;

namespace Consultoria.Core.Shared.ModelViews.Cliente
{
    public class TelefoneView : ICloneable
    {
        public int Id { get; set; }
        public string Numero { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
