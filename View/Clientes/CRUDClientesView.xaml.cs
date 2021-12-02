using DinnamuS_2._0_Desktop.Controller;
using DinnamuS_2._0_Desktop.Model;
using DinnamuS_2._0_Desktop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DinnamuS_2._0_Desktop.View.Clientes
{
    /// <summary>
    /// Lógica interna para CRUDClientesView.xaml
    /// </summary>
    public partial class CRUDClientesView : Window
    {
        //public static int idParceiro = 0; //Criado apenas para parar de dar erro no código antigo (30/06/21)
        public static  int ClienteId = 0;
        public Cliente cliente;// = new Cliente(); // Precisa instanciar aqui ou pode ser no construtor?
        public PessoaEndereco Endereco; // = new PessoaEndereco();
        StatusView status;
        List<TipoDeDocumento> listaTipoDeDocumentos;



        ClienteController clienteController;

        public CRUDClientesView()
        {
            InitializeComponent();
            clienteController = new ClienteController();
            cliente = new Cliente();
            //status = new StatusView(); //Nao funcionou instanciar aqui neste ponto.
            Endereco = new PessoaEndereco();
            
        }



        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cliente = new Cliente();

                cliente.Nome = txtNome.Text;
                cliente.Doc = txtCpf.Text;
                cliente.TiposDeDocumentos = (TipoDeDocumento)cbDocs.SelectedItem;

                clienteController.SalvarCliente(cliente);

                MessageBox.Show("Cliente salvo com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }

        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            status = new StatusView();

            CarregaComboTiposDoc();

            if (ClienteId > 0)
            {
                clienteController = new ClienteController();

                cliente = clienteController.RetornaClienteById(ClienteId).First();

                gridDadosCliente.DataContext = cliente;

                cbDocs.SelectedItem = cliente.TiposDeDocumentos;

                status.Status = StatusView.StatusValues.Navegando;

                statusBar.DataContext = status;

            }

            


        }


        private void CarregaComboTiposDoc()
        {
           listaTipoDeDocumentos  = new List<TipoDeDocumento>();

            TiposDeDocumentosController controllerDocs = new TiposDeDocumentosController();

            listaTipoDeDocumentos = controllerDocs.RetornaTiposDocumentos();
            cbDocs.ItemsSource = listaTipoDeDocumentos;
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btTestar_Click(object sender, RoutedEventArgs e)
        {


            AplicaEstiloView estilizar = new AplicaEstiloView();

            //estilizar.ExibirControles(this);
            
            
            
            estilizar.Aplicar(this);
            /*
            try
            {
                MessageBox.Show("Dados do Cliente:" + cliente.ToString() + '\n' + "Endereço(s): " + '\n' +

                cliente.Enderecos[0].ToString()
                );
            }

            catch (Exception ex)
            {
                MessageBox.Show("Deu merda!!", "Testes", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            */
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
