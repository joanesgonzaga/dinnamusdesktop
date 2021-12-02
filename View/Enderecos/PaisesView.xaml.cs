using DinnamuS_2._0_Desktop.Controller;
using DinnamuS_2._0_Desktop.Model.Endereco;
using DinnamuS_2._0_Desktop.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DinnamuS_2._0_Desktop.View.Enderecos
{
    /// <summary>
    /// Lógica interna para MunicipiosView.xaml
    /// </summary>
    public partial class PaisesView : Window
    {
        PaisController controller;
        //UFController ufController;
        StatusView status;
        Pais pais;
        List<Pais> paises;
        List<Button> buttons;

        public PaisesView()
        {
            InitializeComponent();
            //ufController = new UFController();
            //CarregaComboUFs();
            paises = new List<Pais>();

        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            if (status.Status == StatusView.StatusValues.Nenhum || status.Status == StatusView.StatusValues.Navegando)
            {
                status.Status = StatusView.StatusValues.Adicionando;

                pais = new Pais();

                gridDados.DataContext = pais;
            }

            else if (status.Status == StatusView.StatusValues.Adicionando)
            {
                try
                {
                    pais.CodigoIBGE = txtCodigoIBGE.Text.Trim();

                    //municipio.UF = (UF)cbUFs.SelectedItem;
                    pais.Nome = txtPais.Text.Trim();

                    controller.AdicionarPais(pais);

                    status.Status = StatusView.StatusValues.Navegando;

                    MessageBox.Show("País " + pais.Nome + " cadastrado com sucesso!", "Cadastro de Países", MessageBoxButton.OK, MessageBoxImage.Information);

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
                    controller.AtualizaPais(pais);
                    status.Status = StatusView.StatusValues.Navegando;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            CarregaDataGridMunicipios();

            ControlaCRUDButtons.Controlar(this, status, buttons);
        }

        private void CarregaDataGridMunicipios()
        {
            dataGridEntidades.DataContext = controller.RetornaPaises();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (status.Status == StatusView.StatusValues.Navegando)
            {
                status.Status = StatusView.StatusValues.Editando;
            }

            else if (status.Status == StatusView.StatusValues.Adicionando || status.Status == StatusView.StatusValues.Editando)
            {
                status.Status = StatusView.StatusValues.Navegando;
            }

            ControlaCRUDButtons.Controlar(this, status, buttons);
        }

        /*
        private void btnExcluir_Click(object sender, RoutedEventArgs e)
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

        */

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {

            if (pais == null)
            {
                MessageBox.Show("Não existe município selecionado para exclusão");
            }

            else
            {
                if (MessageBox.Show("Tem certeza que deseja excluir o município " + pais.Nome + " ?", "Exclusão de Registro", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        controller.RemovePais(pais);

                        //Atualiza a List<Municipio> após a exclusão do item e atualiza o DataGrid após a exclusão
                        paises.Remove(pais);
                        dataGridEntidades.ItemsSource = null;
                        dataGridEntidades.ItemsSource = paises;

                        //Verifica se o DataGrid tem itens para poder selecionar o primeiro da lista
                        if (dataGridEntidades.Items.Count > 0)
                        {
                            Municipio item = (Municipio)dataGridEntidades.Items[0];
                            dataGridEntidades.SelectedItem = item;
                            dataGridEntidades.ScrollIntoView(item);
                            DataGridRow row = (DataGridRow)dataGridEntidades.ItemContainerGenerator.ContainerFromIndex(dataGridEntidades.SelectedIndex);
                            row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));

                            pais = (Pais)dataGridEntidades.SelectedItem;

                            //Atualiza a Grid de dados com o municipio selecionado no DataGrid
                            gridDados.DataContext = pais;

                            //Seleciona o comboBox de UFs com a UF do município selecionado no DataGrid (não está automático)
                            /*
                            int indexUF = 0;
                            foreach (UF uf in cbUFs.Items)
                            {
                                if (uf.Uf == municipio.UF.Uf)
                                {
                                    indexUF = cbUFs.Items.IndexOf(uf);
                                }
                            }

                            cbUFs.SelectedIndex = indexUF;
                            */
                            status.Status = StatusView.StatusValues.Editando;
                        }

                        //Caso o DataGrid não tenha itens, limpa o objeto do Binding e muda para o status Nenhum
                        else
                        {
                            Municipio m = new Municipio();
                            gridDados.DataContext = m;

                            status.Status = StatusView.StatusValues.Nenhum;
                        }

                        ControlaCRUDButtons.Controlar(this, status, buttons);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exclusão de Registro", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }

        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            //Cria lista de botões para método de controle
            buttons = new List<Button>();
            buttons.Add(btnNovo);
            buttons.Add(btnEditar);
            buttons.Add(btnExcluir);
            buttons.Add(btnLimpar);
            buttons.Add(btnSair);
            buttons.Add(btnPesquisar);


            controller = new PaisController();
            //ufController = new UFController();
            //CarregaComboUFs();
            paises = controller.RetornaPaises();
            dataGridEntidades.ItemsSource = paises;

            status = new StatusView();
            status.Status = StatusView.StatusValues.Nenhum; //Depois voltar para modo Nenhum
            ControlaCRUDButtons.Controlar(this, status, buttons);

            statusBar.DataContext = status;
        }

        /*
        private void CarregaComboUFs()
        {
            controller = new MunicipiosController();

            cbUFs.ItemsSource = ufController.RetornaUFs();
        }
        */

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
                            pais = (Pais)dgr.Item;
                            gridDados.DataContext = paises;

                            /*
                            int index = 0;

                            foreach (UF item in cbUFs.Items)
                            {
                                if (item.Uf == municipio.UF.Uf)
                                {
                                    index = cbUFs.Items.IndexOf(item);
                                }
                            }
                            */

                            //cbUFs.SelectedIndex = index;
                            status.Status = StatusView.StatusValues.Navegando;
                            ControlaCRUDButtons.Controlar(this, status, buttons);
                        }

                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocorreram erros ao carregar os dados do país \n" + ex.Message, "Consulta de Países", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                string termoBusca;

                if (!String.IsNullOrEmpty(txtCodigoIBGE.Text))
                {
                    termoBusca = txtCodigoIBGE.Text.Trim();
                    paises = controller.RetornaPaisPorIBGE(termoBusca);
                }

                else if (!string.IsNullOrEmpty(txtPais.Text))
                {
                    termoBusca = txtPais.Text.Trim();
                    paises = controller.RetornaPaisesPorNome(termoBusca);
                }

                dataGridEntidades.ItemsSource = paises;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {

            if (status.Status == StatusView.StatusValues.Nenhum || status.Status == StatusView.StatusValues.Navegando)
            {
                pais = new Pais();
                paises = new List<Pais>();

                txtCodigoIBGE.Text = "";
                txtPais.Text = "";
                dataGridEntidades.ItemsSource = null;
                dataGridEntidades.Items.Clear();
                dataGridEntidades.ItemsSource = paises;
                gridDados.DataContext = pais;
                //cbUFs.SelectedIndex = -1;
                status.Status = StatusView.StatusValues.Nenhum;
            }

            else if (status.Status == StatusView.StatusValues.Adicionando)
            {
                txtCodigoIBGE.Text = "";
                txtPais.Text = "";
                //cbUFs.SelectedIndex = -1;
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Utils.FecharView.Fechar(status, this, e);
        }
    }
}
