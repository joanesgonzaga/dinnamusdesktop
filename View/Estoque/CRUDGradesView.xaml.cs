using DinnamuS_2._0_Desktop.Controller;
using DinnamuS_2._0_Desktop.Model.Estoque;
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
    /// Lógica interna para CRUDGradesView.xaml
    /// </summary>
    public partial class CRUDGradesView : Window
    {
        StatusView status = new StatusView();
        private List<Button> buttons;
        private Grade grade;
        private List<Grade> grades;
        private GradeController controller;

        public CRUDGradesView()
        {
            InitializeComponent();
            
            grades = new List<Grade>();
            controller = new GradeController();

            buttons = new List<Button>();
            buttons.Add(btnNovo);
            buttons.Add(btnEditar);
            buttons.Add(btnExcluir);
            buttons.Add(btnLimpar);

            

            statusBar.DataContext = status;
            
            CarregarGridGrade();
        }

        private void HabilitarComponentes(bool booleano)
        {
            txtNome.IsEnabled = booleano;
            txtDescricao.IsEnabled = booleano;

            btnAdicionarItem.IsEnabled = booleano;
        }
        private void CarregarGridGrade()
        {
            try
            {
                HabilitarComponentes(false);

                dataGridEntidades.ItemsSource = null;
                dataGridEntidades.Items.Clear();
                grades = controller.CarregarGrades();
                dataGridEntidades.ItemsSource = grades;

                //grades = controller.CarregarGrades();
                //dataGridEntidades.DataContext = grades;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            if (status.Status == StatusView.StatusValues.Nenhum || status.Status == StatusView.StatusValues.Navegando)
            {
                HabilitarComponentes(true);
                btnAdicionarItem.IsEnabled = false;
                status.Status = StatusView.StatusValues.Adicionando;
                grade = new Grade();
                gridDados.DataContext = grade;
                txtNome.Focus();

            }

            else if (status.Status == StatusView.StatusValues.Adicionando)
            {
                try
                {
                    controller.AdicionarGrade(grade);
                    status.Status = StatusView.StatusValues.Navegando;
                    gridDados.DataContext = grade;
                    CarregarGridGrade();
                    HabilitarComponentes(false);
                    btnAdicionarItem.IsEnabled = false;
                    MessageBox.Show("Grade " + grade.Nome + " cadastrada com sucesso!");
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
                    controller.AtualizarGrade(grade);
                    status.Status = StatusView.StatusValues.Navegando;
                    gridDados.DataContext = grade;
                    HabilitarComponentes(false);
                    btnAdicionarItem.IsEnabled = false;
                }

                catch (Exception ex)
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
                HabilitarComponentes(true);
                btnAdicionarItem.IsEnabled = true;
            }

            else if (status.Status == StatusView.StatusValues.Adicionando)
            {
                grade = null;
                //gridDadosProduto.DataContext = produto;

                status.Status = StatusView.StatusValues.Nenhum;
                HabilitarComponentes(false);
                btnAdicionarItem.IsEnabled = false;
            }

            else if (status.Status == StatusView.StatusValues.Editando)
            {
                status.Status = StatusView.StatusValues.Navegando;
                HabilitarComponentes(false);
                btnAdicionarItem.IsEnabled = false;
            }

            ControlaCRUDButtons.Controlar(this, status, buttons);
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (grade == null)
            {
                MessageBox.Show("Não existe produto selecionado para exclusão");
            }

            else
            {
                if (MessageBox.Show("Tem certeza que deseja excluir a grade " + grade.Nome + " ?", "Exclusão de Registro", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        controller.RemoverGrade(grade);

                        //Código para limpar componentes WPF

                        grade = new Grade(); //Talvez essa instanciação seja desnecessária.
                        gridDados.DataContext = grade;
                        Utils.LimparComponentesDaView.Limpar(this);
                        //txtCodigo.Text = "";

                        CarregarGridGrade();

                        if (dataGridEntidades.Items.Count > 0)
                        {
                             Grade item = (Grade)dataGridEntidades.Items[0];
                            dataGridEntidades.SelectedItem = item;
                            dataGridEntidades.ScrollIntoView(item);
                            DataGridRow row = (DataGridRow)dataGridEntidades.ItemContainerGenerator.ContainerFromIndex(dataGridEntidades.SelectedIndex);
                            row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                        }



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

            MessageBox.Show(status.Status.ToString());
            //Utils.LimparComponentesDaView.Limpar(this);
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {

            if (dataGridEntidades != null && dataGridEntidades.SelectedItems != null && dataGridEntidades.SelectedItems.Count == 1)
            //if(dataGridEntidade.SelectedItem != null)
            {

                DataGridRow dgr = dataGridEntidades.ItemContainerGenerator.ContainerFromItem(dataGridEntidades.SelectedItem) as DataGridRow;

                grade = (Grade)dgr.Item;
                CRUDGradeItensView.gradeId = grade.Id;
                CRUDGradeItensView viewGradeItens = new CRUDGradeItensView();
                viewGradeItens.Owner = this;
                viewGradeItens.Show();

            }

            else
            {
                MessageBox.Show("Você precisa selecionar uma Grade!", "Ação Inválida", MessageBoxButton.OK, MessageBoxImage.Warning);
                //A ordem a seguir é fundamental para não haver erro de carregamento do objeto Parceiro na View ClientesView
                //ClientesView.cliente = new Parceiro();
                //ClientesView.idParceiro = 0;
                //ClientesView clienteView = new ClientesView();
                //clienteView.Owner = this;
                //clienteView.Show();
            }



            /*
            if (grade != null)
            {
                CRUDGradeItensView viewItens = new CRUDGradeItensView();
                viewItens.Owner = this;
                viewItens.gradeId = grade.Id;
                viewItens.Show();
            }

            */
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            
            status.Status = StatusView.StatusValues.Nenhum;
            //statusBar.DataContext = status;
            btnAdicionarItem.IsEnabled = false;

            ControlaCRUDButtons.Controlar(this, status, buttons);

            
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
                            grade = (Grade)dgr.Item;
                            gridDados.DataContext = grade;
                            status.Status = StatusView.StatusValues.Navegando;
                            Utils.ControlaCRUDButtons.Controlar(this, status, buttons);
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
    }
}
