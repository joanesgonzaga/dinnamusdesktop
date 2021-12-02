using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace DinnamuS_2._0_Desktop.Utils
{
    public static class FecharView
    {
        public static void Fechar(StatusView status, Window window, System.ComponentModel.CancelEventArgs e)
        {
            if (status.Status == StatusView.StatusValues.Adicionando || status.Status == StatusView.StatusValues.Editando)
            {
                MessageBox.Show("Não é permitido sair da tela durante uma Operação de ADIÇÂO ou EDIÇÂO de registro" + "\nSaia da Operação de ADIÇÂO/EDIÇÂO e clique em Sair", "EXCLUSÃO DE REGISTRO", MessageBoxButton.OK, MessageBoxImage.Warning);
                
                e.Cancel = true;
            }

            else
            {
                e.Cancel = false;
            }
        }
    }
}
