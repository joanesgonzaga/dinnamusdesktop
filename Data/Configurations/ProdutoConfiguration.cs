using DinnamuS_2._0_Desktop.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinnamuS_2._0_Desktop.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(p => p.Codigo)
                .HasColumnName("Codigo");

            builder.Property(p => p.Loja)
                .HasColumnName("Loja");

            /*
            builder.Property(p => p.isAtivo)
                .HasColumnName("isAtivo")
                .HasColumnType("bit");
            */

            builder.Property(p => p.DataCadastro)
                .HasColumnName("DataCadastro")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .IsRequired();

            builder.Property(p => p.NomeImpresso)
                .HasColumnName("NomeImpresso");

            builder.HasMany(p => p.ProdutosItens)
                .WithOne(pi => pi.Produto)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
