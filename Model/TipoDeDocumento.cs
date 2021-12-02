using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DinnamuS_2._0_Desktop.Model
{
    [Table("TiposDeDocumentos")]
    public class TipoDeDocumento
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("tipo")]
        public string Tipo { get; set; }

        [Column("mascara")]
        public string Mascara { get; set; }

        public override bool Equals(object obj)
        {
            return obj is TipoDeDocumento documento &&
                   Id == documento.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
