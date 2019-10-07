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
    /// Interaction logic for frmListaDeUsuarios.xaml
    /// </summary>
    public partial class frmListaDeUsuarios : Window
    {
        public frmListaDeUsuarios()
        {
            InitializeComponent();
        }

        private void FrmListaDeUsuario1_Loaded(object sender, RoutedEventArgs e)
        {
            //List<Usuario> user = UsuarioDao.ListarUsuarios();
            //dynamic d = new
            //{
            //    Nome = user,
            //    CriadoEm = user.CriadoEm,
            //    Departamento = user.Departamento,
            //    Matricula = user.Matricula,
            //    Email = user.Email

            //};
            
            dtaListaUsusarios.ItemsSource = UsuarioDao.ListarUsuarios();
            dtaListaUsusarios.Items.Refresh();

        }
    }
}
