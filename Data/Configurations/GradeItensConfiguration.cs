using DinnamuS_2._0_Desktop.Model.Estoque;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinnamuS_2._0_Desktop.Data.Configurations
{
    public class GradeItensConfiguration : IEntityTypeConfiguration<GradeItem>
    {
        public void Configure(EntityTypeBuilder<GradeItem> builder)
        {
            builder.ToTable("GradesItens");

            builder.HasKey(gi => gi.Id);

            builder.Property(gi => gi.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(gi => gi.GradeId)
                .HasColumnName("GradeId")
                .IsRequired();

            builder.Property(gi => gi.Variacao)
                .HasColumnName("Variacao");

            builder.Property(gi => gi.Ordem)
                .HasColumnName("Ordem");
        }
    }
}
