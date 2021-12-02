using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace DinnamuS_2._0_Desktop.Utils
{
    public static class ControlaCRUDButtons
    {
        public static void Controlar(Window window, StatusView status, List<Button> buttons)
        {
            if (status.Status == StatusView.StatusValues.Nenhum)
            {
                foreach (Button b in buttons)
                {
                    switch (b.Name)
                    {
                        case "btnNovo":
                            b.Content = "Novo";
                            b.IsEnabled = true;
                            break;

                        case "btnEditar":
                            b.IsEnabled = false;
                            break;

                        case "btnExcluir":
                            b.IsEnabled = false;
                            break;

                        case "btnLimpar":
                            b.IsEnabled = false;
                            break;

                        case "btnPesquisar":
                            b.IsEnabled = true;
                            break;

                        default:

                            break;
                    }
                }
            }

            else if (status.Status == StatusView.StatusValues.Navegando)
            {
                foreach (Button b in buttons)
                {
                    switch (b.Name)
                    {
                        case "btnNovo":
                            b.Content = "Novo";
                            b.IsEnabled = true;
                            break;

                        case "btnEditar":
                            b.Content = "Editar";
                            b.IsEnabled = true;
                            break;

                        case "btnExcluir":
                            b.IsEnabled = false;
                            break;

                        case "btnLimpar":
                            b.IsEnabled = false;
                            break;

                        case "btnPesquisar":
                            b.IsEnabled = true;
                            break;

                        default:
                            break;
                    }
                }
            }

            else if (status.Status == StatusView.StatusValues.Editando)
            {
                foreach (Button b in buttons)
                {
                    switch (b.Name)
                    {
                        case "btnNovo":
                            b.Content = "Gravar";
                            b.IsEnabled = true;
                            break;

                        case "btnEditar":
                            b.Content = "Cancelar";
                            b.IsEnabled = true;
                            break;

                        case "btnExcluir":
                            b.IsEnabled = true;
                            break;

                        case "btnLimpar":
                            b.IsEnabled = false;
                            break;

                        case "btnPesquisar":
                            b.IsEnabled = false;
                            break;

                        default:
                            break;
                    }
                }
            }

            else if (status.Status == StatusView.StatusValues.Adicionando)
            {
                foreach (Button b in buttons)
                {
                    switch (b.Name)
                    {
                        case "btnNovo":
                            b.Content = "Gravar";
                            b.IsEnabled = true;
                            break;

                        case "btnEditar":
                            b.Content = "Cancelar";
                            b.IsEnabled = true;
                            break;

                        case "btnExcluir":
                            b.IsEnabled = false;
                            break;

                        case "btnLimpar":
                            b.IsEnabled = true;
                            break;

                        case "btnPesquisar":
                            b.IsEnabled = false;
                            break;

                        default:
                            break;
                    }
                }
            }

            else
            {
                throw new Exception("Status de Operação Desconhecido");
            }

        }
    }
}
