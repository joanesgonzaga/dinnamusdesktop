using DinnamuS_2._0_Desktop.Data;
using DinnamuS_2._0_Desktop.Model.Endereco;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DinnamuS_2._0_Desktop.Controller
{
    public class PaisController
    {
        private Pais Pais { get; set; }

        public PaisController()
        {
            Pais = new Pais();
        }


        public Pais RetornaPaisByID(int id)
        {
            using (var db = new DinnamuSApplicationContext())
            {
                this.Pais = (Pais)db.Set<Pais>().Where(p => p.Id == id);
            }

            return this.Pais;
        }

        public List<Pais> RetornaPaises()
        {
            List<Pais> paises = new List<Pais>();

            using (var db = new DinnamuSApplicationContext())
            {
                paises = db.Set<Pais>().ToList();
            }

            return paises;
        }

        internal void AdicionarPais(Pais pais)
        {
            throw new NotImplementedException();
        }

        internal void AtualizaPais(Pais pais)
        {
            throw new NotImplementedException();
        }

        internal void RemovePais(Pais pais)
        {
            throw new NotImplementedException();
        }

        internal List<Pais> RetornaPaisPorIBGE(string termoBusca)
        {
            throw new NotImplementedException();
        }

        internal List<Pais> RetornaPaisesPorNome(string termoBusca)
        {
            List<Pais> paises = new List<Pais>();

            using (var db = new DinnamuSApplicationContext())
            {
                paises = db.Set<Pais>().Where(p => p.Nome.ToLower().Contains(termoBusca)).ToList();
            }

            return paises;
        }
    }
}
