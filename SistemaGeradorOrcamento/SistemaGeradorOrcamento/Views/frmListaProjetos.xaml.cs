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
    /// Interaction logic for frmListaProjetos.xaml
    /// </summary>
    public partial class frmListaProjetos : Window
    {
        public frmListaProjetos()
        {
            InitializeComponent();
        }

        private void DtaProjeto_Loaded(object sender, RoutedEventArgs e)
        {
            
            dtaProjeto.ItemsSource = ProjetoDao.ListarTodosProjetos();
            dtaProjeto.Items.Refresh();
            
            

        }
    }
}
