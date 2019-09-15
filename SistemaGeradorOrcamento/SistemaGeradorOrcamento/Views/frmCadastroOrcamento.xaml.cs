using SistemaGeradorOrcamento.DAL;
using SistemaGeradorOrcamento.Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SistemaGeradorOrcamento.Views
{
    /// <summary>
    /// Interaction logic for frmCadastroOrcamento.xaml
    /// </summary>
    public partial class frmCadastroOrcamento : Window
    {
        public frmCadastroOrcamento()
        {
            InitializeComponent();
        }

        private List<dynamic> servicosGrid = new List<dynamic>();
        double total = 0;
        double totalGeral = 0;
        double totalImposto = 0;

        private void LimparFormulario()
        {
            txtNomeServico.Clear();
            txtQuantidadeServico.Clear();
            txtTipoServico.Clear();
            txtPrecoServico.Clear();
        }

        
        private void BtnBuscarServico_Click(object sender, RoutedEventArgs e)
        {
            if (!txtNomeServico.Text.Equals(""))
            {
                Servico servico = new Servico
                {
                    Nome = txtNomeServico.Text
                };

                servico = ServicoDao.BuscarServicoPorNome(servico);

                if(servico != null)
                {
                    txtNomeServico.Text = servico.Nome;
                    txtTipoServico.Text = servico.Tipo;
                    txtPrecoServico.Text = servico.Valor.ToString("C2");
                }
                else
                {
                    MessageBox.Show("Esse Serviço não está cadastrado!",
                        "Busca de Serviço");
                }

            }
            else
            {
                MessageBox.Show("Por Favor Preencha o campo Nome do Serviço!",
                        "Busca de Serviço");
            } 
        }

        private void BtnAdicionarServico_Click(object sender, RoutedEventArgs e)
        {
           if(!txtNomeServico.Text.Equals("") && !txtPrecoServico.Text.Equals("") 
                && !txtPrecoServico.Text.Equals("") && !txtQuantidadeServico.Text.Equals(""))
            {
                Servico servico = new Servico
                {
                    Nome = txtNomeServico.Text
                };

                servico = ServicoDao.BuscarServicoPorNome(servico);

                dynamic d = new
                {
                    Nome = servico.Nome,
                    Tipo = servico.Tipo,
                    Quantidade = txtQuantidadeServico.Text,
                    Preco = servico.Valor.ToString("C2"),
                    Subtotal = (servico.Valor * Convert.ToInt32(txtQuantidadeServico.Text)).ToString("C2")
                };
                servicosGrid.Add(d);
                dtaListaServicos.ItemsSource = servicosGrid;
                dtaListaServicos.Items.Refresh();
                

                //Calculo Valor Total
                total += servico.Valor * Convert.ToInt32(txtQuantidadeServico.Text);
                txtTotalServico.Text = total.ToString("C2");

                //Calculo do Imposto
                totalImposto += (servico.Valor * Convert.ToInt32(txtQuantidadeServico.Text))*0.10;
                txtTotalImpostoServico.Text = totalImposto.ToString("C2");

                //Calculo Valor Total
                totalGeral = total + totalImposto;
                txtTotalGeralServico.Text = totalGeral.ToString("C2");

                LimparFormulario();
            }
            else
            {
                MessageBox.Show("Por Favor Preencha todos os campos!",
                        "Cadastro de Serviço");
            }
        }

        private void BtnBuscarMaterial_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdicionarMaterial_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
