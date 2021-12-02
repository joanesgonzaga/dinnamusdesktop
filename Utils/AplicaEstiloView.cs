using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DinnamuS_2._0_Desktop.Utils
{
    
    public class AplicaEstiloView
    {
        List<Control> controles;
        public AplicaEstiloView()
        {

        }

        public void Aplicar_(Window window)
        {
            List<Visual> componentes = new List<Visual>();

            WindowComponentsListing.EnumVisual(window, componentes);

            foreach (Visual componente in componentes)
            {

                if (componente is TextBox)
                {

                    
                }

                if (componente is ComboBox)
                {
                    
                }

                if (componente is Button)
                {
                    //DefineEstiloBotoes(componente);
                }

            }
        }


        public void ExibirControles(Window window)
        {

            IList<Control> controles =  WindowComponentsListing.GetControls(window);
            
            StringBuilder nomes = new StringBuilder();
            foreach (Control controle in controles)
            {
                nomes.Append("\n" +controle.ToString());
            }

            MessageBox.Show(nomes.ToString());
        }

        public void Aplicar(Window window)
        {
            List<Visual> componentes = new List<Visual>();

            WindowComponentsListing.EnumVisual(window, componentes);

            foreach (Visual visual in componentes)
            {
                
                if (typeof(Button).IsInstanceOfType(visual))
                {
                    DefineEstiloBotoes(visual as Button);
                }

                else if (typeof(Grid).IsInstanceOfType(visual))
                {
                    DefineGrid(visual as Grid);
                }
                
            }

        }

        private void DefineEstiloTextBox(TextBox textBox)
        {

            Setter setterFontS = new Setter(Button.FontSizeProperty, 14);
            
            Style estiloCaixa = new Style();
            
            
            textBox.FontSize = 14;
        }

        private void DefineEstiloBotoes(Button button)
        {
            button.Margin = new Thickness(10);
            button.Height = 45;
            button.FontSize = 14;
            button.Background = new SolidColorBrush(Colors.Beige);
        }

        private void DefineGrid(Grid grid)
        {

        }
    }
}
