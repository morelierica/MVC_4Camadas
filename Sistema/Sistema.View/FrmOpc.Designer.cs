namespace Sistema.View
{
    partial class FrmOpc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCadUsuarios = new System.Windows.Forms.Button();
            this.btnCadProdutos = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCadUsuarios
            // 
            this.btnCadUsuarios.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadUsuarios.Location = new System.Drawing.Point(42, 89);
            this.btnCadUsuarios.Name = "btnCadUsuarios";
            this.btnCadUsuarios.Size = new System.Drawing.Size(114, 46);
            this.btnCadUsuarios.TabIndex = 0;
            this.btnCadUsuarios.Text = "Cadastro de Usuários";
            this.btnCadUsuarios.UseVisualStyleBackColor = true;
            this.btnCadUsuarios.Click += new System.EventHandler(this.btnCadUsuarios_Click);
            // 
            // btnCadProdutos
            // 
            this.btnCadProdutos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadProdutos.Location = new System.Drawing.Point(185, 89);
            this.btnCadProdutos.Name = "btnCadProdutos";
            this.btnCadProdutos.Size = new System.Drawing.Size(114, 46);
            this.btnCadProdutos.TabIndex = 1;
            this.btnCadProdutos.Text = "Cadastro de Produtos";
            this.btnCadProdutos.UseVisualStyleBackColor = true;
            this.btnCadProdutos.Click += new System.EventHandler(this.btnCadProdutos_Click);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(334, 89);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(114, 46);
            this.btnSair.TabIndex = 2;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // FrmOpc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 237);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnCadProdutos);
            this.Controls.Add(this.btnCadUsuarios);
            this.MaximizeBox = false;
            this.Name = "FrmOpc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCadUsuarios;
        private System.Windows.Forms.Button btnCadProdutos;
        private System.Windows.Forms.Button btnSair;
    }
}