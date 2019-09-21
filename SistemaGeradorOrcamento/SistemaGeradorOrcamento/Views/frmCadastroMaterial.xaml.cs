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
    ///    

    public partial class frmCadastroMaterial : Window
    {

        private List<dynamic> materiaisGrid = new List<dynamic>();

        Material material = new Material();

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

            //ADICIONA OS DADOS CADASTRADOS NO DATAGRID
            materiaisGrid.Add(material);
            dtaMateriais.ItemsSource = materiaisGrid;
            dtaMateriais.Items.Refresh();

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
                    materiaisGrid.Add(material);
                    dtaMateriais.ItemsSource = MaterialDao.ListarMaterial();
                    dtaMateriais.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Esse material já existe!",
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
            MessageBox.Show("Digite o nome ou o fabricante!",
                          "Sistema de Orçamento", MessageBoxButton.OK,
                          MessageBoxImage.Information);

            txtCodigo.IsEnabled = true;
            txtNome.IsEnabled = true;
            txtDescricao.IsEnabled = true;
            txtFabricante.IsEnabled = true;
            txtValor.IsEnabled = true;
            
            if (!txtNome.Text.Equals("") || !txtFabricante.Text.Equals(""))
            {
                Material matNome = new Material
                {
                    Nome = txtNome.Text,

                };
                Material matFabricante = new Material
                {
                    Fabricante = txtFabricante.Text
                };

                matNome = MaterialDao.BuscarMaterialPorNome(matNome);
                matFabricante = MaterialDao.buscarMaterialPorFabricante(matFabricante);

                if (matNome != null )
                {
                    MessageBox.Show("Material localizado!",
                    "SistemaOrçamento", MessageBoxButton.OK, MessageBoxImage.Information);

                    txtNome.Text = matNome.Nome;
                    txtFabricante.Text = matNome.Fabricante;
                    txtCodigo.Text = matNome.Codigo;
                    txtDescricao.Text = matNome.Descricao;
                    txtValor.Text = matNome.Valor.ToString("C2");
                    btnEditar.IsEnabled = true;
                    btnExcluir.IsEnabled = true;
                }
                else
                {
                    if (matFabricante != null)
                    {
                        MessageBox.Show("Material localizado!",
                    "SistemaOrçamento", MessageBoxButton.OK, MessageBoxImage.Information);

                        txtNome.Text = matFabricante.Nome;
                        txtFabricante.Text = matFabricante.Fabricante;
                        txtCodigo.Text = matFabricante.Codigo;
                        btnEditar.IsEnabled = true;
                        btnExcluir.IsEnabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Material não localizado!",
                            "Sistema de Orçamento", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            dtaMateriais.ItemsSource = MaterialDao.ListarMaterial();
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
          
            material.Nome = txtNome.Text;
            material = MaterialDao.BuscarMaterialPorNome(material);
            if (material != null)
            {
                MaterialDao.DeletarMaterial(material);                
                MessageBox.Show("Material removido com sucesso!",
                        "SistemaOrçamento", MessageBoxButton.OK, MessageBoxImage.Information);
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("Material não cadastrado ou inexistente!",
                        "SistemaOrçamento", MessageBoxButton.OK, MessageBoxImage.Error);
                LimparFormulario();
            }
        }
    }
}
