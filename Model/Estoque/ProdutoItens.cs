using System;
using System.Collections.Generic;
using System.Text;

namespace DinnamuS_2._0_Desktop.Model.Estoque
{
    public class ProdutoItens
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }

        public string RotuloVariacao { get; set; }

        public List<ProdutoGradesItensVariacao> produtoGradesItensVariacaos { get; set; } = new List<ProdutoGradesItensVariacao>();

    }
}
