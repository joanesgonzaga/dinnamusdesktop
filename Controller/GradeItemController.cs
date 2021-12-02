using DinnamuS_2._0_Desktop.Data;
using DinnamuS_2._0_Desktop.Model.Estoque;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DinnamuS_2._0_Desktop.Controller
{
    public class GradeItemController
    {
        protected List<GradeItem> itensDaGrade;

        public GradeItemController()
        {
            itensDaGrade = new List<GradeItem>();
        }

        public List<GradeItem> RetornaItensDaGrade(Grade grade)
        {
            using (var contexto = new DinnamuSApplicationContext())
            {
                itensDaGrade = contexto.Set<GradeItem>().Where(ig => ig.Grade == grade).ToList();
            }

                return itensDaGrade;
        }
    }
}
