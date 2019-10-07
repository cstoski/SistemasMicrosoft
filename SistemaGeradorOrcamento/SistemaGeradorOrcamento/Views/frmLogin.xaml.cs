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
    /// Interaction logic for frmLogin.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(!txtMatricula.Text.Equals("") && !pswSenha.Equals(""))
            {
                Usuario user = new Usuario
                {
                    Matricula = txtMatricula.Text,
                    Senha = pswSenha.Password
                };


              
            }
            else
            {
                MessageBox.Show("Por favor Preencher Matrícula e Senha",
                        "Sistema Orcamento", MessageBoxButton.OK,
                        MessageBoxImage.Error);
            }
        }
    }
}
