using Sistema.Entidades;
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

namespace Sistema.View
{
    public partial class FrmCadProdutos : Form
    {
        ProductEnt objTabela = new ProductEnt();

        public FrmCadProdutos()
        {
            InitializeComponent();
        }

        private string opc = "";

        private void listarGrid()
        {
            try
            {
                List<ProductEnt> lista = new List<ProductEnt>();
                lista = new ProductModel().Lista();
                grid.AutoGenerateColumns = false;
                grid.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro!" + ex, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }
        }

        private void FrmCadProdutos_Load(object sender, EventArgs e)
        {
            listarGrid();
        }

        private void HabilitarCampos()
        {
            txtNome.Enabled = true;
            txtDescricao.Enabled = true;
            txtPreco.Enabled = true;
        }

        private void DesaabilitarCampos()
        {
            txtNome.Enabled = false;
            txtDescricao.Enabled = false;
            txtPreco.Enabled = false;
        }

        private void LimparCampos()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtPreco.Text = "";

        }        

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
                        objTabela.Pro_name = txtNome.Text;
                        objTabela.Pro_description = txtDescricao.Text;
                        objTabela.Pro_price = Convert.ToDecimal(txtPreco.Text);

                        int x = ProductModel.Insert(objTabela);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Produto {0} inserido com sucesso!", txtNome.Text), "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Erro ao Inserir Produto");
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
                        objTabela.Pro_id = Convert.ToInt32(txtCodigo.Text);

                        int x = ProductModel.Delete(objTabela);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Produto {0} Excluido com sucesso!", txtNome.Text), "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Erro ao Excluir Produto");
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
                        objTabela.Pro_id = Convert.ToInt32(txtCodigo.Text);
                        objTabela.Pro_name = txtNome.Text;
                        objTabela.Pro_description = txtDescricao.Text;
                        objTabela.Pro_price = Convert.ToDecimal(txtPreco.Text);

                        int x = ProductModel.Update(objTabela);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Produto {0} Editado com sucesso!", txtNome.Text), "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Erro ao Editar Produto");
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
                        objTabela.Pro_name = txtBuscar.Text;
                        List<ProductEnt> lista = new List<ProductEnt>();
                        lista = new ProductModel().Search(objTabela);
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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            opc = "Novo";
            IniciarOpc();
            txtNome.Focus();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            opc = "Buscar";
            IniciarOpc();
            LimparCampos();
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtDescricao.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtPreco.Text = grid.CurrentRow.Cells[3].Value.ToString();
            HabilitarCampos();
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmOpc form = new FrmOpc();
            this.Hide();
            form.Show();
        }
    }
}
