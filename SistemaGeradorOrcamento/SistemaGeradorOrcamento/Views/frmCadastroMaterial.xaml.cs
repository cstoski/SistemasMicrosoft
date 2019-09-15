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
    /// Interaction logic for frmCadastroMaterial.xaml
    /// </summary>
    public partial class frmCadastroMaterial : Window
    {
        public frmCadastroMaterial()
        {
            InitializeComponent();
        }

        private void LimparFormulario()
        {
            txtNome.Clear();
            txtCodigo.Clear();
            txtDescricao.Clear();
            txtFabricante.Clear();
            txtValor.Clear();

            
            txtCodigo.Focus();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            txtCodigo.IsEnabled = true;
            txtNome.IsEnabled = true;
            txtDescricao.IsEnabled = true;
            txtFabricante.IsEnabled = true;
            txtValor.IsEnabled = true;
            btnSalvar.Visibility = Visibility.Visible;
            btnCadastrar.IsEnabled = false;
            btnEditar.IsEnabled = false;
            btnExcluir.IsEnabled = false;
            btnBuscar.IsEnabled = false;


        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if ((!txtCodigo.Text.Equals("")) && (!txtNome.Text.Equals("")) && (!txtFabricante.Text.Equals("")) && (!txtValor.Text.Equals("")))
            {
                Material material = new Material
                {
                    Codigo = txtCodigo.Text,
                    Nome = txtNome.Text,
                    Descricao = txtDescricao.Text,
                    Fabricante = txtFabricante.Text,
                    Valor = Convert.ToDouble(txtValor.Text)
                };

                if (MaterialDao.CadastrarMaterial(material))
                {
                    MessageBox.Show("Material cadastrado com sucesso!",
                        "SistemaOrcamento", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    LimparFormulario();
                }
                else
                {
                    MessageBox.Show("Esse Material já existe!",
                        "Sistema Orcamento", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                txtCodigo.IsEnabled = false;
                txtNome.IsEnabled = false;
                txtDescricao.IsEnabled = false;
                txtFabricante.IsEnabled = false;
                txtValor.IsEnabled = false;
                btnSalvar.Visibility = Visibility.Collapsed;
                btnCadastrar.IsEnabled = true;
                btnBuscar.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Por favor preencher todos os campos!",
                        "Sistema de Orçamento", MessageBoxButton.OK,
                        MessageBoxImage.Error);
            }
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
