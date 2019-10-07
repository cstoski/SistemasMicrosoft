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
        bool clickBotao = false;


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
                    NomeCliente = txtNome.Text.ToUpper(),
                    Contato = txtContato.Text.ToUpper(),
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
                    btnEditar.Content = "Editar";
                    clickBotao = false;
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
            btnEditar.Content = "Editar";
            clickBotao = false;
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

        
        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente
            {
                NomeCliente = objetoSelecionadoDataGrid.NomeCliente
            };
            
            cliente = ClienteDao.BuscarClientePorNome(cliente);
            

            if (clickBotao == false)
            {
                btnCancelar.Visibility = Visibility.Visible;
                clickBotao = true;
                btnEditar.Content = "Salvar";
                btnEditar.IsEnabled = true;
                btnBuscar.IsEnabled = false;
                btnCadastrar.IsEnabled = false;
                txtNome.Text = cliente.NomeCliente.ToUpper();
                txtContato.Text = cliente.Contato.ToUpper();
                txtTelefone.Text = cliente.Telefone;
                txtNome.IsEnabled = false;
                txtContato.IsEnabled = true;
                txtTelefone.IsEnabled = true;
                txtContato.Focus();
            }
            else
            {
                
                if (txtNome != null || txtContato != null || txtTelefone != null)
                {
                    cliente.Contato = txtContato.Text.ToUpper();
                    cliente.Telefone = txtTelefone.Text;

                    if (ClienteDao.AlterarCliente(cliente))
                    {
                        MessageBox.Show("Cadastro Alterado!",
                            "Sistema de Orcamento", MessageBoxButton.OK, MessageBoxImage.Information);

                        LimparFormulario();
                        txtNome.IsEnabled = false;
                        txtContato.IsEnabled = false;
                        txtTelefone.IsEnabled = false;
                        btnCancelar.Visibility = Visibility.Hidden;
                        btnSalvar.Visibility = Visibility.Hidden;
                        btnBuscar.IsEnabled = true;
                        btnCadastrar.IsEnabled = true;
                        btnEditar.Content = "Editar";
                        btnEditar.IsEnabled = false;

                        List<Cliente> c = ClienteDao.ListarClientes();
                        dtaCliente.ItemsSource = c;
                    }
                    else
                    {
                        MessageBox.Show("Este Cadastro não pode ser Alterado",
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
