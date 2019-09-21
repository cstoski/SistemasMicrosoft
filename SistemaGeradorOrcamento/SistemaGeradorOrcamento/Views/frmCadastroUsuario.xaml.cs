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
        Usuario u = new Usuario();

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

            if (txtNome.Text.Equals("") || txtEmail.Text.Equals("")
             || txtMatricula.Text.Equals("") || psbSenha1.Equals("") || psbSenha2.Equals(""))
            {
                MessageBox.Show("Preencha todos os campos", "SistemaOrçamento", MessageBoxButton.OK, MessageBoxImage.Error);
                LimparFormulario();
            }
            else
            {

                if (psbSenha1.Password.Equals(psbSenha2.Password.ToString().ToString()))
                {
                    u.Nome = txtNome.Text;
                    u.Matricula = txtMatricula.Text;
                    u.Departamento = txtDepartamento.Text;
                    u.Email = txtEmail.Text;
                    u.Senha = psbSenha1.Password.ToString();

                    if (UsuarioDao.BuscarUsuarioPorMatricula(u) != null)
                    {
                        MessageBox.Show("Usuario ja existe na base", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        LimparFormulario();
                    }
                    else
                    {
                        UsuarioDao.CadastrarUsuario(u);
                        LimparFormulario();
                        MessageBox.Show("Cadastro realizado com sucesso", "SistemOrçamento", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Senha não confere!", "SistemOrçamento", MessageBoxButton.OK, MessageBoxImage.Error);
                    psbSenha1.Clear();
                    psbSenha2.Clear();

                }
            }
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
       
            if (!txtMatricula.Text.Equals(""))
            {
                Usuario u = new Usuario
                {
                    Matricula = txtMatricula.Text
                };
                u = UsuarioDao.BuscarUsuarioPorMatricula(u);
                if (u != null)
                {
                    //VALIDAÇÃO DO BOTÃO YES PARA ALTERAR OS DADOS
                    if (MessageBox.Show("Usuário localizado! Deseja alterar os dados?",
                      "SistemaOrçamento", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes) 
                    {
                        txtNome.Text = u.Nome;
                        txtMatricula.Text = u.Matricula;
                        txtDepartamento.Text = u.Departamento;
                        txtEmail.Text = u.Email;
                        psbSenha1.Password = u.Senha;
                        psbSenha2.Password = u.Senha;

                        //HABILITAR O BOTÃO EDITAR
                        btnEditar.IsEnabled = true;                        
                    }
                    else
                    {
                        txtNome.Text = u.Nome;
                        txtMatricula.Text = u.Matricula;
                        txtDepartamento.Text = u.Departamento;
                        txtEmail.Text = u.Email;
                    }
                }
                else
                {
                    MessageBox.Show("Usuário não cadastrado ou inexistente!",
                        "SistemaOrçamento", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Para realizar a busca, digite a matricula!",
                      "SistemaOrçamento", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {

            Usuario u = new Usuario();
            u.Matricula = txtMatricula.Text;
            u = UsuarioDao.BuscarUsuarioPorMatricula(u);
            if (u != null)
            {
                UsuarioDao.DeletarUsuarios(u);
                MessageBox.Show("Usuário removido com sucesso!",
                        "SistemaOrçamento", MessageBoxButton.OK, MessageBoxImage.Information);
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("Usuário não cadastrado ou inexistente!",
                        "SistemaOrçamento", MessageBoxButton.OK, MessageBoxImage.Error);
                LimparFormulario();
            }
        }

        //SÓ SERÁ POSSÍVEL EDITAR APÓS SER REALIZADO A BUSCA PELA MATRICULA
        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {

            Usuario u = new Usuario();

            u.Matricula = txtMatricula.Text;
            u = UsuarioDao.BuscarUsuarioPorMatricula(u);

                u.Nome = txtNome.Text;
                u.Matricula = txtMatricula.Text;
                u.Departamento = txtDepartamento.Text;
                u.Email = txtEmail.Text;
                u.Senha = psbSenha1.Password.ToString();

            if (psbSenha1.Password.Equals(psbSenha2.Password.ToString().ToString()) && !psbSenha1.Password.Equals(""))
            {
                UsuarioDao.AlterarUsuario(u);

                MessageBox.Show("Dados alterados com sucesso!",
                      "SistemaOrçamento", MessageBoxButton.OK, MessageBoxImage.Information);
                btnEditar.IsEnabled = false;
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("Senha não confere!", "SistemOrçamento", MessageBoxButton.OK, MessageBoxImage.Error);
                psbSenha1.Clear();
                psbSenha2.Clear();

            }

        }

    }
}








