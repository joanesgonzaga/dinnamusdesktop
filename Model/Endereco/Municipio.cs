using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DinnamuS_2._0_Desktop.Model.Endereco
{
    public class Municipio
    {
        public int Id { get; set; }
        public string CodigoIBGE { get; set; }

        public string NomeMunicipio { get; set; }

        public int UFId { get; set; }

        public UF UF { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Municipio municipio &&
                   Id == municipio.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
