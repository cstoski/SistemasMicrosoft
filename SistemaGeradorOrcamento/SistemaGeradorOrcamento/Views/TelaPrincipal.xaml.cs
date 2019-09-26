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
    /// Interaction logic for TelaPrincipal.xaml
    /// </summary>
    public partial class TelaPrincipal : Window
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroCliente frmCliente = new frmCadastroCliente();
            frmCliente.ShowDialog();
        }

        private void MenuItem_Click_Projetos(object sender, RoutedEventArgs e)
        {
            frmCadastroProjeto frmProjeto = new frmCadastroProjeto();
            frmProjeto.ShowDialog();
            //frmCadastroOrcamento frmOrcamento = new frmCadastroOrcamento();
            //frmOrcamento.ShowDialog();
        }

        private void MenuItem_Click_Usuarios(object sender, RoutedEventArgs e)
        {
            frmCadastroUsuario frmUsuario = new frmCadastroUsuario();
            frmUsuario.ShowDialog();
        }

        private void MenuItem_Click_Materiais(object sender, RoutedEventArgs e)
        {
            frmCadastroMaterial frmMaterial = new frmCadastroMaterial();
            frmMaterial.ShowDialog();
        }

        private void MenuItem_Click_Servicos(object sender, RoutedEventArgs e)
        {
            frmCadastroServico frmServico = new frmCadastroServico();
            frmServico.ShowDialog();
        }
    }
}
