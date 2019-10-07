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
    /// Interaction logic for frmVisualizarOrcamento.xaml
    /// </summary>
    public partial class frmVisualizarOrcamento : Window
    {
        public frmVisualizarOrcamento()
        {
            InitializeComponent();
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

                Orcamento orcamento = ProjetoDao.BuscaOrcamentoProjeto(projeto);

                if (projeto != null)
                {
                    txtProjeto.Text = projeto.NomeProjeto;

                    dtaListaServicos.ItemsSource = orcamento.servico;

                    dtaListaMateriais.ItemsSource = orcamento.material;

                    //double valorTotal = orcamento.servico.Sum();

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
    }
}
