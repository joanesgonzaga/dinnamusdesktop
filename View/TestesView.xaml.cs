using DinnamuS_2._0_Desktop.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DinnamuS_2._0_Desktop.View
{
    /// <summary>
    /// Lógica interna para TestesView.xaml
    /// </summary>
    public partial class TestesView : Window
    {
        public TestesView()
        {
            InitializeComponent();
            Metodo();
        }


        private void Metodo()
        {
            List<Visual> componentes = new List<Visual>();

            WindowComponentsListing.EnumVisual(this, componentes);

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

        private void DefineEstiloBotoes(Button button)
        {
            button.Margin = new Thickness(10);
            button.Height = 45;
            button.FontSize = 14;
            button.Background = new SolidColorBrush(Colors.Beige);
        }

        private void DefineGrid(Grid grid)
        {
            grid.Background = new SolidColorBrush(Colors.CadetBlue);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Metodo();
        }


  
    }
}
