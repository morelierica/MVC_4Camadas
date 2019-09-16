using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.View
{
    public partial class frmCadUsuario : Form
    {
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
