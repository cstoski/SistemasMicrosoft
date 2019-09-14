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
    /// Interaction logic for frmCadastroCliente.xaml
    /// </summary>
    public partial class frmCadastroCliente : Window
    {
        public frmCadastroCliente()
        {
            InitializeComponent();
        }

        private void LimparFormulario()
        {
            txtNome.Clear();
            txtContato.Clear();
            txtTelefone.Clear();
                       
            txtNome.Focus();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Cliente c = new Cliente
            {
                NomeCliente = txtNome.Text,
                Contato = txtNome.Text,
                Telefone = txtTelefone.Text
            };

            if (ClienteDao.CadastrarCliente(c))
            {
                MessageBox.Show("Cliente Cadastrado!",
                    "SistemaOrcamento", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("Já Exite um Cliente com Este Nome",
                    "SistemaOrcamento", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
