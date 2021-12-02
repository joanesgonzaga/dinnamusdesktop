using DinnamuS_2._0_Desktop.Data;
using DinnamuS_2._0_Desktop.Model.Endereco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DinnamuS_2._0_Desktop.Controller
{
    public class UFController
    {
        List<UF> ufs;

        public UFController()
        {
            ufs = new List<UF>();
        }

        public List<UF> RetornaUFs()
        {
            using (var db = new DinnamuSApplicationContext())
            {
                //var ufs = (DbSet<UF>)db.Set<UF>().Include(u => u.Pais);

                ufs = db.Set<UF>().Include(u => u.Pais).ToList();
            }

            return ufs;
        }
    }
}
