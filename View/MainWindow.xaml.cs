using DinnamuS_2._0_Desktop.Controller;
using DinnamuS_2._0_Desktop.Data;
using DinnamuS_2._0_Desktop.Model;
using DinnamuS_2._0_Desktop.Utils;
using DinnamuS_2._0_Desktop.View;
using DinnamuS_2._0_Desktop.View.Clientes;
using DinnamuS_2._0_Desktop.View.Enderecos;
using DinnamuS_2._0_Desktop.View.Estoque;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging; 
using System.Windows.Navigation;
using System.Windows.Shapes; 

namespace DinnamuS_2._0_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Cliente cliente = new Cliente();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

            dataGridEntidades.Columns.Clear();
            dataGridEntidades.Items.Clear();
            List<Cliente> clientes = new List<Cliente>();
            List<Produto> produtos = new List<Produto>();
            ObservableCollection<Cliente> listaDeClientes = new ObservableCollection<Cliente>();
            ObservableCollection<Produto> listaDeProdutos = new ObservableCollection<Produto>();

            /*
             *Código para selecionar Id Social (Apenas exemplo)
             *
             parceiros = controler.RetornaParceirosById(Int32.Parse(termoBusca));
                                foreach (var p in parceiros)
                                {
                                    if (String.IsNullOrEmpty(p.CPF) && String.IsNullOrEmpty(p.CNPJ))
                                    {
                                        parceiro = p;
                                        parceiro.IdSocial = "";
                                        lista.Add(parceiro);
                                    }

                                    else if (String.IsNullOrEmpty(p.CPF))
                                    {
                                        parceiro = p;
                                        parceiro.IdSocial = parceiro.CNPJ;
                                        lista.Add(parceiro);
                                    }
                                    else
                                    {
                                        parceiro = p;
                                        parceiro.IdSocial = p.CPF;
                                        lista.Add(parceiro);
                                    }
                                } 
             */


            if (cbEntidades.SelectedIndex == -1)
            {
                MessageBox.Show("Você precisa selecionar um valor na lista", "Pesquisa", MessageBoxButton.OK, MessageBoxImage.Warning);

                cbEntidades.IsDropDownOpen = true;
            }

            else
            {
                ComboBoxItem item = (ComboBoxItem)cbEntidades.SelectedItem;
                string entidade = item.Content.ToString();

                string termoBusca = txtTermoBusca.Text;

                switch (entidade)
                {
                    case "Clientes":

                        ClienteController controler = new ClienteController();

                        if (rbCodigo.IsChecked == true)
                        {
                            int i = 0;
                            if (!int.TryParse(termoBusca, out i))
                            {
                                MessageBox.Show("O valor precisa ser numérico!", "Consulta " + entidade, MessageBoxButton.OK, MessageBoxImage.Warning);
                                return;
                            }

                            else
                            {
                                clientes = controler.RetornaClienteById(Int32.Parse(termoBusca));
                                foreach (var p in clientes)
                                {
                                    //p.IdSocial = controler.RetornaIdSocial(p.CPF);

                                    listaDeClientes.Add(p);
                                }
                            }

                        }

                        
                        else if (rbNome.IsChecked == true)
                        {
                            clientes = controler.RetornaParceirosPeloNome(termoBusca);

                            foreach (var p in clientes)
                            {
                                //p.IdSocial = controler.RetornaIdSocial(p.CPF);
                                listaDeClientes.Add(p);
                            }

                        }

                        else if (rbIdSocial.IsChecked == true)
                        {

                        }

                        else
                        {
                            //Condição para nada marcado!
                        }

                        
                        if (listaDeClientes.Count == 0)
                        {
                            cliente = new Cliente();
                            CRUDClientesView.ClienteId = 0;
                            
                            constroiDataGridClientes(new ObservableCollection<Cliente>());
                        }

                        else
                        {
                            constroiDataGridClientes(listaDeClientes);
                        }
                        

                        //constroiDataGridClientes(listaDeClientes);
                        break;

                    case "Produtos":

                        ProdutoController produtoControler = new ProdutoController();

                        if (rbCodigo.IsChecked == true)
                        {
                            int i = 0;
                            if (!int.TryParse(termoBusca, out i))
                            {
                                MessageBox.Show("O valor precisa ser numérico!", "Consulta " + entidade, MessageBoxButton.OK, MessageBoxImage.Warning);
                                return;
                            }

                            else
                            {
                                /*
                                produtos = produtoControler.retornaProdutosByCodigo(Int32.Parse(termoBusca));
                                foreach (var p in produtos)
                                {
                                    listaDeProdutos.Add(p);
                                }

                                */
                            }

                        }

                        else if (rbNome.IsChecked == true)
                        {
                            /*
                            produtos = produtoControler.retornaProdutoByNome(termoBusca);

                            foreach (var p in produtos)
                            {
                                listaDeProdutos.Add(p);
                            }
                            */

                        }

                        else if (rbIdSocial.IsChecked == true)
                        {
                            
                        }

                        else
                        {
                            //Condição para nada marcado!
                        }

                        constroiDataGridProdutos(listaDeProdutos);

                        break;

                    case "Fornecedores":
                        break;

                    default:
                        break;

                }
            }
        }

        
       
        public void constroiDataGridClientes(ObservableCollection<Cliente> lista)
        {

            dataGridEntidades.Items.Clear();

            dataGridEntidades.IsReadOnly = true;
            dataGridEntidades.ColumnHeaderHeight = 40;
            dataGridEntidades.RowHeight = 35;
            int left = Convert.ToInt16(dataGridEntidades.Margin.Left);
            int top = Convert.ToInt16(dataGridEntidades.Margin.Top);
            int right = Convert.ToInt16(dataGridEntidades.Margin.Right);
            int bottom = Convert.ToInt16(dataGridEntidades.Margin.Bottom);
            dataGridEntidades.Margin = new Thickness(left, top, 0, 5);
            dataGridEntidades.Margin = new Thickness(right, bottom, 0, 10);
            dataGridEntidades.CanUserResizeRows = false;
            dataGridEntidades.AutoGenerateColumns = false;
            dataGridEntidades.CanUserAddRows = false;
            dataGridEntidades.SelectionMode = DataGridSelectionMode.Single;
            dataGridEntidades.CanUserResizeColumns = false;

            DataGridTextColumn colunaCodigo = new DataGridTextColumn();
            colunaCodigo.Header = "Código";
            colunaCodigo.Binding = new Binding("Id");
            colunaCodigo.Width = 100;
            colunaCodigo.MaxWidth = 100;
            colunaCodigo.MinWidth = 100;
            dataGridEntidades.Columns.Add(colunaCodigo);

            DataGridTextColumn colunaNome = new DataGridTextColumn();
            colunaNome.MaxWidth = 300;
            colunaNome.MinWidth = 300;
            colunaNome.Header = "Nome/Descrição";
            colunaNome.Width = 300;
            colunaNome.Binding = new Binding("Nome");
            dataGridEntidades.Columns.Add(colunaNome);

            /*
            DataGridTextColumn colunaIdSocial = new DataGridTextColumn();
            colunaIdSocial.Header = "CPF/CNPJ";
            colunaIdSocial.MaxWidth = 150;
            colunaIdSocial.MinWidth = 150;
            colunaIdSocial.Width = 150;
            colunaIdSocial.Binding = new Binding("IdSocial");
            dataGridEntidades.Columns.Add(colunaIdSocial);
            */

            foreach (Cliente cliente in lista)
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("Id");
                dt.Columns.Add("Nome");
                //dt.Columns.Add("IdSocial");

                DataRow dr = dt.NewRow();
                
                dr["Id"] = cliente.Id;
                dr["Nome"] = cliente.Nome;
                //dr["IdSocial"] = cliente.IdSocial;

                dt.Rows.Add(dr);

                
                dataGridEntidades.Items.Add(dt);

                
            }

        }

        public void constroiDataGridProdutos(ObservableCollection<Produto> lista)
        {

            dataGridEntidades.Items.Clear();

            dataGridEntidades.IsReadOnly = true;
            dataGridEntidades.ColumnHeaderHeight = 40;
            dataGridEntidades.RowHeight = 35;
            int left = Convert.ToInt16(dataGridEntidades.Margin.Left);
            int top = Convert.ToInt16(dataGridEntidades.Margin.Top);
            int right = Convert.ToInt16(dataGridEntidades.Margin.Right);
            int bottom = Convert.ToInt16(dataGridEntidades.Margin.Bottom);
            dataGridEntidades.Margin = new Thickness(left, top, 0, 5);
            dataGridEntidades.Margin = new Thickness(right, bottom, 0, 10);
            dataGridEntidades.CanUserResizeRows = false;
            dataGridEntidades.AutoGenerateColumns = false;
            dataGridEntidades.CanUserAddRows = false;
            dataGridEntidades.SelectionMode = DataGridSelectionMode.Single;
            dataGridEntidades.CanUserResizeColumns = false;

            DataGridTextColumn colunaCodigo = new DataGridTextColumn();
            colunaCodigo.Header = "Código";
            colunaCodigo.Binding = new Binding("Id");
            colunaCodigo.Width = 100;
            colunaCodigo.MaxWidth = 100;
            colunaCodigo.MinWidth = 100;
            dataGridEntidades.Columns.Add(colunaCodigo);

            DataGridTextColumn colunaNome = new DataGridTextColumn();
            colunaNome.MaxWidth = 300;
            colunaNome.MinWidth = 300;
            colunaNome.Header = "Nome/Descrição";
            colunaNome.Width = 300;
            colunaNome.Binding = new Binding("Nome");
            dataGridEntidades.Columns.Add(colunaNome);

            DataGridTextColumn colunaNCM = new DataGridTextColumn();
            colunaNCM.Header = "NCM";
            colunaNCM.MaxWidth = 150;
            colunaNCM.MinWidth = 150;
            colunaNCM.Width = 150;
            colunaNCM.Binding = new Binding("NCM");
            dataGridEntidades.Columns.Add(colunaNCM);

            foreach (Produto produto in lista)
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("Id");
                dt.Columns.Add("Nome");
                dt.Columns.Add("NCM");

                DataRow dr = dt.NewRow();
                dr["Id"] = produto.Id;
                dr["Nome"] = produto.Nome;
                //dr["NCM"] = produto.NCM;

                dt.Rows.Add(dr);

                dataGridEntidades.Items.Add(dt);


            }

        }

        private void btnTestes_Click(object sender, RoutedEventArgs e)
        {
            TestesView view = new TestesView();            
            view.Show();

            /*
            long cpf = Convert.ToInt64(txtTermoBusca.Text);
            string testes = string.Format("{0:000\\.000\\.000-00}", cpf);

            MessageBox.Show(testes);

            */
        }

        private void dataGridEntidades_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {

                if (sender != null)
                {
                    if (sender != null)
                    {
                        
                    
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocorreram erros ao carregar os dados do cliente \n" + ex.Message, "Consulta de Clientes", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void mnItemCriteriosBusca_Click(object sender, RoutedEventArgs e)
        {
            Window w = new CriteriosDeBuscaView();
            w.Show();
        }

        private void mnItemClientes_Click(object sender, RoutedEventArgs e)
        {
            Window w = new CRUDClientesView();

            w.Show();
        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridEntidades != null && dataGridEntidades.SelectedItems != null && dataGridEntidades.SelectedItems.Count == 1)
            //if(dataGridEntidade.SelectedItem != null)
            {

                DataGridRow dgr = dataGridEntidades.ItemContainerGenerator.ContainerFromItem(dataGridEntidades.SelectedItem) as DataGridRow;

                DataTable dt = (DataTable)dgr.Item;

                DataRow dr = dt.Rows[0];

                //MessageBox.Show(dr[1].ToString());

                CRUDClientesView.ClienteId =  Convert.ToInt32( dr[0].ToString());
                CRUDClientesView viewCliente = new CRUDClientesView();
                viewCliente.Owner = this;
                viewCliente.Show();

            }

            else
            {

                //A ordem a seguir é fundamental para não haver erro de carregamento do objeto Parceiro na View ClientesView
                //ClientesView.cliente = new Parceiro();
                CRUDClientesView.ClienteId = 0;
                CRUDClientesView clienteView = new CRUDClientesView();
                clienteView.Owner = this;
                clienteView.Show();
            }
        }

        private void mnItemTiposDeContatos_Click(object sender, RoutedEventArgs e)
        {
            View.TiposDeContatos tiposDeContatos = new TiposDeContatos();

            tiposDeContatos.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnItemTiposDeDocumentos_Click(object sender, RoutedEventArgs e)
        {
            View.TiposDeDocumentos vw = new TiposDeDocumentos();
            vw.Show();
        }

        private void dataGridEntidades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void mnItemMunicípios_Click(object sender, RoutedEventArgs e)
        {
            MunicipiosView view = new MunicipiosView();

            view.Show();
        }

        private void mnItemPaises_Click(object sender, RoutedEventArgs e)
        {
            PaisesView view = new PaisesView();

            view.Show();
        }

        private void mnItemProdutos_Click(object sender, RoutedEventArgs e)
        {
            CRUDProdutosView prod = new CRUDProdutosView();
            prod.Show();
        }

        private void mnItemGrades_Click(object sender, RoutedEventArgs e)
        {
            CRUDGradesView view = new CRUDGradesView();
            
            view.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {    
            
            if (MessageBox.Show("Confirma o fechamento de toda a aplicação?", "XOKR", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();

                }

                else
                {
                    e.Cancel = true;
                }
        }

        private void mnItemSair_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
            
            /*
            if (MessageBox.Show("Confirma o fechamento de toda a aplicação?", "XOKR", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                fechando = true; //gambiarra rules
                Application.Current.Shutdown();
            }
            */
        }

        private void mnItemSobre_Click(object sender, RoutedEventArgs e)
        {
            SobreView sobre = new SobreView();

            sobre.Show();
        }

        private void btnProdutos_Click(object sender, RoutedEventArgs e)
        {
            CRUDProdutosView prod = new CRUDProdutosView();
            prod.Show();
        }
    }
}
