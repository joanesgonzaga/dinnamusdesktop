using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DinnamuS_2._0_Desktop.Model.Endereco
{
    public class UF
    {
        public int Id { get; set; }

        public string CodigoIBGE { get; set; }

        public string Uf { get; set; }

        public string Estado { get; set; }

        public int PaisId { get; set; }

        public Pais Pais { get; set; }

        public List<Municipio> Municipios { get; set; }
    }
}
