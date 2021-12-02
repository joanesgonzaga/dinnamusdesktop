using DinnamuS_2._0_Desktop.Model.Endereco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DinnamuS_2._0_Desktop.Model
{
    [Table("PessoaEnderecos")]
    public class PessoaEndereco
    {
        [Key]
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        //[Column("PaisId")]
        //public int PaisId { get; set; }

        //public Pais Pais { get; set; }

        [Column("UfId")]
        public int UFId { get; set; }

        public UF UF { get; set; }

        public int MunicipioId { get; set; }

        public Municipio Municipio { get; set; }

        public int TipoEnderecoId { get; set; }

        //Propriedade abaixo é de navegação
        public TipoEndereco TipoEndereco { get; set; }

        //Propriedade abaixo é para salvar na tabela o nome do tipo
        [Column("TipoEndereco")]
        public string TipoDeEndereco { get; set; }
    }
}
