using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DinnamuS_2._0_Desktop.Model.Endereco
{
    public class Pais
    {
        public int Id { get; set; }

        public string CodigoIBGE { get; set; }

        public string Nome { get; set; }

        public List<UF> UFs { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Pais pais &&
                   Id == pais.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}