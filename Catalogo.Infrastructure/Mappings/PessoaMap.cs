using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Catalogo.Domain.Entities;

namespace Catalogo.Infrastructure.Mappings
{
    public class PessoaEntityTypeConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("pessoa", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(x => x.Cpf)
                .HasColumnName("cpf")
                .HasColumnType("varchar")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.Idade)
                .HasColumnName("idade")
                .IsRequired();

            builder.Property(x => x.CidadeId)
                .HasColumnName("cidade_id")
                .IsRequired();

            builder.HasIndex(x => x.Cpf).IsUnique();

            builder.HasOne(x => x.Cidade)
                .WithMany(x => x.Pessoas)
                .HasForeignKey(x => x.CidadeId);
        }
    }
}
