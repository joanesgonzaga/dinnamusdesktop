using DinnamuS_2._0_Desktop.Controller;
using DinnamuS_2._0_Desktop.Data;
using DinnamuS_2._0_Desktop.Model.Estoque;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Collections.ObjectModel;
using DinnamuS_2._0_Desktop.Utils;
using System.Windows.Controls;
using System.Windows.Media;

namespace DinnamuS_2._0_Desktop.View.Estoque
{
    /// <summary>
    /// Lógica interna para CRUDGradeItensView.xaml
    /// </summary>
    public partial class CRUDGradeItensView : Window
    {
        public static int gradeId;
        public GradeController gradeController = new GradeController();
        public GradeItemController controller;
        private Grade grade;
        private ObservableCollection<GradeItem> itensDaGrade;
        private GradeItem gradeItem;
        private StatusView status;
        private List<Button> buttons;
        private DataGridRow dgr;
        private List<GradeItem> itensRemover;
        private List<GradeItem> itensAdicionar;
        
        public CRUDGradeItensView()
        {
            InitializeComponent();

            dgr = new DataGridRow();

            controller = new GradeItemController();
            itensDaGrade = new ObservableCollection<GradeItem>();
            itensRemover = new List<GradeItem>();
            itensAdicionar = new List<GradeItem>();
            
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            if (status.Status == StatusView.StatusValues.Nenhum || status.Status == StatusView.StatusValues.Navegando)
            {
                status.Status = StatusView.StatusValues.Adicionando;
                
                HabilitarComponentes(true);
                //LimparComponentes();


                //Interrompe a seleção de itens durante o status Adicionando
                //dataGridEntidades.RemoveHandler(DataGrid.SelectionChangedEvent, (SelectionChangedEventHandler)dataGridEntidades_SelectionChanged);

                /*
                 * Desabilita qualquer interação com as linhas do DataGrid
                dataGridEntidades.IsHitTestVisible = false; 
                */

                //gradeItem = new GradeItem();

            }

            else if (status.Status == StatusView.StatusValues.Adicionando)
            {
                try
                {
                    //Neste momento os itens da grade já foram adicionados à list Grade.ItensDaGrade pelo evento Click do botao btnAdicionar
                    gradeController.AtualizarGrade(grade);

                    grade = gradeController.RetornaGradeComItens(gradeId);

                    dataGridEntidades.ItemsSource = grade.ItensDaGrade;
                    status.Status = StatusView.StatusValues.Navegando;
                    HabilitarComponentes(false);
                    LimparComponentes();


                    //dataGridEntidades.AddHandler(DataGrid.SelectionChangedEvent, (SelectionChangedEventHandler)dataGridEntidades_SelectionChanged);

                    MessageBox.Show("Iten(s) adicionado(s) com sucesso à grade " + grade.Nome, "Inserção de Registros", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    gradeController.AtualizarGrade(grade);
                    grade = gradeController.RetornaGradeComItens(gradeId);
                    dataGridEntidades.ItemsSource = grade.ItensDaGrade;
                    //dataGridEntidades.AddHandler(DataGrid.SelectionChangedEvent, (SelectionChangedEventHandler)dataGridEntidades_SelectionChanged);

                    status.Status = StatusView.StatusValues.Navegando;

                    LimparComponentes();
                    HabilitarComponentes(false);
                    btnAdicionar.IsEnabled = false;
                    btnRemover.IsEnabled = false;

                    MessageBox.Show("Iten(s) da grade alterados com sucesso!" + grade.Nome, "Inserção de Registros", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreram erros ao carregar os dados do município \n" + ex.Message, "Consulta de Municípios", MessageBoxButton.OK, MessageBoxImage.Error);
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
                /*
                 * Neste modo, os botões abaixo são desativados
                 */ 
                btnAdicionar.IsEnabled = false;
                btnRemover.IsEnabled = false;
                
            }

            else if(status.Status == StatusView.StatusValues.Adicionando)
            {
                status.Status = StatusView.StatusValues.Navegando;
                LimparComponentes();
                HabilitarComponentes(false);

                grade = gradeController.RetornaGradeComItens(gradeId);
                dataGridEntidades.ItemsSource = grade.ItensDaGrade;
                //dataGridEntidades.AddHandler(DataGrid.SelectionChangedEvent, (SelectionChangedEventHandler)dataGridEntidades_SelectionChanged);

            }

            else if (status.Status == StatusView.StatusValues.Editando)
            {
                status.Status = StatusView.StatusValues.Navegando;
                HabilitarComponentes(false);

                grade = gradeController.RetornaGradeComItens(gradeId);
                dataGridEntidades.ItemsSource = grade.ItensDaGrade;

                //dataGridEntidades.AddHandler(DataGrid.SelectionChangedEvent, (SelectionChangedEventHandler)dataGridEntidades_SelectionChanged);
            }

            ControlaCRUDButtons.Controlar(this, status, buttons);
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {

            if (gradeItem == null)
            {
                MessageBox.Show("Você precisa selecionar um item para exclusão!");
            }

            else
            {
                if(MessageBox.Show("Tem certeza que deseja excluir o item " + gradeItem.Variacao + " ?", "Exclusão de Registro", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    gradeController.RemoveItemDaGrade(grade, gradeItem);
                    
                    grade = gradeController.RetornaGradeComItens(gradeId);
                    dataGridEntidades.ItemsSource = grade.ItensDaGrade;
                }
            }




           //tracker;
            
            //dataGridEntidades.row

            if (gradeItem != null)
            {
                //Popula a lista de itens a 
                itensRemover.Add(gradeItem);
                
                //Formata a DataGridRow com backGroud Red sinalizando os registros a serem excluídos ao Gravar
                dgr.Background = Brushes.Red;
                //grade.ItensDaGrade.Remove(gradeItem);
            }
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            LimparComponentes();
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            buttons = new List<Button>();
            buttons.Add(btnNovo);
            buttons.Add(btnEditar);
            buttons.Add(btnExcluir);
            buttons.Add(btnLimpar);
            buttons.Add(btnSair);
            txtNome.IsEnabled = false;

            status = new StatusView();

            status.Status = StatusView.StatusValues.Navegando;
            grade = gradeController.RetornaGradeComItens(gradeId);
            gradeItem = new GradeItem();


            gridDados.DataContext = gradeItem;
            dataGridEntidades.ItemsSource = grade.ItensDaGrade;
            txtNome.DataContext = grade;

            statusBar.DataContext = status;
            HabilitarComponentes(false);
            Utils.ControlaCRUDButtons.Controlar(this, status, buttons);
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {

            foreach (GradeItem item in dataGridEntidades.Items)
            {
                if (item.Equals(gradeItem))
                {
                    MessageBox.Show("Você não pode adicionar mais de um item com o mesmo nome!", "Inserção de Registro", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    return;
                }
            }

            if (grade.ItensDaGrade.Contains(gradeItem))
            {
                MessageBox.Show("Este item já existe para essa grade!", "Inserção de Registro", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                
                return;
            }

            try
            {
                //throw new Exception();
                
                if (gradeItem != null)
                {
                    grade.ItensDaGrade.Add(gradeItem);
                    //itensAdicionar.Add(gradeItem);
                    gradeItem = new GradeItem();
                    gridDados.DataContext = gradeItem;
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show("Informe o erro ao suporte: \n" + ex.Message, "COMPORTAMENTO INESPERADO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
                        dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;

                        if (dgr != null)
                        {
                            gradeItem = (GradeItem)dgr.Item;
                            gridDados.DataContext = gradeItem;

                        }

                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocorreram erros ao carregar os dados do município \n" + ex.Message, "Consulta de Municípios", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void LimparComponentes()
        {
            gradeItem = new GradeItem();
            gridDados.DataContext = gradeItem;
        }

        private void HabilitarComponentes(bool booleano)
        {
            
            txtVariacao.IsEnabled = booleano;
            txtOrdem.IsEnabled = booleano;
            btnAdicionar.IsEnabled = booleano;
            btnRemover.IsEnabled = booleano;
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {

            if (gradeItem != null)
            {
                if (gradeItem.Id > 0)
                {
                    return;
                }
                
                //A remove abaixo não ocorre no banco, mas apenas na list do dataGrid
                grade.ItensDaGrade.Remove(gradeItem);
                gradeItem = new GradeItem();
                gridDados.DataContext = gradeItem;

               
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Utils.FecharView.Fechar(status, this, e);
        }
    }
}
