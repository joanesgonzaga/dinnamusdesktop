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
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("Paises");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(p => p.CodigoIBGE)
                .HasColumnName("CodigoIBGE")
                .HasColumnType("varchar(25)");

            builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(60)");

            builder.HasMany(p => p.UFs)
                .WithOne(uf => uf.Pais)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
