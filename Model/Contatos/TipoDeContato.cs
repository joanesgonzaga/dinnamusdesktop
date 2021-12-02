using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DinnamuS_2._0_Desktop.Model.Contatos
{
    [Table("TiposDeContatos")]
    public class TipoDeContato
    {
        [Key]
        public int Id { get; set; }

        public string Tipo { get; set; }

        public string Mascara { get; set; }

        public override string ToString()
        {
            return "Código: " + this.Id + ", Tipo: " + this.Tipo + ", Máscara: " + this.Mascara;
        }

        public override bool Equals(object obj)
        {
            return obj is TipoDeContato contato &&
                   Id == contato.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }


    }


}
