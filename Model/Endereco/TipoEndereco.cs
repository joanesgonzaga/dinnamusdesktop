using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DinnamuS_2._0_Desktop.Model.Endereco
{
    [Table("TiposDeEnderecos")]
    public class TipoEndereco
    {
        [Key]
        public int Id { get; set; }

        public string Tipo { get; set; }
    }
}
