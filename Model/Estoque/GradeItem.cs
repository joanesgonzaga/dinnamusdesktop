using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DinnamuS_2._0_Desktop.Model.Estoque
{
    public class GradeItem : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        public int Id {
            get { return this.id; } 
            set
            {
                this.id = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Id") );
                }
            } 
        }

        private string variacao;
        public string Variacao {
            get { return this.variacao; }
            set
            {
                this.variacao = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Variacao"));
                }
            }
        }


        private int gradeId;
        public int GradeId {
            get { return this.gradeId; }
            set
            {
                this.gradeId = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("GradeId"));
                }
            }
        }

        public Grade Grade { get; set; }


        private int ordem;
        public int Ordem {
            get { return this.ordem; }
            set
            {
                this.ordem = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Ordem"));
                }
            } 
        }

        public override bool Equals(object obj)
        {
            return obj is GradeItem item &&
                   Variacao == item.Variacao;
        }
    }
}
