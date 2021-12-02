using DinnamuS_2._0_Desktop.Model.Contatos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DinnamuS_2._0_Desktop.Model
{
    [Table("PessoaContatos")]
    public class PessoaContatos
    {
        public int Id { get; set; }

        public string Contato { get; set; }

        public int PessoaId { get; set; }

        public Pessoa Pessoa { get; set; }

        public int TipoDeContatoId { get; set; }

        public TipoDeContato TipoDeContato { get; set; }

        public override bool Equals(object obj)
        {
            return obj is PessoaContatos contatos &&
                   Id == contatos.Id &&
                   PessoaId == contatos.PessoaId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, PessoaId);
        }
    }
}
