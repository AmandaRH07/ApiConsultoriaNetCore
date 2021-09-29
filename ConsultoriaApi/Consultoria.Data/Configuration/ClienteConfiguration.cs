using Consultoria.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Consultoria.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(p => p.Nome).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Sexo).HasConversion(
                p => p.ToString(),
                p => (Sexo)Enum.Parse(typeof(Sexo), p));
        }
    }
}
