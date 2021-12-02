using System;
using System.Collections.Generic;
using System.Text;

namespace DinnamuS_2._0_Desktop.Model.Estoque
{
    public class ProdutoGradesItensVariacao
    {
        public int Id { get; set; }

        public int GradeItemId { get; set; }

        public GradeItem GradeItem { get; set; }

        public int ProdutoItensId { get; set; }

        public ProdutoItens ProdutoItens { get; set; }

        //public int VariacaoId { get; set; }



        public override bool Equals(object obj)
        {
            return obj is ProdutoGradesItensVariacao variacao &&
                   Id == variacao.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
