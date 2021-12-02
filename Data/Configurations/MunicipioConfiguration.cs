using DinnamuS_2._0_Desktop.Model.Endereco;
using DinnamuS_2._0_Desktop;
using DinnamuS_2._0_Desktop.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapeamentoTestes.Data.Configurations
{
    public class MunicipioConfiguration : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder.ToTable("Municipios");
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(m => m.CodigoIBGE)
                .HasColumnName("CodigoIBGE")
                .HasColumnType("varchar(25)")
                .IsRequired();

            builder.Property(m => m.UFId)
                .HasColumnName("UFId")
                .IsRequired();

            builder.Property(m => m.NomeMunicipio)
                .HasColumnName("NomeMunicipio")
                .HasColumnType("varchar(60)")
                .IsRequired();
        }
    }
}
