using DinnamuS_2._0_Desktop.Model.Estoque;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Linq;

namespace DinnamuS_2._0_Desktop.Model
{
    
    public class Produto
    {
        public int Id { get; set; }

        public int Codigo { get; set; }

        public int Loja { get; set; }

        public string Nome { get; set; }

        public string NomeImpresso { get; set; }

        public DateTime DataCadastro { get; set; }

        //public int Linha { get; set; }

        //public int Colecao { get; set; }

        //public bool isAtivo { get; set; }

        //Não instancia um List<Grade> exatamente, mas sim ProdutoGradeConfiguration (N:N)
        public List<Grade> Grades { get; set; } = new List<Grade>();

        public List<ProdutoItens> ProdutosItens { get; set; } = new List<ProdutoItens>();

        public List<ProdutoGradesItensVariacao> ItensGradesProdutos { get; set; }


    }
}
