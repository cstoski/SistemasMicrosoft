using SistemaGeradorOrcamento.DAL;
using SistemaGeradorOrcamento.Models;
using System;
using System.Collections.Generic;
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
            btnSalvar.Visibility = Visibility.Visible;
            btnCancelar.Visibility = Visibility.Visible;
            btnBuscarOrcamento.IsEnabled = false;
            btnNovo.IsEnabled = false;
            txtProjeto.Focus();
            txtNumero.Text = ProjetoDao.GerarNumeroProjeto(p);
        }

        private void BtnBuscarOrcamento_Click(object sender, RoutedEventArgs e)
        {
            //Se o valor da caixa de text for vazia lista todos os registros
            //Senão busca pelo Número Informado
           
            if (txtNumero.Text.Equals(""))
            {
                List<Projeto> projetos = ProjetoDao.ListarTodosProjetos();
                dtaProjetos.ItemsSource = projetos;
                dtaProjetos.IsEnabled = true;
            }
            else
            {
                Projeto p = new Projeto
                {
                    NumeroProjeto = txtNumero.Text
                };
                p = ProjetoDao.BuscarProjetoPorNumero(p);

                if (p != null)
                {
                    txtProjeto.Text = p.NomeProjeto;
                    cboStatus.SelectedIndex = Convert.ToInt32(p.Status);
                    cboCliente.SelectedIndex = Convert.ToInt32(p.Cliente);
                }
                else
                {
                    MessageBox.Show("Projeto Não Cadastrado",
                        "Cadastro de Orçamento");
                }

            }

        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumero.Text != null && cboStatus.Text != null && txtProjeto.Text != "" && cboCliente.Text !=null)
            {
                //ComboBoxItem ComboItem = (ComboBoxItem)cboStatus.SelectedItem;
                Projeto projeto = new Projeto
                {
                    NumeroProjeto = txtNumero.Text,
                    NomeProjeto = txtProjeto.Text,
                    Status = cboStatus.SelectedIndex.ToString(),
                    Cliente = cboCliente.SelectedValue.ToString()
                };

                if (ProjetoDao.CadastrarProjeto(projeto))
                {
                    MessageBox.Show("Projeto Cadastrado!",
                        "Sistema Orcamento", MessageBoxButton.OK,
                        MessageBoxImage.Information);

                    btnSalvar.Visibility = Visibility.Hidden;
                    btnCancelar.Visibility = Visibility.Hidden;
                    btnBuscarOrcamento.IsEnabled = true;
                    btnNovo.IsEnabled = true;
                    txtNumero.Text = "";
                    txtNumero.IsEnabled = true;
                    txtNumero.Focus();
                    txtProjeto.Text = "";
                    txtProjeto.IsEnabled = false;
                    cboStatus.SelectedIndex = -1;
                    cboStatus.IsEnabled = false;
                    cboCliente.SelectedIndex = -1;
                    cboCliente.IsEnabled = false;
                    
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

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtNumero.Text = "";
            txtNumero.IsEnabled = true;
            txtProjeto.Text = "";
            txtProjeto.IsEnabled = false;
            cboStatus.SelectedIndex = -1;
            cboStatus.IsEnabled = false;
            cboCliente.SelectedIndex = -1;
            cboCliente.IsEnabled = false;

            
            btnSalvar.Visibility = Visibility.Hidden;
            btnCancelar.Visibility = Visibility.Hidden;
            btnBuscarOrcamento.IsEnabled = true;
            btnNovo.IsEnabled = true;
            txtNumero.Focus();
        }
    }
}
