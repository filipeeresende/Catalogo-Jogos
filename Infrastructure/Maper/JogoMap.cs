using Infrastructure.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Maper
{
    internal class JogoMap : IEntityTypeConfiguration<Jogo>
    {

        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            builder.ToTable("Jogo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property<string>(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property<string>(builder => builder.Produtora)
                .IsRequired()
                .HasColumnName("Produtora")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property<double>(builder => builder.Preco)
                .IsRequired()
                .HasColumnName("Preco")
                .HasColumnType("DECIMAL")
                .HasMaxLength(1000);
        }
    }
}
