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

            txtNome.Focus();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
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
                        "SistemaOrcamento", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            
        }
    }
}
