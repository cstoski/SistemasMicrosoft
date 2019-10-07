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
            txtCodigo.IsEnabled = true;
            txtCodigo.Focus();
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
            //materiaisGrid.Add(material);
            //dtaMateriais.ItemsSource = materiaisGrid;
            //dtaMateriais.Items.Refresh();

        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if ((!txtCodigo.Text.Equals("")) && (!txtNome.Text.Equals("")) && (!txtFabricante.Text.Equals("")) && (!txtValor.Text.Equals("")))
            {
                Material material = new Material
                {
                    Codigo = txtCodigo.Text.ToUpper(),
                    Nome = txtNome.Text.ToUpper(),
                    Descricao = txtDescricao.Text.ToUpper(),
                    Fabricante = txtFabricante.Text.ToUpper(),
                    Valor = Convert.ToDouble(txtValor.Text)
                };

                if (MaterialDao.CadastrarMaterial(material))
                {
                    MessageBox.Show("Material cadastrado com sucesso!",
                        "SistemaOrcamento", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    LimparFormulario();

                    //materiaisGrid.Add(material);
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
            txtCodigo.IsEnabled = true;
            txtNome.IsEnabled = false;
            txtDescricao.IsEnabled = false;
            txtFabricante.IsEnabled = false;
            txtValor.IsEnabled = false;

            
            if (!txtCodigo.Text.Equals(""))
            {
                Material material = new Material
                {
                    Codigo = txtCodigo.Text,

                };
                

                material = MaterialDao.BuscarMaterialPorCodigo(material);
                
                if (material != null )
                {
                    btnCadastrar.IsEnabled = false;
                    txtNome.Text = material.Nome;
                    txtFabricante.Text = material.Fabricante;
                    txtCodigo.Text = material.Codigo;
                    txtDescricao.Text = material.Descricao;
                    txtValor.Text = material.Valor.ToString("C2");
                    btnEditar.IsEnabled = true;
                    btnExcluir.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Material não localizado!",
                            "Sistema de Orçamento", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Por favor Preencher o Código!",
                            "Sistema de Orçamento", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
           // dtaMateriais.ItemsSource = MaterialDao.ListarMaterial();
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

        bool clickEditar = false;
        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            Material material = new Material
            {
                Codigo = txtCodigo.Text,

            };

            material = MaterialDao.BuscarMaterialPorCodigo(material);

            if (clickEditar == false)
            {
                txtCodigo.IsEnabled = false;
                txtNome.IsEnabled = true;
                txtDescricao.IsEnabled = true;
                txtFabricante.IsEnabled = true;
                txtValor.IsEnabled = true;

                btnCadastrar.IsEnabled = false;
                btnEditar.IsEnabled = true;
                btnExcluir.IsEnabled = false;
                btnBuscar.IsEnabled = false;

                btnEditar.Content = "Salvar";
                clickEditar = true;
            }
            else
            {
                if ((!txtCodigo.Text.Equals("")) && (!txtNome.Text.Equals("")) && (!txtFabricante.Text.Equals("")) && (!txtValor.Text.Equals("")))
                {

                    material.Nome = txtNome.Text.ToUpper();
                    material.Descricao = txtDescricao.Text.ToUpper();
                    material.Fabricante = txtFabricante.Text.ToUpper();
                    material.Valor = Convert.ToDouble(txtValor.Text.Replace("R$", ""));
                    
                    MaterialDao.EditarMaterial(material);
                    
                        MessageBox.Show("Material Alterado com sucesso!",
                            "SistemaOrcamento", MessageBoxButton.OK,
                            MessageBoxImage.Information);
                        LimparFormulario();

                        //materiaisGrid.Add(material);
                        dtaMateriais.ItemsSource = MaterialDao.ListarMaterial();
                        dtaMateriais.Items.Refresh();
                    
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
            
        }
    }
}
