using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DinnamuS_2._0_Desktop.Utils
{
    public class StatusView : INotifyPropertyChanged
    {
        private StatusValues status;

        public StatusValues Status
        {
            get { return status; }

            set
            {
                this.status = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Status"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public enum StatusValues
        {
            Nenhum, Navegando, Adicionando, Editando
        }
    }
}
