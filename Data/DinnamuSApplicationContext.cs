using DinnamuS_2._0_Desktop.Data.Configurations;
using DinnamuS_2._0_Desktop.Model;
using DinnamuS_2._0_Desktop.Model.Contatos;
using DinnamuS_2._0_Desktop.Model.Endereco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinnamuS_2._0_Desktop.Data
{
    class DinnamuSApplicationContext : DbContext
    {
        //public DbSet<Produto> Produtos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=MATRIZ;Initial Catalog=Principal;Persist Security Info=False;User ID=sa;Password=senh@654321;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True");
            //optionsBuilder.UseNpgsql("Host=Server;Database=Principal;Port=5432;Username=postgres;Password=senh@654321", optionsBuilder => optionsBuilder.SetPostgresVersion(9,6));
            optionsBuilder.UseNpgsql("Server = 192.168.0.6; Port = 5432; Database = Principal; User Id = postgres; Password=senh@654321", optionsBuilder => optionsBuilder.SetPostgresVersion(9, 6));
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            //Método abaixo automatiza a aplicação das classes de configuração do modelo de dados
            //varrendo, no warm-up da aplicação, o assembly que possui as classes que implementam o IEntityTypeConfiguration na aplicação
            model.ApplyConfigurationsFromAssembly(typeof(DinnamuSApplicationContext).Assembly);
        }

    }
}
