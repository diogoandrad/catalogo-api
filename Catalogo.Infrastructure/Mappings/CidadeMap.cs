using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Catalogo.Domain.Entities;

namespace Catalogo.Infrastructure.Mappings
{
    public class CidadeEntityTypeConfiguration : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("cidade", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Uf)
                .HasColumnName("uf")
                .HasColumnType("varchar")
                .HasMaxLength(2)
                .IsRequired();
        }
    }
}
