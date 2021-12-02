using System;
using System.Collections.Generic;
using System.Text;

namespace DinnamuS_2._0_Desktop.Model.Estoque
{
    public class CombinacaoProdutoItem
    {
        public int ProdutoVariacaoItemId { get; set; }

        public List<GradeItem> ItensDaGrade { get; set; } = new List<GradeItem>();
    }
}
