using DinnamuS_2._0_Desktop.Controller;
using DinnamuS_2._0_Desktop.Model;
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

namespace DinnamuS_2._0_Desktop.View.Estoque
{
    /// <summary>
    /// Lógica interna para CRUDProdutosView.xaml
    /// </summary>
    public partial class CRUDProdutosView : Window
    {

        public static int ProdutoId = 0;
        public Produto produto = new Produto();
        StatusView status = new StatusView();

        ProdutoController controller;

        List<Button> buttons;
        

        public CRUDProdutosView()
        {
            InitializeComponent();
            
            controller = new ProdutoController();
            
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            buttons = new List<Button>();
            buttons.Add(btnNovo);
            buttons.Add(btnEditar);
            buttons.Add(btnExcluir);
            buttons.Add(btnLimpar);


            
            status.Status = StatusView.StatusValues.Nenhum;

            ControlaCRUDButtons.Controlar(this, status,buttons);

            statusBar.DataContext = status;
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            if (status.Status == StatusView.StatusValues.Nenhum || status.Status == StatusView.StatusValues.Navegando)
            {
                status.Status = StatusView.StatusValues.Adicionando;
                
                produto = new Produto();
                //produto.isAtivo = true;
                gridDadosProduto.DataContext = produto;

            }

            else if (status.Status == StatusView.StatusValues.Adicionando)
            {
                try
                {
                    produto.DataCadastro = System.DateTime.Now;
                    
                    //produto.isAtivo = (bool)chkBoxAtivo.IsChecked;
                    controller.AdicionarProduto(produto);
                    gridDadosProduto.DataContext = produto;
                    txtCodigo.Text = produto.Id.ToString();
                    status.Status = StatusView.StatusValues.Navegando;
                    MessageBox.Show("Produto " + produto.Nome + " cadastrado com sucesso!", "Cadastro de Produtos", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.Message);
                }
            }

            else if (status.Status == StatusView.StatusValues.Editando)
            {
                try
                {
                    controller.AtualizarProduto(produto);
                    gridDadosProduto.DataContext = produto;
                    status.Status = StatusView.StatusValues.Navegando;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            ControlaCRUDButtons.Controlar(this, status, buttons);
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (status.Status == StatusView.StatusValues.Navegando)
            {
                status.Status = StatusView.StatusValues.Editando;
            }

            else if (status.Status == StatusView.StatusValues.Adicionando)
            {
                produto = null;
                gridDadosProduto.DataContext = produto;
                
                status.Status = StatusView.StatusValues.Nenhum;
            }

            else if (status.Status == StatusView.StatusValues.Editando)
            {
                status.Status = StatusView.StatusValues.Navegando;
            }

            ControlaCRUDButtons.Controlar(this, status, buttons);
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (produto == null)
            {
                MessageBox.Show("Não existe produto selecionado para exclusão");
            }

            else
            {
                if (MessageBox.Show("Tem certeza que deseja excluir o produto " + produto.Nome + " ?", "Exclusão de Registro", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        controller.RemoverProduto(produto);

                        //Código para limpar componentes WPF
                        
                        produto = new Produto(); //Talvez essa instanciação seja desnecessária.
                        Utils.LimparComponentesDaView.Limpar(this);
                        txtCodigo.Text = "";
                        status.Status = StatusView.StatusValues.Nenhum;

                        ControlaCRUDButtons.Controlar(this, status, buttons);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            Utils.LimparComponentesDaView.Limpar(this);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Utils.FecharView.Fechar(status, this, e);
        }
    }
    }

