using DinnamuS_2._0_Desktop.Model.Estoque;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinnamuS_2._0_Desktop.Controller
{
    public class ProdutoItemConfiguration : IEntityTypeConfiguration<ProdutoItens>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ProdutoItens> builder)
        {
            builder.ToTable("ProdutosItens");

            builder.HasKey(pi => pi.Id);

            builder.Property(pi => pi.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(pi => pi.ProdutoId)
                .HasColumnName("ProdutoId")
                .IsRequired();

            builder.Property(pi => pi.RotuloVariacao)
                .HasColumnName("RotuloVariacao")
                .IsRequired();

            builder.HasOne(pi => pi.Produto)
                .WithMany(p => p.ProdutosItens)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
