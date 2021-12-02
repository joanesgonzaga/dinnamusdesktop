using DinnamuS_2._0_Desktop.Model.Estoque;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinnamuS_2._0_Desktop.Data.Configurations
{
    public class ProdutoGradesItensVariacaoConfiguration : IEntityTypeConfiguration<ProdutoGradesItensVariacao>
    {
        public void Configure(EntityTypeBuilder<ProdutoGradesItensVariacao> builder)
        {
            builder.ToTable("ProdutosItensVariacao");

            builder.HasKey(pgiv => pgiv.Id);

            builder.Property(pgiv => pgiv.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(pgiv => pgiv.GradeItemId)
                .HasColumnName("GradeItemId")
                .IsRequired();

            builder.Property(pgiv => pgiv.ProdutoItensId)
                .HasColumnName("Variacao")
                .IsRequired();

            /*
            builder.HasOne(gip => gip.Produto)
                .WithMany(p => p.ItensGradesProdutos);
            */
        }
    }
}
