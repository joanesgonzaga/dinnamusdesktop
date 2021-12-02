using DinnamuS_2._0_Desktop.Data;
using DinnamuS_2._0_Desktop.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinnamuS_2._0_Desktop.Controller
{
    public class ProdutoController
    {
        

        public List<Produto> retornaProdutoByNome(string termoBusca)
        {
            using var db = new DinnamuSApplicationContext();

            return db.Set<Produto>().Where(p => p.Nome.Contains(termoBusca)).OrderBy(p => p.Nome).ToList(); //Include(p => p.ItensGradeProdutos) .ToList();
        }

        /*
        public List<Produto> retornaProdutosByCodigo(int codigo)
        {
            using var db = new DinnamuSApplicationContext();

            return db.Set<Produto>().Where(p => p.Codigo == codigo).Include(p => p.ProdutosItens).ToList();
        }
        */

        public void AdicionarProduto(Produto produto)
        {
            using (var db = new DinnamuSApplicationContext())
            {
                db.Entry(produto).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        internal void AtualizarProduto(Produto produto)
        {
            using (var db = new DinnamuSApplicationContext())
            {
                //db.Entry(produto).State = EntityState.;
                db.Set<Produto>().Update(produto);
                db.SaveChanges();
            }
        }

        internal void RemoverProduto(Produto produto)
        {
            using (var db = new DinnamuSApplicationContext())
            {
                db.Set<Produto>().Remove(produto);
                db.SaveChanges();
            }
        }
    }
}
