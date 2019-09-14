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
    /// Interaction logic for frmCadastroUsuario.xaml
    /// </summary>
    public partial class frmCadastroUsuario : Window
    {
        public frmCadastroUsuario()
        {
            InitializeComponent();
        }
        private void LimparFormulario()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtMatricula.Clear();
            txtDepartamento.Clear();
            psbSenha1.Clear();
            psbSenha2.Clear();

            txtNome.Focus();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Usuario user = new Usuario
            {
                Nome = txtNome.Text,
                Matricula = txtMatricula.Text,
                Departamento = txtDepartamento.Text,
                Email= txtEmail.Text,
                Senha = "1234"
               
            };

            if (UsuarioDao.CadastrarUsuario(user))
            {
                MessageBox.Show("Usuário Cadastrado!",
                    "SistemaOrcamento", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("Já Exite um Usuário com Este Nome",
                    "SistemaOrcamento", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
