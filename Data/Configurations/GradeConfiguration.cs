using DinnamuS_2._0_Desktop.Model.Estoque;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinnamuS_2._0_Desktop.Data.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        
            public void Configure(EntityTypeBuilder<Grade> builder)
            {
                builder.ToTable("Grades");

                builder.HasKey(g => g.Id);

                builder.Property(g => g.Id)
                    .HasColumnName("Id")
                    .IsRequired();

                builder.Property(g => g.Nome)
                    .HasColumnName("Nome")
                    .IsRequired();

                builder.Property(g => g.Descricao)
                    .HasColumnName("Descricao");


                builder.HasMany(g => g.ItensDaGrade)
                    .WithOne(ig => ig.Grade)

                //O behavior abaixo era NoAction, mas ocorria o erro abaixo:
                //"The association between entities 'Grade' and 'GradeItem' with the key value '{GradeId: 4}' has been severed,
                //but the relationship is either marked as required or is implicitly required because the foreign key is not nullable.
                //If the dependent/child entity should be deleted when a required relationship is severed, configure the relationship to use cascade deletes
                .OnDelete(DeleteBehavior.Cascade);

}

}
}
