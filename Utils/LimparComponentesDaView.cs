using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DinnamuS_2._0_Desktop.Utils
{
    public static class LimparComponentesDaView
    {
        public static void Limpar(Window view)
        {
           
                List<Visual> componentes = new List<Visual>();

                WindowComponentsListing.EnumVisual(view, componentes);

                foreach (Visual componente in componentes)
                {

                    if (componente is TextBox)
                    {

                        if (((TextBox)componente).Name != "txtCodigo")
                        {
                            ((TextBox)componente).Text = "";
                        }
                    }

                    if (componente is ComboBox)
                    {
                        ((ComboBox)componente).SelectedIndex = -1;
                    }

                }
            
        }
    }
}
