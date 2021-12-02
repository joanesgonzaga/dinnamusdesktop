using DinnamuS_2._0_Desktop.Data;
using DinnamuS_2._0_Desktop.Model.Contatos;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace DinnamuS_2._0_Desktop.Controller
{
    public class TipoDeContatosController
    {
        public List<TipoDeContato> RetornaTiposDeContatos()
        {
            List<TipoDeContato> tipoDeContatos = new List<TipoDeContato>();

            using (var db = new DinnamuSApplicationContext())
            {
                tipoDeContatos = db.Set<TipoDeContato>().ToList();
            }

            //ObservableCollection<TipoDeContato> tipos = new ObservableCollection<TipoDeContato>(tipoDeContatos);
                return tipoDeContatos;
        }

        public void AtualizaTipoDeContato(TipoDeContato tipo)
        {
            using (var db = new DinnamuSApplicationContext())
            {
                db.Set<TipoDeContato>().Update(tipo);
                db.SaveChanges();
            }
        }

        public void NovoTipoDeContato(TipoDeContato tipoContato)
        {
            using (var db = new DinnamuSApplicationContext())
            {
                db.Set<TipoDeContato>().Add(tipoContato);
                db.SaveChanges();
            }
        }

        public void ExcluirTipo(TipoDeContato tipo)
        {
            using (var db = new DinnamuSApplicationContext())
            {
                db.Set<TipoDeContato>().Remove(tipo);
                db.SaveChanges();
            }
        }
    }
}
