using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DinnamuS_2._0_Desktop.Model
{
    public class Pessoa
    {
        public int Id { get; set; }

        public int Codigo { get; set; }

        public string Nome { get; set; }

        public bool isAtivo { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataNascimento { get; set; }

        public TipoDeDocumento TiposDeDocumentos { get; set; }

        public string Doc { get; set; }

        public List<PessoaContatos> Contatos { get; set; }

        public List<PessoaEndereco> Enderecos { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Pessoa pessoa &&
                   Id == pessoa.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
