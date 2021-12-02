using DinnamuS_2._0_Desktop.Model;
using DinnamuS_2._0_Desktop.Model.Estoque;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapeamentoTestes.Data.Configurations
{
    public class GrupoConfiguration : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.ToTable("Grupos");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(g => g.Nome)
                .HasColumnName("Nome")
                .IsRequired();

            builder.Property(g => g.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(60);

            builder.Property(g => g.GrupoPaiId)
                .HasColumnName("GrupoPaiId");

            builder.HasMany(g => g.Subgrupos)
                .WithOne(g => g.GrupoPai)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
