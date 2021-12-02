using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DinnamuS_2._0_Desktop.Model
{
    public class Cliente : Pessoa
    {
        public string Sexo { get; set; }

        //public int PessoaId { get; set; }

        //public Pessoa Pessoa { get; set; }
    }
}
