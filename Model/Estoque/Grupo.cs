using DinnamuS_2._0_Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnamuS_2._0_Desktop.Model.Estoque
{
    public class Grupo
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Descricao { get; set; }

        
        public int GrupoPaiId { get; set; }
        public Grupo GrupoPai { get; set; }

        public List<Grupo> Subgrupos { get; set; }


    }
}
