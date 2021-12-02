using DinnamuS_2._0_Desktop.Controller;
using DinnamuS_2._0_Desktop.Model.Contatos;
using DinnamuS_2._0_Desktop.Utils;
using System;
using System.Linq;
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
using DinnamuS_2._0_Desktop.Model;

namespace DinnamuS_2._0_Desktop.View
{
    /// <summary>
    /// Lógica interna para TiposDeContatos.xaml
    /// </summary>
    public partial class TiposDeDocumentos : Window
    {
        TiposDeDocumentosController controller;
        StatusView status;
        TipoDeDocumento tipoDeDocumento;
        TipoDeDocumento ultimoTipoCadastrado;
        List<TipoDeDocumento> listaDeTipos;

        public TiposDeDocumentos()
        {
            InitializeComponent();

            CarregaGrid();
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            if (status.Status == StatusView.StatusValues.Nenhum)
            {
                status.Status = StatusView.StatusValues.Adicionando;
                gridDados.DataContext = null;
                txtTipo.Focus();
                ControlaCRUDButtons();
            }

            else if (status.Status == StatusView.StatusValues.Navegando)
            {
                status.Status = StatusView.StatusValues.Adicionando;
                gridDados.DataContext = null;
                txtTipo.Focus();
                ControlaCRUDButtons();
            }

            else if (status.Status == StatusView.StatusValues.Adicionando)
            {

                try
                {
                    tipoDeDocumento = new TipoDeDocumento();

                    tipoDeDocumento.Tipo = txtTipo.Text;
                    tipoDeDocumento.Mascara = txtMascara.Text;

                    controller.NovoTipoDeDocumento(tipoDeDocumento);

                    ultimoTipoCadastrado = tipoDeDocumento;
                    status.Status = StatusView.StatusValues.Navegando;
                    gridDados.DataContext = tipoDeDocumento;
                    CarregaGrid();
                    ControlaCRUDButtons();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                
            }

            else if (status.Status == StatusView.StatusValues.Editando)
            {
                try
                {
                    controller.AtualizaTipoDocumento(tipoDeDocumento);

                    status.Status = StatusView.StatusValues.Navegando;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ControlaCRUDButtons();
            }
        }

        public void CarregaGrid()
        {
            dataGridEntidades.ItemsSource = null;
            dataGridEntidades.Items.Clear();
            listaDeTipos = controller.RetornaTiposDocumentos();
            dataGridEntidades.ItemsSource = listaDeTipos;

          
            if (ultimoTipoCadastrado != null)
            {
                //dataGridEntidades.SelectedItem = listaDeTipos.Find(t => t.Id == ultimoTipoCadastrado.Id);
                //dataGridEntidades.Row
                SelectRowByIndex(dataGridEntidades, ultimoTipoCadastrado);
            }
            
        }

        public static void SelectRowByIndex(DataGrid dataGrid, TipoDeDocumento tipo)
        {
            int rowIndex = 0;
            foreach (object itemch in dataGrid.Items)
            {
                TipoDeDocumento pttemp = (TipoDeDocumento)itemch;
                if (tipo.Id == pttemp.Id)
                {
                    rowIndex = dataGrid.Items.IndexOf(pttemp);
                    break;
                }
            }

            
            //dataGrid.SelectedItems.Clear();
            TipoDeDocumento item = (TipoDeDocumento)dataGrid.Items[rowIndex];
            dataGrid.SelectedItem = item;
            dataGrid.ScrollIntoView(item);
            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            
        }


        private void ControlaCRUDButtons()
        {
            if (status.Status == StatusView.StatusValues.Nenhum)
            {
                btnNovo.Content = "Novo";
                btnNovo.IsEnabled = true;
                btnEditar.IsEnabled = false;
                btnExcluir.IsEnabled = false;
                btnLimpar.IsEnabled = true;
                //btnEndereco.IsEnabled = false;
                //ControlaCRUDDataGrid(status, cliente.Enderecos);
                DesabilitaTextBox(false);

            }

            else if (status.Status == StatusView.StatusValues.Navegando)
            {
                btnNovo.Content = "Novo";
                btnNovo.IsEnabled = true;
                btnEditar.Content = "Editar";
                btnEditar.IsEnabled = true;
                btnExcluir.IsEnabled = false;
                btnLimpar.IsEnabled = false;
                //btnEndereco.IsEnabled = false;
                //ControlaCRUDDataGrid(status, cliente.Enderecos);
                DesabilitaTextBox(false);

            }

            else if (status.Status == StatusView.StatusValues.Editando)
            {
                btnNovo.Content = "Gravar";
                btnNovo.IsEnabled = true;
                btnEditar.Content = "Cancelar";
                btnEditar.IsEnabled = true;
                btnExcluir.IsEnabled = true;
                btnLimpar.IsEnabled = false;
                //btnEndereco.IsEnabled = true;
                //ControlaCRUDDataGrid(status, cliente.Enderecos);
                DesabilitaTextBox(true);

            }

            else if (status.Status == StatusView.StatusValues.Adicionando)
            {
                btnNovo.Content = "Gravar";
                btnNovo.IsEnabled = true;
                btnEditar.Content = "Cancelar";
                btnEditar.IsEnabled = true;
                btnExcluir.IsEnabled = false;
                btnLimpar.IsEnabled = true;
                DesabilitaTextBox(true);
                //btnEndereco.IsEnabled = false;

                //ControlaCRUDDataGrid(status, cliente.Enderecos);

            }
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            status = new StatusView();
            controller = new TiposDeDocumentosController();
            status.Status = StatusView.StatusValues.Nenhum;
            listaDeTipos = new List<TipoDeDocumento>();

            statusBar.DataContext = status;
           
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (status.Status == StatusView.StatusValues.Navegando)
            {
                status.Status = StatusView.StatusValues.Editando;

                txtTipo.Focus();
                ControlaCRUDButtons();
            }

            else if (status.Status == StatusView.StatusValues.Adicionando)
            {
                status.Status = StatusView.StatusValues.Nenhum;  //Pode estar errado. A mudança talvez seja para Navegando
                ControlaCRUDButtons();
            }

            else if (status.Status == StatusView.StatusValues.Editando)
            {
                status.Status = StatusView.StatusValues.Navegando;
                ControlaCRUDButtons();
            }
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {

            if (tipoDeDocumento == null)
            {
                MessageBox.Show("Não existe cliente selecionado para exclusão");
            }

            else
            {
                if (MessageBox.Show("Tem certeza que deseja excluir o cliente " + tipoDeDocumento.Tipo + " ?", "Exclusão de Registro", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //string nome = cliente.Nome;
                        controller.ExcluirTipo(tipoDeDocumento);

                        status.Status = StatusView.StatusValues.Nenhum;

                        TipoDeContato tipo = new TipoDeContato();
                        gridDados.DataContext = tipo;

                        CarregaGrid();
                        ControlaCRUDButtons();

                        if (dataGridEntidades.Items.Count > 0)
                        {
                            TipoDeContato item = (TipoDeContato)dataGridEntidades.Items[0];
                            dataGridEntidades.SelectedItem = item;
                            dataGridEntidades.ScrollIntoView(item);
                            DataGridRow row = (DataGridRow)dataGridEntidades.ItemContainerGenerator.ContainerFromIndex(dataGridEntidades.SelectedIndex);
                            row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                        }
                        

                        
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exclusão de Registro", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }





            if (tipoDeDocumento == null)
            {
                MessageBox.Show("Não foi selecionado um Tipo de Contato para exclusão", "Exclusão de Contato");
            }

            else
            {
                status.Status = StatusView.StatusValues.Nenhum;
            }
        }

        

        public void DesabilitaTextBox(bool isAtivo)
        {
            txtTipo.IsEnabled = isAtivo;
            txtMascara.IsEnabled = isAtivo;
        }

        private void dataGridEntidades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                if (sender != null)
                {
                    DataGrid grid = sender as DataGrid;
                    if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                    {
                        DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;

                        if (dgr != null)
                        {
                            tipoDeDocumento = (TipoDeDocumento)dgr.Item;
                            gridDados.DataContext = tipoDeDocumento;
                            status.Status = StatusView.StatusValues.Navegando;
                            ControlaCRUDButtons();
                        }
                        
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocorreram erros ao carregar os dados do cliente \n" + ex.Message, "Consulta de Clientes", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Utils.FecharView.Fechar(status, this, e);
        }


        /*
        try
            {

                if (sender != null)
                {
                    DataGrid grid = sender as DataGrid;
                    if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                    {
                        DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;

        TipoDeContato tipoDeContato = (TipoDeContato)dgr.Item;
        gridDados.DataContext = tipoDeContato;
                    }
}

            }

            catch (Exception ex)
{
    MessageBox.Show("Ocorreram erros ao carregar os dados do cliente \n" + ex.Message, "Consulta de Clientes", MessageBoxButton.OK, MessageBoxImage.Error);
}
        */
    }
}
