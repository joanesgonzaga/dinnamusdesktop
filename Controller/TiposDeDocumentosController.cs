using DinnamuS_2._0_Desktop.Data;
using DinnamuS_2._0_Desktop.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DinnamuS_2._0_Desktop.Controller
{
    class TiposDeDocumentosController
    {
        public List<TipoDeDocumento> RetornaTiposDocumentos()
        {
            List<TipoDeDocumento> lista = new List<TipoDeDocumento>();

            using (var db = new DinnamuSApplicationContext())
            {
                //lista = db.Set<TipoDeDocumento>().ToList();

                lista = (from td in db.Set<TipoDeDocumento>().Where(t => t.Tipo != null) select td).ToList();
            }

                return lista;
        }

        public void AtualizaTipoDocumento(TipoDeDocumento tipo)
        {
            using (var db = new DinnamuSApplicationContext())
            {
                db.Set<TipoDeDocumento>().Update(tipo);
                db.SaveChanges();
            }
        }

        internal void NovoTipoDeDocumento(TipoDeDocumento tipoDeDocumento)
        {
            using (var db = new DinnamuSApplicationContext())
            {
                db.Set<TipoDeDocumento>().Add(tipoDeDocumento);
                db.SaveChanges();
            }
        }

        public void ExcluirTipo(TipoDeDocumento tipoDeDocumento)
        {
            using (var contexto = new DinnamuSApplicationContext())
            {
                contexto.Set<TipoDeDocumento>().Remove(tipoDeDocumento);
                contexto.SaveChanges();
            }
        }
    }
}
