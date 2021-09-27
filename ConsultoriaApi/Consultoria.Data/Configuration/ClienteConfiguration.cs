using Consultoria.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultoria.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("TbCliente");
            builder.Property(p => p.Nome).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Sexo).HasDefaultValue('F').IsRequired();
            builder.Property(p => p.Documento).HasColumnName("DocumentoIdentificador");

            builder.HasIndex(p => new { 
                p.Nome, 
                p.Sexo 
            });
            builder.Property(p => p.DataNascimento).HasColumnType("varchar");
        }
    }
}
