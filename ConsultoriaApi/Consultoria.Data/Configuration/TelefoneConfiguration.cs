using Consultoria.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultoria.Data.Context
{
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {

        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            // definindo chave composta
            builder.HasKey(p => new { p.ClienteId, p.Numero });
        }
    }
}