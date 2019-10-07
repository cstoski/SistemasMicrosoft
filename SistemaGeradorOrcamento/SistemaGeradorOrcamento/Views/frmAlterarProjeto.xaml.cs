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
    /// Interaction logic for frmAlterarProjeto.xaml
    /// </summary>
    public partial class frmAlterarProjeto : Window
    {
        public frmAlterarProjeto()
        {
            InitializeComponent();

            cboCliente.ItemsSource = ClienteDao.ListarClientes();
            cboCliente.DisplayMemberPath = "NomeCliente";
            cboCliente.SelectedValuePath = "ClienteId";

            txtNumero.Focus();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (!txtNumero.Text.Equals(""))
            {
                Projeto projeto = new Projeto
                {
                    NumeroProjeto = txtNumero.Text
                };

                projeto = ProjetoDao.BuscarProjetoPorNumero(projeto);

                if (projeto != null)
                {
                    txtNumero.IsEnabled = false;
                    txtProjeto.IsEnabled = true;
                    btnEditar.IsEnabled = true;
                    btnCancelar.IsEnabled = true;
                    cboStatus.IsEnabled = true;
                    cboCliente.IsEnabled = true;

                    txtProjeto.Text = projeto.NomeProjeto;
                    cboStatus.SelectedIndex = Convert.ToInt32(projeto.Status);

                    int idCliente = projeto.Cliente.ClienteId;
                    Cliente cliente = ClienteDao.BuscarClientePorId(idCliente);

                    cboCliente.SelectedIndex = cliente.ClienteId;

                    btnBuscar.IsEnabled = false;
                   
                }
                else
                {
                    MessageBox.Show("Projeto Inexistente", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Insira o código do Projeto", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);                
            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (!txtNumero.Text.Equals("") && !txtProjeto.Text.Equals(""))
            {
                Projeto projeto = new Projeto
                {
                    NumeroProjeto = txtNumero.Text
                };

                projeto = ProjetoDao.BuscarProjetoPorNumero(projeto);

                if (projeto != null)
                {
                    projeto.NomeProjeto = txtProjeto.Text;
                    projeto.Status = cboStatus.SelectedIndex.ToString();

                    int idCliente = Convert.ToInt32(cboCliente.SelectedValue);
                    projeto.Cliente = ClienteDao.BuscarClientePorId(idCliente);

                    if(ProjetoDao.AlterarProjeto(projeto))
                    {
                        MessageBox.Show("Cadastro Alterado!",
                            "Sistema de Orcamento", MessageBoxButton.OK, MessageBoxImage.Information);

                        txtNumero.Text = "";
                        txtProjeto.Text = "";
                        cboCliente.SelectedIndex = -1;
                        cboStatus.SelectedIndex = -1;

                        txtNumero.IsEnabled = true;
                        txtProjeto.Focus();
                        txtProjeto.IsEnabled = false;
                        btnEditar.IsEnabled = false;
                        btnCancelar.IsEnabled = false;
                        cboStatus.IsEnabled = false;
                        cboCliente.IsEnabled = false;
                        btnBuscar.IsEnabled = true;

                    }
                    else
                    {
                        MessageBox.Show("Projeto Não pode ser alterado",
                        "Sistema Orcamento", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Projeto Inexistente", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Insira o código do Projeto", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtNumero.Text = "";
            txtProjeto.Text = "";
            cboCliente.SelectedIndex = -1;
            cboStatus.SelectedIndex = -1;

            txtNumero.IsEnabled = true;
            txtProjeto.Focus();
            txtProjeto.IsEnabled = false;
            btnEditar.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            cboStatus.IsEnabled = false;
            cboCliente.IsEnabled = false;
            btnBuscar.IsEnabled = true;
        }
    }
}
