using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace DinnamuS_2._0_Desktop.Model.Estoque
{
    public class Grade : INotifyPropertyChanged
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
                    PropertyChanged(this, new PropertyChangedEventArgs("Id")) ;
                }
            } 
        }

        private string nome;
        public string Nome {
            get { return this.nome; }
            set
            {
                this.nome = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Nome"));
                }
            }
        }

        private string descricao;

        public string Descricao {
            get { return this.descricao; }
            set
            {
                this.descricao = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Descricao"));
                }
            } 
        }

        private ObservableCollection<GradeItem> itensDaGrade;

        public ObservableCollection<GradeItem> ItensDaGrade {
            get { return this.itensDaGrade; }
            set
            {
                this.itensDaGrade = value;
                
                
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ItensDaGrade"));
                }
                
            }
        }

        public List<Produto> Produtos { get; set; }

        
    }
}
