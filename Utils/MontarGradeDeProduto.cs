using DinnamuS_2._0_Desktop.Model.Estoque;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinnamuS_2._0_Desktop.Utils
{
    public static class MontarGradeDeProduto
    {
        public static List<CombinacaoProdutoItem> MontarGrade(List<Grade> gradesDoProduto)
        {
            List<CombinacaoProdutoItem> retorno = new List<CombinacaoProdutoItem>();
            int tamanhoDaPrimeiraGrade = gradesDoProduto[0].ItensDaGrade.Count;
            int indice = 0;
            GradeItem gradeItem;
            // p m g
            // azul / pto
            //List<CombinacaoProdutoItem> itensDaGrade = new List<CombinacaoProdutoItem>();
            CombinacaoProdutoItem combinacaoProdutoItem = new CombinacaoProdutoItem();
            while (indice < tamanhoDaPrimeiraGrade)
            {
                gradeItem = gradesDoProduto[0].ItensDaGrade[indice];
                if (gradesDoProduto.Count > 1) // chama recursividade
                {
                    List<Grade> sublist = gradesDoProduto.GetRange(1, gradesDoProduto.Count - 1);
                    // azul , pto
                    List<CombinacaoProdutoItem> subvariacoes = MontarGrade(sublist);

                    foreach (CombinacaoProdutoItem combinacaoItem in subvariacoes)
                    {
                        combinacaoItem.ItensDaGrade.Add(gradeItem);

                        retorno.Add(combinacaoItem);
                    }
                }
                else
                {
                    combinacaoProdutoItem = new CombinacaoProdutoItem();
                    combinacaoProdutoItem.ItensDaGrade.Add(gradeItem);
                    retorno.Add(combinacaoProdutoItem);
                }

                indice++;
            }

            return retorno;
        }
    }
}
