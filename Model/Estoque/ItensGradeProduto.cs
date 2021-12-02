using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DinnamuS_2._0_Desktop.Model
{
    [Table("itensgradeproduto")]
    public class ItensGradeProduto
    {
        [Key]
        [Column("chaveunica")]
        public int Id { get; set; }

        [Column("codigo")]
        public int Codigo { get; set; }

        [Column("tamanho")]
        public string Tamanho { get; set; }

        [Column("codbarraint")]
        public string CodBarraInt { get; set; }

        
        //public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
