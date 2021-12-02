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
    public partial class MunicipiosView : Window
    {
        MunicipiosController controller;
        UFController ufController;
        StatusView status;
        Municipio municipio;
        List<Municipio> municipios;
        List<Button> buttons;

        public MunicipiosView()
        {
            InitializeComponent();
            ufController = new UFController();
            CarregaComboUFs();
            municipios = new List<Municipio>();

        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            if (status.Status == StatusView.StatusValues.Nenhum || status.Status == StatusView.StatusValues.Navegando)
            {
                status.Status = StatusView.StatusValues.Adicionando;

                municipio = new Municipio();

                gridDados.DataContext = municipio;
            }

            else if (status.Status == StatusView.StatusValues.Adicionando)
            {
                try
                {
                    municipio.CodigoIBGE = txtCodigoIBGE.Text.Trim();

                    municipio.UF = (UF)cbUFs.SelectedItem;
                    municipio.NomeMunicipio = txtMunicipio.Text.Trim();

                    controller.AdicionarMunicipio(municipio);

                    status.Status = StatusView.StatusValues.Navegando;

                    MessageBox.Show("Município " + municipio.NomeMunicipio + " cadastrado com sucesso!", "Cadastro de Municípios", MessageBoxButton.OK, MessageBoxImage.Information);

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
                    controller.AtualizaMunicipio(municipio);
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
            dataGridEntidades.DataContext = controller.RetornaTodosMunicipios();
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

            if (municipio == null)
            {
                MessageBox.Show("Não existe município selecionado para exclusão");
            }

            else
            {
                if (MessageBox.Show("Tem certeza que deseja excluir o município " + municipio.NomeMunicipio + " ?", "Exclusão de Registro", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        controller.RemoveMunicipio(municipio);

                        //Atualiza a List<Municipio> após a exclusão do item e atualiza o DataGrid após a exclusão
                        municipios.Remove(municipio);
                        dataGridEntidades.ItemsSource = null;
                        dataGridEntidades.ItemsSource = municipios;

                        //Verifica se o DataGrid tem itens para poder selecionar o primeiro da lista
                        if (dataGridEntidades.Items.Count > 0)
                        {
                            Municipio item = (Municipio)dataGridEntidades.Items[0];
                            dataGridEntidades.SelectedItem = item;
                            dataGridEntidades.ScrollIntoView(item);
                            DataGridRow row = (DataGridRow)dataGridEntidades.ItemContainerGenerator.ContainerFromIndex(dataGridEntidades.SelectedIndex);
                            row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));

                            municipio = (Municipio)dataGridEntidades.SelectedItem;

                            //Atualiza a Grid de dados com o municipio selecionado no DataGrid
                            gridDados.DataContext = municipio;

                            //Seleciona o comboBox de UFs com a UF do município selecionado no DataGrid (não está automático)
                            int indexUF = 0;
                            foreach (UF uf in cbUFs.Items)
                            {
                                if (uf.Uf == municipio.UF.Uf)
                                {
                                    indexUF = cbUFs.Items.IndexOf(uf);
                                }
                            }

                            cbUFs.SelectedIndex = indexUF;

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


            controller = new MunicipiosController();
            ufController = new UFController();
            //CarregaComboUFs();
            status = new StatusView();
            status.Status = StatusView.StatusValues.Nenhum; //Depois voltar para modo Nenhum
            ControlaCRUDButtons.Controlar(this, status, buttons);

            statusBar.DataContext = status;
        }

        private void CarregaComboUFs()
        {
            controller = new MunicipiosController();

            cbUFs.ItemsSource = ufController.RetornaUFs();
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
                            municipio = (Municipio)dgr.Item;
                            gridDados.DataContext = municipio;

                            int index = 0;

                            foreach (UF item in cbUFs.Items)
                            {
                                if (item.Uf == municipio.UF.Uf)
                                {
                                    index = cbUFs.Items.IndexOf(item);
                                }
                            }

                            cbUFs.SelectedIndex = index;
                            status.Status = StatusView.StatusValues.Navegando;
                            ControlaCRUDButtons.Controlar(this, status, buttons);
                        }

                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocorreram erros ao carregar os dados do município \n" + ex.Message, "Consulta de Municípios", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            string termoBusca;

            if (!String.IsNullOrEmpty(txtCodigoIBGE.Text))
            {
                termoBusca = txtCodigoIBGE.Text.Trim();
                municipios = controller.RetornaMunicipioPorIBGE(termoBusca);
            }

            else if (!string.IsNullOrEmpty(txtMunicipio.Text) && cbUFs.SelectedIndex >= 0)
            {
                termoBusca = txtMunicipio.Text.Trim();
                UF uf = (UF)cbUFs.SelectedItem;
                municipios = controller.RetornamunicipiosPorNomeEUF(termoBusca, uf.Uf);
            }

            else if (!string.IsNullOrEmpty(txtMunicipio.Text))
            {
                termoBusca = txtMunicipio.Text.Trim();
                municipios = controller.RetornamunicipiosPorNome(termoBusca);
            }

            dataGridEntidades.ItemsSource = municipios;
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {

            if (status.Status == StatusView.StatusValues.Nenhum || status.Status == StatusView.StatusValues.Navegando)
            {
                municipio = new Municipio();
                municipios = new List<Municipio>();

                txtCodigoIBGE.Text = "";
                txtMunicipio.Text = "";
                dataGridEntidades.ItemsSource = null;
                dataGridEntidades.Items.Clear();
                dataGridEntidades.ItemsSource = municipios;
                gridDados.DataContext = municipio;
                cbUFs.SelectedIndex = -1;
                status.Status = StatusView.StatusValues.Nenhum;
            }

            else if (status.Status == StatusView.StatusValues.Adicionando)
            {
                txtCodigoIBGE.Text = "";
                txtMunicipio.Text = "";
                cbUFs.SelectedIndex = -1;
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Utils.FecharView.Fechar(status, this, e);
        }
    }
}
