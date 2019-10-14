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
            txtNome.Focus();
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
                            MessageBox.Show(string.Format("Usuário {0} inserido com sucesso!", txtNome.Text), "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    try
                    {                        
                        objTabela.Id = Convert.ToInt32(txtCodigo.Text);

                        int x = UserModel.Delete(objTabela);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Usuário {0} Excluido com sucesso!", txtNome.Text), "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Erro ao Excluir Usuário");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu o seguinte erro ao Excluir " + ex.Message);
                    }
                    break;

                case "Editar":
                    try
                    {
                        objTabela.Id = Convert.ToInt32(txtCodigo.Text);
                        objTabela.Name = txtNome.Text;
                        objTabela.Login = txtUsuario.Text;
                        objTabela.Password = txtSenha.Text;

                        int x = UserModel.Update(objTabela);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Usuário {0} Editado com sucesso!", txtNome.Text), "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Erro ao Editar Usuário");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu o seguinte erro ao Editar " + ex.Message);
                    }
                    break;

                case "Buscar":
                    try
                    {
                        objTabela.Name = txtBuscar.Text;
                        List<UserEnt> lista = new List<UserEnt>();
                        lista = new UserModel().Search(objTabela);
                        grid.AutoGenerateColumns = false;
                        grid.DataSource = lista;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro!" + ex, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        throw;
                    }
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

        private void DesaabilitarCampos()
        {            
            txtNome.Enabled = false;
            txtUsuario.Enabled = false;
            txtSenha.Enabled = false;
        }

        private void LimparCampos()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtUsuario.Text = "";
            txtSenha.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            opc = "Salvar";
            IniciarOpc();
            listarGrid();
            LimparCampos();
            DesaabilitarCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Selecione um registro na tabela para Excluir", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            opc = "Excluir";
            IniciarOpc();
            listarGrid();
            DesaabilitarCampos();
            LimparCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Selecione um registro na tabela para Editar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            opc = "Editar";
            IniciarOpc();
            DesaabilitarCampos();
            LimparCampos();
            listarGrid();
        }

        private void listarGrid()
        {
            try
            {
                List<UserEnt> lista = new List<UserEnt>();
                lista = new UserModel().Lista();
                grid.AutoGenerateColumns = false;
                grid.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro!" + ex, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
                throw;
            }
        }

        private void frmCadUsuario_Load(object sender, EventArgs e)
        {
            listarGrid();
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtUsuario.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtSenha.Text = grid.CurrentRow.Cells[3].Value.ToString();
            HabilitarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            opc = "Buscar";
            IniciarOpc();            
            LimparCampos();            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                listarGrid();
                return;
            }

            opc = "Buscar";
            IniciarOpc();
            
        }
    }
}
