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
    /// Interaction logic for frmCadastroServico.xaml
    /// </summary>
    public partial class frmCadastroServico : Window
    {
        private List<dynamic> servicosGrid =
            new List<dynamic>();
        dynamic objetoSelecionadoDataGrid;
        bool clickBotao = false;

        public frmCadastroServico()
        {
            InitializeComponent();
        }

        private void LimparFormulario()
        {
            txtNome.Clear();
            txtDescricao.Clear();
            txtValor.Clear();
            cmbTipoServico.Items.Clear();

            txtNome.Focus();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            txtNome.IsEnabled = true;
            txtDescricao.IsEnabled = true;
            txtValor.IsEnabled = true;
            cmbTipoServico.IsEnabled = true;
            btnCancelar.Visibility = Visibility;
            btnSalvar.Visibility = Visibility;
            btnBuscar.IsEnabled = false;
            btnCadastrar.IsEnabled = false;
            txtNome.Focus();

        }

        private void FrmCadastroServico1_Loaded(object sender, RoutedEventArgs e)
        {
            //List<Servico> s = ServicoDao.ListarServicos();
            //dtaServicos.ItemsSource = s;
         
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNome.Equals("") || txtValor.Equals("") || cmbTipoServico.Text.Equals(""))
            {
                MessageBox.Show("Por Favor Preencha todos os campos!",
                    "Sistema Orcamento", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                Servico servico = new Servico
                {
                    Nome = txtNome.Text.ToUpper(),
                    Descricao = txtDescricao.Text.ToUpper(),
                    Valor = Convert.ToDouble(txtValor.Text),
                    Tipo = cmbTipoServico.Text
                };

                if (ServicoDao.CadastrarServico(servico))
                {
                    MessageBox.Show("Serviço cadastrado com sucesso!",
                        "Sistema Orcamento", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    LimparFormulario();
                    txtNome.IsEnabled = false;
                    txtDescricao.IsEnabled = false;
                    txtValor.IsEnabled = false;
                    cmbTipoServico.IsEnabled = false;
                    btnCancelar.Visibility = Visibility.Hidden;
                    btnSalvar.Visibility = Visibility.Hidden;
                    btnBuscar.IsEnabled = true;
                    btnCadastrar.IsEnabled = true;

                }
                else
                {
                    MessageBox.Show("Esse Serviço já existe!",
                        "Sistema Orcamento", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
 
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimparFormulario();
            txtNome.IsEnabled = false;
            txtDescricao.IsEnabled = false;
            txtValor.IsEnabled = false;
            cmbTipoServico.IsEnabled = false;
            btnCancelar.Visibility = Visibility.Hidden;
            btnSalvar.Visibility = Visibility.Hidden;
            btnBuscar.IsEnabled = true;
            btnCadastrar.IsEnabled = true;
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            List<Servico> s = ServicoDao.ListarServicos();
            dtaServicos.ItemsSource = s;
        }

        private void DtaServicos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            objetoSelecionadoDataGrid = dtaServicos.SelectedValue;
            btnEditar.IsEnabled = true;
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            Servico servico = new Servico
            {
                Nome = objetoSelecionadoDataGrid.Nome
            };

            servico = ServicoDao.BuscarServicoPorNome(servico);


            if (clickBotao == false)
            {
                btnCancelar.Visibility = Visibility.Visible;
                clickBotao = true;
                btnEditar.Content = "Salvar";
                btnEditar.IsEnabled = true;
                btnBuscar.IsEnabled = false;
                btnCadastrar.IsEnabled = false;
                cmbTipoServico.IsEnabled = true;
                txtNome.Text = servico.Nome;
                txtDescricao.Text = servico.Descricao;
                txtValor.Text = Convert.ToInt32(servico.Valor).ToString("C2");
                cmbTipoServico.Text = servico.Tipo;
                txtNome.IsEnabled = false;
                txtDescricao.IsEnabled = true;
                txtValor.IsEnabled = true;
                txtNome.Focus();
            }
            else
            {

                if (txtNome != null || txtDescricao != null || txtValor != null)
                {
                    servico.Descricao = txtDescricao.Text.ToUpper();
                    servico.Tipo = cmbTipoServico.Text;
                    servico.Valor = Convert.ToDouble(txtValor.Text.Replace("R$",""));
                    servico.Tipo = cmbTipoServico.Text;

                    if (ServicoDao.AlterarServico(servico))
                    {
                        MessageBox.Show("Serviço Alterado!",
                            "Sistema de Orcamento", MessageBoxButton.OK, MessageBoxImage.Information);

                        LimparFormulario();
                        txtNome.IsEnabled = false;
                        txtDescricao.IsEnabled = false;
                        txtValor.IsEnabled = false;
                        btnCancelar.Visibility = Visibility.Hidden;
                        btnSalvar.Visibility = Visibility.Hidden;
                        btnBuscar.IsEnabled = true;
                        btnCadastrar.IsEnabled = true;
                        btnEditar.Content = "Editar";
                        btnEditar.IsEnabled = false;

                        dtaServicos.Items.Refresh();

                    }
                    else
                    {
                        MessageBox.Show("Este Serviço não pode ser Alterado",
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
