﻿using SistemaGeradorOrcamento.DAL;
using SistemaGeradorOrcamento.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SistemaGeradorOrcamento.Views
{
    /// <summary>
    /// Interaction logic for frmCadastroProjeto.xaml
    /// </summary>
    public partial class frmCadastroProjeto : Window
    {
        public frmCadastroProjeto()
        {
            InitializeComponent();
            txtNumero.Focus();
            txtNomeServico.IsEnabled = false;
            txtTipoServico.IsEnabled = false;
            txtPrecoServico.IsEnabled = false;
            btnBuscarServico.IsEnabled = false;
            txtQuantidadeServico.IsEnabled = false;
            btnAdicionarServico.IsEnabled = false;

            txtNomeMaterial.IsEnabled = false;
            txtCodigoMaterial.IsEnabled = false;
            txtPrecoMaterial.IsEnabled = false;
            txtQuantidadeMaterial.IsEnabled = false;
            txtDescricao.IsEnabled = false;
            txtfabricante.IsEnabled = false;
            btnBuscarMaterial.IsEnabled = false;
            btnAdicionarMaterial.IsEnabled = false;
        }

        double totalServico = 0;
        double totalGeralServico = 0;
        double totalImpostoServico = 0;
        double totalMaterial = 0;
        double totalGeralMaterial = 0;
        double totalImpostoMaterial = 0;
        

        Projeto projetoNovo = new Projeto();
        Orcamento orcamento = new Orcamento();
        List<ItensMaterial> listaItensMateriais = new List<ItensMaterial>();
        List<ItensServico> listaItensServicos = new List<ItensServico>();
        List<itensOrcamento> listaItensOrcamentos = new List<itensOrcamento>();

        private void LimparFormularioServico()
        {
            txtNomeServico.Clear();
            txtQuantidadeServico.Clear();
            txtTipoServico.Clear();
            txtPrecoServico.Clear();
        }

        private void LimparFormularioMaterial()
        {
            txtNomeMaterial.Clear();
            txtCodigoMaterial.Clear();
            txtPrecoMaterial.Clear();
            txtQuantidadeMaterial.Clear();
            txtDescricao.Clear();
            txtfabricante.Clear();
        }

        private void FrmCadatroProjeto_Loaded(object sender, RoutedEventArgs e)
        {
            cboCliente.ItemsSource = ClienteDao.ListarClientes();
            cboCliente.DisplayMemberPath = "NomeCliente";
            cboCliente.SelectedValuePath = "ClienteId";
        }

        private void BtnNovo_Click(object sender, RoutedEventArgs e)
        {
            //Adicionar Numeração Automática
            cboStatus.SelectedIndex = 0;
            cboStatus.IsEnabled = false;
            txtNumero.IsEnabled = false;
            txtProjeto.IsEnabled = true;
            cboCliente.IsEnabled = true;
            btnSalvar.IsEnabled = true;
            btnSalvar.Visibility = Visibility.Visible;
            btnCancelar.Visibility = Visibility.Visible;
            btnNovo.IsEnabled = false;
            txtProjeto.Focus();

            txtNomeServico.IsEnabled = true;
            btnBuscarServico.IsEnabled = true;
            txtQuantidadeServico.IsEnabled = true;
            btnAdicionarServico.IsEnabled = true;

            txtNomeMaterial.IsEnabled = false;
            txtCodigoMaterial.IsEnabled = true;
            
            txtCodigoMaterial.Focus();
            txtQuantidadeMaterial.IsEnabled = true;
            txtDescricao.IsEnabled = true;
            txtfabricante.IsEnabled = true;
            btnBuscarMaterial.IsEnabled = true;
            btnAdicionarMaterial.IsEnabled = true;

            txtNumero.Text = ProjetoDao.GerarNumeroProjeto(projetoNovo);
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumero.Text != null && cboStatus.Text != null && txtProjeto.Text != "" && cboCliente.Text !=null)
            {
                orcamento.servico = listaItensServicos;
                orcamento.material = listaItensMateriais;
                itensOrcamento io = new itensOrcamento
                {
                    orcamento = orcamento
                };
                listaItensOrcamentos.Add(io);

                int idCliente = Convert.ToInt32(cboCliente.SelectedValue);
                projetoNovo.NumeroProjeto = txtNumero.Text;
                projetoNovo.NomeProjeto = txtProjeto.Text.ToUpper();
                projetoNovo.Status = cboStatus.SelectedIndex.ToString();
                projetoNovo.Cliente = ClienteDao.BuscarClientePorId(idCliente);
                projetoNovo.listaOrcamento = listaItensOrcamentos;
                

                if (ProjetoDao.CadastrarProjeto(projetoNovo))
                {
                    MessageBox.Show("Projeto Cadastrado!",
                        "Sistema Orcamento", MessageBoxButton.OK,
                        MessageBoxImage.Information);

                    btnSalvar.Visibility = Visibility.Hidden;
                    btnCancelar.Visibility = Visibility.Hidden;
                    btnNovo.IsEnabled = true;
                    txtNumero.Text = "";
                    txtNumero.IsEnabled = true;
                    txtNumero.Focus();
                    txtProjeto.Text = "";
                    txtProjeto.IsEnabled = false;
                    cboStatus.SelectedIndex = -1;
                    cboStatus.IsEnabled = false;
                    cboCliente.SelectedIndex = -1;
                    cboCliente.IsEnabled = false;                    
                }
                else
                {
                    MessageBox.Show("Já Exite um Projeto com Este Número",
                        "Sistema Orcamento", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Por favor Preencha todos os campos!");
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtNumero.Text = "";
            txtNumero.IsEnabled = true;
            txtProjeto.Text = "";
            txtProjeto.IsEnabled = false;
            cboStatus.SelectedIndex = -1;
            cboStatus.IsEnabled = false;
            cboCliente.SelectedIndex = -1;
            cboCliente.IsEnabled = false;
                        
            btnSalvar.Visibility = Visibility.Hidden;
            btnCancelar.Visibility = Visibility.Hidden;
            btnNovo.IsEnabled = true;

            txtNomeServico.Text = "";
            txtNomeServico.IsEnabled = false;
            txtTipoServico.Text = "";
            txtTipoServico.IsEnabled = false;
            txtPrecoServico.Text = "";
            txtPrecoServico.IsEnabled = false;
            btnBuscarServico.IsEnabled = false;
            txtQuantidadeServico.Text = "";
            txtQuantidadeServico.IsEnabled = false;
            btnAdicionarServico.IsEnabled = false;

            txtNomeMaterial.IsEnabled = false;
            txtCodigoMaterial.IsEnabled = false;
            txtPrecoMaterial.IsEnabled = false;
            txtQuantidadeMaterial.IsEnabled = false;
            txtDescricao.IsEnabled = false;
            txtfabricante.IsEnabled = false;
            btnBuscarMaterial.IsEnabled = false;
            btnAdicionarMaterial.IsEnabled = false;

            txtNumero.Focus();
        }

        /// <summary>
        /// Função Para Buscar um serviço
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBuscarServico_Click(object sender, RoutedEventArgs e)
        {
            if (!txtNomeServico.Text.Equals(""))
            {
                Servico servico = new Servico
                {
                    Nome = txtNomeServico.Text
                };

                servico = ServicoDao.BuscarServicoPorNome(servico);

                if (servico != null)
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

        /// <summary>
        /// Função para Adicionar um serviço
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdicionarServico_Click(object sender, RoutedEventArgs e)
        {
            if (!txtNomeServico.Text.Equals("") && !txtPrecoServico.Text.Equals("")
                && !txtPrecoServico.Text.Equals("") && !txtQuantidadeServico.Text.Equals(""))
            {
                Servico servico = new Servico
                {
                    Nome = txtNomeServico.Text
                };

                servico = ServicoDao.BuscarServicoPorNome(servico);

                ItensServico listaServico = new ItensServico
                {
                    servico = servico,
                    quantidade = Convert.ToInt32(txtQuantidadeServico.Text),
                };

                listaItensServicos.Add(listaServico);

                dtaListaServicos.ItemsSource = listaItensServicos;
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
            else
            {
                MessageBox.Show("Por Favor Preencha todos os campos!",
                        "Cadastro de Serviço");
            }
        }

        private void BtnExcluirServico_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditarServico_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DtaListaServicos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void BtnEditarMaterial_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnExcluirMaterial_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdicionarMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (!txtNomeMaterial.Text.Equals("") && !txtCodigoMaterial.Text.Equals("")
               && !txtPrecoMaterial.Text.Equals("") && !txtQuantidadeMaterial.Text.Equals("") && !txtfabricante.Text.Equals(""))
            {
                Material material = new Material
                {
                    Codigo = txtCodigoMaterial.Text                    
                };

                material = MaterialDao.BuscarMaterialPorCodigo(material);

                ItensMaterial listaMaterial = new ItensMaterial
                {
                    material = material,
                    quantidade = Convert.ToInt32(txtQuantidadeMaterial.Text),
                };

                listaItensMateriais.Add(listaMaterial);

                dtaListaMateriais.ItemsSource = listaItensMateriais;
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
                        "Cadastro de Materiais");
            }
        }

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
                    txtDescricao.Text = material.Descricao;
                    txtPrecoMaterial.Text = material.Valor.ToString("C2");
                    txtfabricante.Text = material.Fabricante;
                    
                }
                else
                {
                    MessageBox.Show("Esse Material não está cadastrado!",
                        "Busca de Material");
                }

            }
            else
            {
                MessageBox.Show("Por Favor Preencha o campo Código do Material!",
                        "Busca de Material");
            }
        }
    }
}
