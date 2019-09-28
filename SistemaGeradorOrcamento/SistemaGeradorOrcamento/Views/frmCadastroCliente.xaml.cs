using SistemaGeradorOrcamento.DAL;
using SistemaGeradorOrcamento.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace SistemaGeradorOrcamento.Views
{
    /// <summary>
    /// Interaction logic for frmCadastroCliente.xaml
    /// </summary>
    public partial class frmCadastroCliente : Window
    {
        private List<dynamic> servicosGrid = new List<dynamic>();
        dynamic objetoSelecionadoDataGrid;

        public frmCadastroCliente()
        {
            InitializeComponent();
        }

        private void LimparFormulario()
        {
            txtNome.Clear();
            txtContato.Clear();
            txtTelefone.Clear();
               
            txtNome.Focus();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            txtContato.IsEnabled = true;
            txtNome.IsEnabled = true;
            txtTelefone.IsEnabled = true;
            btnCancelar.Visibility = Visibility.Visible;
            btnSalvar.Visibility = Visibility.Visible;
            btnCadastrar.IsEnabled = false;
            btnEditar.IsEnabled = false;
            btnBuscar.IsEnabled = false;

            txtNome.Focus();

        }   

        private void FrmCadatroCliente_Loaded(object sender, RoutedEventArgs e)
        {
            

            
        }

        
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            List<Cliente> c = ClienteDao.ListarClientes();
            dtaCliente.ItemsSource = c;
        }

              
        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNome != null || txtContato != null || txtTelefone != null)
            {
                Cliente c = new Cliente
                {
                    NomeCliente = txtNome.Text,
                    Contato = txtContato.Text,
                    Telefone = txtTelefone.Text
                };

                if (ClienteDao.CadastrarCliente(c))
                {
                    MessageBox.Show("Cliente Cadastrado!",
                        "Sistema de Orcamento", MessageBoxButton.OK, MessageBoxImage.Information);

                    LimparFormulario();
                    txtNome.IsEnabled = false;
                    txtContato.IsEnabled = false;
                    txtTelefone.IsEnabled = false;
                    btnCancelar.Visibility = Visibility.Hidden;
                    btnSalvar.Visibility = Visibility.Hidden;
                    btnBuscar.IsEnabled = true;
                    btnCadastrar.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Já Exite um Cliente com Este Nome",
                        "Sistema de Orcamento", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Por Favor Preencher todos os campos","Sistema de Orcamento",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
         
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimparFormulario();
            txtNome.IsEnabled = false;
            txtContato.IsEnabled = false;
            txtTelefone.IsEnabled = false;
            btnCancelar.Visibility = Visibility.Hidden;
            btnSalvar.Visibility = Visibility.Hidden;
            btnBuscar.IsEnabled = true;
            btnCadastrar.IsEnabled = true;
        }

        private void DtaCliente_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            objetoSelecionadoDataGrid = dtaCliente.SelectedValue;
            btnEditar.IsEnabled = true;
        }

        bool clickBotao = false;
        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente
            {
                NomeCliente = objetoSelecionadoDataGrid.NomeCliente
            };

            cliente = ClienteDao.BuscarClientePorNome(cliente);
            Cliente clienteCopia = cliente;


            if (clickBotao == false)
            {
                clickBotao = true;
                btnEditar.Content = "Salvar";
                btnEditar.IsEnabled = true;
                txtNome.Text = cliente.NomeCliente;
                txtContato.Text = cliente.Contato;
                txtTelefone.Text = cliente.Telefone;
                txtNome.IsEnabled = false;
                txtContato.IsEnabled = true;
                txtTelefone.IsEnabled = true;
                txtTelefone.Focus();
            }
            else
            {
                clickBotao = false;
                if (txtNome != null || txtContato != null || txtTelefone != null)
                {
                    Cliente c = new Cliente
                    {
                        NomeCliente = txtNome.Text,
                        Contato = txtContato.Text,
                        Telefone = txtTelefone.Text
                    };

                    if (ClienteDao.CadastrarCliente(c))
                    {
                        MessageBox.Show("Cliente Cadastrado!",
                            "Sistema de Orcamento", MessageBoxButton.OK, MessageBoxImage.Information);

                        LimparFormulario();
                        txtNome.IsEnabled = false;
                        txtContato.IsEnabled = false;
                        txtTelefone.IsEnabled = false;
                        btnCancelar.Visibility = Visibility.Hidden;
                        btnSalvar.Visibility = Visibility.Hidden;
                        btnBuscar.IsEnabled = true;
                        btnCadastrar.IsEnabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Já Exite um Cliente com Este Nome",
                            "Sistema de Orcamento", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por Favor Preencher todos os campos", "Sistema de Orcamento",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
           



        }
    }
}
