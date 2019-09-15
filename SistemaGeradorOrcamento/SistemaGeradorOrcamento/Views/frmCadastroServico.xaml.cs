﻿using SistemaGeradorOrcamento.DAL;
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
    /// Interaction logic for frmCadastroServico.xaml
    /// </summary>
    public partial class frmCadastroServico : Window
    {
        public frmCadastroServico()
        {
            InitializeComponent();
        }

        private void LimparFormulario()
        {
            txtNome.Clear();
            txtDescricao.Clear();
            txtValor.Clear();

            txtNome.Focus();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Servico servico = new Servico
            {
                Nome = txtNome.Text,
                Descricao = txtDescricao.Text,
                Valor = Convert.ToDouble(txtValor.Text)
            };

            if (ServicoDao.CadastrarServico(servico))
            {
                MessageBox.Show("Serviço cadastrado com sucesso!",
                    "SistemaOrcamento", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("Esse Serviço já existe!",
                    "SistemaOrcamento", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

        }
    }
}
