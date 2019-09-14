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
    /// Interaction logic for frmCadastroProjeto.xaml
    /// </summary>
    public partial class frmCadastroProjeto : Window
    {
        public frmCadastroProjeto()
        {
            InitializeComponent();
        }

        private void LimparFormulario()
        {
            txtProjeto.Clear();
            txtNumero.Clear();
            cmbCliente.Items.Clear();
            cmbStatus.Items.Clear();
            dgListaOrcamento.Items.Clear();
                        
            txtProjeto.Focus();
        }

        private void BtnAdicionarProjeto_Click(object sender, RoutedEventArgs e)
        {
            Projeto pj = new Projeto
            {
                NumeroProjeto = txtNumero.Text,
                NomeProjeto = txtProjeto.Text,
                Cliente = cmbCliente.Text,
                Status = "Emissao Inicial"                
            };
            if (ProjetoDao.CadastrarProjeto(pj))
            {
                MessageBox.Show("Projeto cadastrado com sucesso!",
                    "SistemaOrcamento", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("Esse Projeto já existe!",
                    "SistemaOrcamento", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
