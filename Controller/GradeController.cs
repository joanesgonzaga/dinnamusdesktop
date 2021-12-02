using DinnamuS_2._0_Desktop.Data;
using DinnamuS_2._0_Desktop.Model.Estoque;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DinnamuS_2._0_Desktop.Controller
{
    public class GradeController
        
    {
        Grade grade;

        public GradeController()
        {
            grade = new Grade();
        }

        public void AdicionarGrade(Grade grade)
        {
            using (var contexto = new DinnamuSApplicationContext())
            {
                
                contexto.Entry(grade).State = EntityState.Added;
                contexto.SaveChanges();
            }
        }

        public void AtualizarGrade(Grade grade)
        {
            using (var contexto = new DinnamuSApplicationContext())
            {
                contexto.Set<Grade>().Update(grade);
                contexto.SaveChanges();
            }
        }


        public List<Grade> CarregarGrades()
        {
            List<Grade> grades;

            using (var contexto = new DinnamuSApplicationContext())
            {
                grades = contexto.Set<Grade>().Where(g => g.Id > 1).ToList();
            }

            return grades;
        }

        public Grade RetornaGradeComItens(int gradeId)
        {
            using (var contexto = new DinnamuSApplicationContext())
            {
                grade = contexto.Set<Grade>().Include(g => g.ItensDaGrade).Where(g => g.Id == gradeId).Single();
            }

            return grade;
        }

        internal void RemoverGrade(Grade grade)
        {
            using (var contexto = new DinnamuSApplicationContext())
            {
                contexto.Set<Grade>().Remove(grade);
                contexto.SaveChanges();
            }
        }

        public void RemoveItensDaGrade(List<GradeItem> itens)
        {
            using (var contexto = new DinnamuSApplicationContext())
            {
                contexto.RemoveRange(itens);
            }
        }

        public void RemoveItemDaGrade(Grade grade, GradeItem item)
        {
            Grade grade1;

            using (var contexto = new DinnamuSApplicationContext())
            {
                grade1 = contexto.Set<Grade>().Where(g => g.Id == grade.Id).Include(g => g.ItensDaGrade).First();

                grade1.ItensDaGrade.Remove(item);

                contexto.Set<Grade>().Update(grade1);
                contexto.SaveChanges();
            }
        }
    }
}
