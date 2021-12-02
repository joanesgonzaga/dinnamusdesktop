using DinnamuS_2._0_Desktop.Data;
using DinnamuS_2._0_Desktop.Model;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace DinnamuS_2._0_Desktop.Controller
{
    class ClienteController
    {

        public List<Cliente> retornaTodosClientes()
        {

            List<Cliente> lista = new List<Cliente>();

            using (var contexto = new DinnamuSApplicationContext())
            {
                
                DbSet<Cliente> q = contexto.Set<Cliente>();

                lista = q.Include("TiposDeDocumentos").ToList();
            }

            return lista;
        }

        public List<Cliente> RetornaClienteById(int id)
        {
            List<Cliente> clientes = new List<Cliente>();

            using (var contexto = new DinnamuSApplicationContext())
            {
                //db.Set<Cliente>().Find(1);
                DbSet<Cliente> cliente = contexto.Set<Cliente>(); //.Where(c => c.Id == id); //.Where(c => c.Id == id).ToList();



                //clientes = cliente.Where(c => c.Id == id) .Include("PessoaEnderecos").Include("TiposDeDocumentos") .ToList();
                //clientes = cliente.Where(p => p.Id == id).Include("PessoaEnderecos").ToList();

                clientes = cliente.Include(c => c.Enderecos).Include(c => c.TiposDeDocumentos).Where(c => c.Id == id).ToList();


            }

            return clientes;
        }

        internal void SalvarCliente(Cliente cliente)
        {
            using (var db = new DinnamuSApplicationContext())
            {
                db.Set<Cliente>().Add(cliente);
                db.SaveChanges();
            }
        }

        public string RetornaIdSocial(string cpf)
        {
            string idSocial;

            if (String.IsNullOrEmpty(cpf))
            {
              
                idSocial = "Não informado";
              
            }

            else if (cpf.Length == 11)
            {
                
                idSocial = string.Format("{0:000\\.000\\.000-00}", Convert.ToInt64(cpf));
                
            }
            else if(cpf.Length == 14)
            {
                idSocial = string.Format("{0:00\\.000\\.000\\/0000-00}", Convert.ToInt64(cpf));
                
            }

            else
            {
                
                idSocial = cpf;
                
            }

            return idSocial;
        }

        public List<Cliente> RetornaParceirosPeloNome(string termoBusca)
        {
            List<Cliente> clientes = new List<Cliente>();

            using (var contexto = new DinnamuSApplicationContext())
            {
                DbSet<Cliente> cliente = contexto.Set<Cliente>();
                //Os métodos ToLower() foram necessários, pois o PostGreSQL está em modo Case Sensitive
                //Elas reproduzem a query abaixo, que torna LowCase tanto a coluna quanto o valor passado:
                /*
                SELECT *
                FROM public."Pessoas"
                WHERE LOWER(nome) = LOWER('termobusca')
                */
                clientes = cliente.Where(p => p.Nome.ToLower() .Contains(termoBusca.ToLower())).Include("TiposDeDocumentos").ToList();
            }

            return clientes;
        }
    }
}
