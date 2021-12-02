using DinnamuS_2._0_Desktop;
using DinnamuS_2._0_Desktop.Model;
using DinnamuS_2._0_Desktop.Model.Endereco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapeamentoTestes.Data.Configurations
{
    public class UFConfiguration : IEntityTypeConfiguration<UF>
    {
        public void Configure(EntityTypeBuilder<UF> builder)
        {
            builder.ToTable("UFs");
            
            //Filtro globa: Nas Queries, traz somente UFs do Brasil, por padrão.
            builder.HasQueryFilter(uf => uf.PaisId == 6);
            
            builder.HasKey(uf => uf.Id);
            builder.Property(uf => uf.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(uf => uf.CodigoIBGE)
                .HasColumnName("CodigoIBGE")
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(uf => uf.Uf)
                .HasColumnName("Uf")
                .HasColumnType("char(2)")
                .IsRequired();

            builder.Property(uf => uf.Estado)
                .HasColumnName("Estado")
                .HasColumnType("varchar(45)")
                .IsRequired();

            builder.Property(uf => uf.PaisId)
                .HasColumnName("PaisId")
                .HasColumnType("integer")
                .IsRequired();

            builder.HasMany(uf => uf.Municipios)
                .WithOne(m => m.UF)
                .OnDelete(DeleteBehavior.NoAction);

            //Precisa?
            builder.HasOne(uf => uf.Pais)
                .WithMany(p => p.UFs)
                .OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
