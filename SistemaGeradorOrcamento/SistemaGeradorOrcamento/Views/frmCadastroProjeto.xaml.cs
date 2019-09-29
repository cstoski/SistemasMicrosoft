using SistemaGeradorOrcamento.DAL;
using SistemaGeradorOrcamento.Models;
using System.Windows;
using System.Windows.Controls;

namespace SistemaGeradorOrcamento.Views
{
    /// <summary>
    /// Interaction logic for frmCadastroProjeto.xaml
    /// </summary>
    public partial class frmCadastroProjeto : Window
    {
        public frmCadastroProjeto()
        {
            InitializeComponent();
            txtNumero.Focus();
        }

        private void BtnEditarProjeto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FrmCadatroProjeto_Loaded(object sender, RoutedEventArgs e)
        {
            cboCliente.ItemsSource = ClienteDao.ListarClientes();
            cboCliente.DisplayMemberPath = "NomeCliente";
            cboCliente.SelectedValuePath = "ClienteId";
        }

        private void BtnNovo_Click(object sender, RoutedEventArgs e)
        {
            Projeto p = new Projeto
            {
                ProjetoId = 1
            };
            //Adicionar Numeração Automática
            cboStatus.SelectedIndex = 0;
            cboStatus.IsEnabled = false;
            txtNumero.IsEnabled = false;
            txtProjeto.IsEnabled = true;
            cboCliente.IsEnabled = true;
            btnSalvar.IsEnabled = true;
            txtProjeto.Focus();
            txtNumero.Text = ProjetoDao.GerarNumeroProjeto(p);
        }

        private void BtnBuscarOrcamento_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumero != null && cboStatus != null && txtProjeto != null && cboCliente != null)
            {
                ComboBoxItem ComboItem = (ComboBoxItem)cboStatus.SelectedItem;
                Projeto projeto = new Projeto
                {
                    NumeroProjeto = txtNumero.Text,
                    NomeProjeto = txtProjeto.Text,
                    Status = ComboItem.Content.ToString(),
                    Cliente = cboCliente.SelectedValue.ToString()
                };

                if (ProjetoDao.CadastrarProjeto(projeto))
                {
                    MessageBox.Show("Projeto Cadastrado!",
                        "Sistema Orcamento", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    //LimparFormulario();
                }
                else
                {
                    MessageBox.Show("Já Exite um Projeto com Este Número",
                        "Sistema Orcamento", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Por favor Preencha todos os campos!");
            }
        }
    }
}
