using DinnamuS_2._0_Desktop.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinnamuS_2._0_Desktop.Data.Configurations
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoas");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .IsRequired();


            builder.Property(p => p.Codigo)
                .HasColumnName("Codigo")
                .HasColumnType("integer");
            

            builder.Property(p => p.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(60)")
                .IsRequired();

            builder.Property(p => p.isAtivo)
                .HasColumnName("Ativo")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(p => p.DataCadastro)
                .HasColumnName("DataCadastro")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder.Property(p => p.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("datetime");

            builder.Property(p => p.Doc)
                .HasColumnName("Doc")
                .HasColumnType("varchar(20)");

        }
    }
}
