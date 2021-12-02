using DinnamuS_2._0_Desktop.Data;
using DinnamuS_2._0_Desktop.Model.Endereco;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DinnamuS_2._0_Desktop.Controller
{
    public class MunicipiosController
    {

        public List<Municipio> RetornaTodosMunicipios()
        {
            List<Municipio> municipios = new List<Municipio>();

            using (var contexto = new DinnamuSApplicationContext())
            {
                DbSet<Municipio> m = contexto.Set<Municipio>();

                municipios = m.ToList(); //Os Includes podem causar queda de desempenho e serem desnecessários.
            }

                return municipios;
        }


        public List<Municipio> RetornaMunicipiosPorUF(UF uf)
        {
            List<Municipio> municipios = new List<Municipio>();

            using (var contexto = new DinnamuSApplicationContext())
            {
                DbSet<Municipio> m = contexto.Set<Municipio>();

                municipios = m.Include(m => m.UF).ThenInclude(u => u.Pais).Where(m => m.UF == uf) .ToList(); //Os Includes podem causar queda de desempenho e serem desnecessários.
            }

            return municipios;
        }

        public List<Municipio> RetornaMunicipioPorIBGE(string codigoIBGE)
        {
            List<Municipio> municipios = new List<Municipio>();

            using (var contexto = new DinnamuSApplicationContext())
            {
                DbSet<Municipio> m = contexto.Set<Municipio>();

                municipios = m.Include(m => m.UF).ThenInclude(u => u.Pais).Where(m => m.CodigoIBGE == codigoIBGE).ToList(); //Os Includes podem causar queda de desempenho e serem desnecessários.
            }

            return municipios;
        }

        public List<Municipio> RetornamunicipiosPorNome(string nomeMunicipio)
        {
            List<Municipio> municipios = new List<Municipio>();

            using (var contexto = new DinnamuSApplicationContext())
            {
                DbSet<Municipio> m = contexto.Set<Municipio>();

                municipios = m.Include(m => m.UF).ThenInclude(u => u.Pais).Where(m => m.NomeMunicipio.ToLower().Contains(nomeMunicipio.ToLower())).ToList(); //Os Includes podem causar queda de desempenho e serem desnecessários.
            }

            return municipios;
        }

        public void AdicionarMunicipio(Municipio municipio)
        {
            using (var contexto = new DinnamuSApplicationContext())
            {
                //O código abaixo (comentado), estranhamente executa um Insert na tabela Paises
                //contexto.Set<Municipio>().Add(municipio);
                contexto.Entry(municipio).State = EntityState.Added;
                contexto.SaveChanges();
            }
        }

        internal void AtualizaMunicipio(Municipio municipio)
        {
            using (var contexto = new DinnamuSApplicationContext())
            {
                contexto.Set<Municipio>().Update(municipio);
                contexto.SaveChanges();
            }
        }

        internal List<Municipio> RetornamunicipiosPorNomeEUF(string nomeMunicipio, string uf)
        {
            List<Municipio> municipios = new List<Municipio>();

            using (var contexto = new DinnamuSApplicationContext())
            {
                DbSet<Municipio> m = contexto.Set<Municipio>();

                municipios = m.Include(m => m.UF).ThenInclude(u => u.Pais).Where(m => m.NomeMunicipio.ToLower().Contains(nomeMunicipio.ToLower())).Where(m => m.UF.Uf == uf) .ToList(); //Os Includes podem causar queda de desempenho e serem desnecessários.
            }

            return municipios;
        }

        public void RemoveMunicipio(Municipio municipio)
        {
            using (var db  = new DinnamuSApplicationContext())
            {
                db.Set<Municipio>().Remove(municipio);

                db.SaveChanges();
            }
        }
    }
}
