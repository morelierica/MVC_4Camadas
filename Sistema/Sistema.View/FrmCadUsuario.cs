using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Model;
using Sistema.Entidades;

namespace Sistema.View
{
    public partial class frmCadUsuario : Form    
    {
        UserEnt objTabela = new UserEnt();        

        public frmCadUsuario()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            opc = "Novo";
            IniciarOpc();            
        }

        private string opc = "";

        private void IniciarOpc()
        {
            switch (opc)
            {
                case "Novo":
                    HabilitarCampos();
                    LimparCampos();
                    break;

                case "Salvar":
                    try
                    {
                        objTabela.Name = txtNome.Text;
                        objTabela.Login = txtUsuario.Text;
                        objTabela.Password = txtSenha.Text;
                    
                        int x = UserModel.Insert(objTabela);

                        if (x > 0)
                        {
                            MessageBox.Show("Usuário {0} inserido com sucesso!", txtNome.Text);
                        }
                        else
                        {
                            MessageBox.Show("Erro ao Inserir Usuário");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu o seguinte erro ao Salvar " + ex.Message);                        
                    }
                    break;

                case "Excluir":
                    break;

                case "Editar":
                    break;

                default:
                    break;
            }

        }

        private void HabilitarCampos()
        {
            txtNome.Enabled = true;
            txtUsuario.Enabled = true;
            txtSenha.Enabled = true;
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtUsuario.Text = "";
            txtSenha.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            opc = "Salvar";
            IniciarOpc();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            opc = "Excluir";
            IniciarOpc();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            opc = "Editar";
            IniciarOpc();
        }
    }
}
