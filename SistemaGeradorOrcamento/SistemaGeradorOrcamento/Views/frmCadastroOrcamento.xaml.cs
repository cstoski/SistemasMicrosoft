using SistemaGeradorOrcamento.DAL;
using SistemaGeradorOrcamento.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;

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
        double totalServico = 0;
        double totalGeralServico = 0;
        double totalImpostoServico = 0;
        private List<dynamic> materialGrid = new List<dynamic>();
        double totalMaterial = 0;
        double totalGeralMaterial = 0;
        double totalImpostoMaterial = 0;
        dynamic objetoSelecaoServico;

        private void LimparFormularioServico()
        {
            txtNomeServico.Clear();
            txtQuantidadeServico.Clear();
            txtTipoServico.Clear();
            txtPrecoServico.Clear();
        }

        private void LimparFormularioMaterial()
        {
            txtCodigoMaterial.Clear();
            txtNomeMaterial.Clear();
            txtPrecoMaterial.Clear();
            txtQuantidadeMaterial.Clear();
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
                totalServico += servico.Valor * Convert.ToInt32(txtQuantidadeServico.Text);
                txtTotalServico.Text = totalServico.ToString("C2");

                //Calculo do Imposto
                totalImpostoServico += (servico.Valor * Convert.ToInt32(txtQuantidadeServico.Text))*0.10;
                txtTotalImpostoServico.Text = totalImpostoServico.ToString("C2");

                //Calculo Valor Total
                totalGeralServico = totalServico + totalImpostoServico;
                txtTotalGeralServico.Text = totalGeralServico.ToString("C2");

                LimparFormularioServico();
            }
            else
            {
                MessageBox.Show("Por Favor Preencha todos os campos!",
                        "Cadastro de Serviço");
            }
        }
        //Lógicas para os campos de Serviço
        private void BtnBuscarMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (!txtCodigoMaterial.Text.Equals(""))
            {
                Material material = new Material
                {
                    Codigo = txtCodigoMaterial.Text
                };

                material = MaterialDao.BuscarMaterialPorCodigo(material);

                if (material != null)
                {
                    txtNomeMaterial.Text = material.Nome;
                    txtPrecoMaterial.Text = material.Valor.ToString("C2");
                    
                }
                else
                {
                    MessageBox.Show("Esse Material não está cadastrado!",
                        "Busca de Material");
                }

            }
            else
            {
                MessageBox.Show("Por Favor Preencha o Código do Material!",
                        "Busca de Material");
            }

        }

        private void BtnAdicionarMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (!txtCodigoMaterial.Text.Equals("") && !txtNomeMaterial.Text.Equals("")
                && !txtPrecoMaterial.Text.Equals("") && !txtQuantidadeMaterial.Text.Equals(""))
            {
                Material material = new Material
                {
                    Codigo = txtCodigoMaterial.Text
                };

                material = MaterialDao.BuscarMaterialPorCodigo(material);

                dynamic d = new
                {
                    Codigo = material.Codigo,
                    Nome = material.Nome,
                    Fabricante = material.Fabricante,
                    Quantidade = txtQuantidadeMaterial.Text,
                    Preco = material.Valor.ToString("C2"),
                    Subtotal = (material.Valor * Convert.ToInt32(txtQuantidadeMaterial.Text)).ToString("C2")
                };
                materialGrid.Add(d);
                dtaListaMateriais.ItemsSource = materialGrid;
                dtaListaMateriais.Items.Refresh();


                //Calculo Valor Total
                totalMaterial += material.Valor * Convert.ToInt32(txtQuantidadeMaterial.Text);
                txtTotalMaterial.Text = totalMaterial.ToString("C2");

                //Calculo do Imposto
                totalImpostoMaterial += (material.Valor * Convert.ToInt32(txtQuantidadeMaterial.Text)) * 0.10;
                txtTotalImpostoMaterial.Text = totalImpostoMaterial.ToString("C2");

                //Calculo Valor Total
                totalGeralMaterial = totalMaterial + totalImpostoMaterial;
                txtTotalGeralMaterial.Text = totalGeralMaterial.ToString("C2");

                LimparFormularioMaterial();
            }
            else
            {
                MessageBox.Show("Por Favor Preencha todos os campos!",
                        "Cadastro de Material");
            }
        }

        private void BtnExcluirServico_Click(object sender, RoutedEventArgs e)
        {
            Servico servico = new Servico
            {
                Nome = objetoSelecaoServico.Nome
            };
            
            int quantidade = Convert.ToInt32(objetoSelecaoServico.Quantidade);
            servico = ServicoDao.BuscarServicoPorNome(servico);

            //Calculo Valor Total
            totalServico -= servico.Valor * quantidade;
            txtTotalServico.Text = totalServico.ToString("C2");

            //Calculo do Imposto
            totalImpostoServico -= (servico.Valor * quantidade) * 0.10;
            txtTotalImpostoServico.Text = totalImpostoServico.ToString("C2");

            //Calculo Valor Total
            totalGeralServico = totalServico + totalImpostoServico;
            txtTotalGeralServico.Text = totalGeralServico.ToString("C2");

            servicosGrid.Remove(objetoSelecaoServico);
            dtaListaServicos.Items.Refresh();
            btnExcluirServico.IsEnabled = false;
            btnEditarServico.IsEnabled = false;
        }

        private void DtaListaServicos_SelectedCellsChanged(object sender, System.Windows.Controls.SelectedCellsChangedEventArgs e)
        {
            objetoSelecaoServico = dtaListaServicos.SelectedValue;
             

            btnExcluirServico.IsEnabled = true;
            btnEditarServico.IsEnabled = true;
         
        }

        bool teste = false;
        private void BtnEditarServico_Click(object sender, RoutedEventArgs e)
        {
            Servico servico = new Servico
            {
                Nome = objetoSelecaoServico.Nome
            };

            int quantidade = Convert.ToInt32(objetoSelecaoServico.Quantidade);
            servico = ServicoDao.BuscarServicoPorNome(servico);

            if (teste == false)
            {
                teste = true;
                btnEditarServico.Content = "Salvar";
                txtNomeServico.Text = servico.Nome;
                txtTipoServico.Text = servico.Tipo;
                txtPrecoServico.Text = servico.Valor.ToString("C2");
                txtQuantidadeServico.Text = quantidade.ToString();
                btnBuscarServico.IsEnabled = false;
                btnAdicionarServico.IsEnabled = false;
                txtNomeServico.IsEnabled = false;
                btnExcluirServico.IsEnabled = false;
            }
            else
            {
                teste = false;
                if(txtQuantidadeServico != null)
                {
                    servicosGrid.Remove(objetoSelecaoServico);
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
                    totalServico += servico.Valor * Convert.ToInt32(txtQuantidadeServico.Text);
                    txtTotalServico.Text = totalServico.ToString("C2");

                    //Calculo do Imposto
                    totalImpostoServico += (servico.Valor * Convert.ToInt32(txtQuantidadeServico.Text)) * 0.10;
                    txtTotalImpostoServico.Text = totalImpostoServico.ToString("C2");

                    //Calculo Valor Total
                    totalGeralServico = totalServico + totalImpostoServico;
                    txtTotalGeralServico.Text = totalGeralServico.ToString("C2");

                    LimparFormularioServico();

                }



                btnEditarServico.Content = "Editar";
            }
            
           
              
        }
    }
}
