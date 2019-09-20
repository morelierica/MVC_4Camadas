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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtUsuario.Text == "")
                {
                    MessageBox.Show("Preencha o campo Usuário", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                    return;
                }

                if (txtSenha.Text == "")
                {
                    MessageBox.Show("Preencha o campo Senha", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSenha.Focus();
                    return;
                }

                UserEnt obj = new UserEnt();
                obj.Login = txtUsuario.Text;
                obj.Password = txtSenha.Text;

                obj = new UserModel().Login(obj);

                if(obj.Login == null)
                {
                    lblMensagem.Text = "Usuário ou Senha não encontrado!";
                    lblMensagem.ForeColor = Color.Red;
                    return;
                }

                frmCadUsuario form = new frmCadUsuario();
                this.Hide();
                form.Show();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro!" + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }             
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
