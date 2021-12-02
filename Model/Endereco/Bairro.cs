using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DinnamuS_2._0_Desktop.Model.Endereco
{
    [Table("Bairros")]
    public class Bairro
    {
        [Key]
        public int Id { get; set; }

        public string CodigoIBGE { get; set; }

        public string NomeBairro { get; set; }

        public int MunicipioId { get; set; }

        public Municipio Municipio { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Bairro bairro &&
                   Id == bairro.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
