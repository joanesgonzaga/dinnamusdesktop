using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DinnamuS_2._0_Desktop.Model
{
    [Table("Fornecedores")]
    class Fornecedor : Pessoa
    {
        public string NomeFantasia { get; set; }
    }
}
