namespace TFS
{
    partial class frmMerge
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
            this.gridMerges = new System.Windows.Forms.DataGridView();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.IdChangeSetInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdChangeSetFim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mensagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conflitos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Finalizado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridMerges)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMerges
            // 
            this.gridMerges.AllowUserToAddRows = false;
            this.gridMerges.AllowUserToDeleteRows = false;
            this.gridMerges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMerges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMerges.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdChangeSetInicio,
            this.IdChangeSetFim,
            this.Mensagem,
            this.Conflitos,
            this.Finalizado});
            this.gridMerges.Location = new System.Drawing.Point(13, 13);
            this.gridMerges.Name = "gridMerges";
            this.gridMerges.Size = new System.Drawing.Size(750, 448);
            this.gridMerges.TabIndex = 0;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.Location = new System.Drawing.Point(606, 467);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 1;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Location = new System.Drawing.Point(687, 467);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 2;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // IdChangeSetInicio
            // 
            this.IdChangeSetInicio.DataPropertyName = "IdChangeSetInicio";
            this.IdChangeSetInicio.HeaderText = "ChangeSet Inicio";
            this.IdChangeSetInicio.Name = "IdChangeSetInicio";
            this.IdChangeSetInicio.ReadOnly = true;
            this.IdChangeSetInicio.Width = 120;
            // 
            // IdChangeSetFim
            // 
            this.IdChangeSetFim.DataPropertyName = "IdChangeSetFim";
            this.IdChangeSetFim.HeaderText = "ChangeSet Fim";
            this.IdChangeSetFim.Name = "IdChangeSetFim";
            this.IdChangeSetFim.ReadOnly = true;
            this.IdChangeSetFim.Width = 110;
            // 
            // Mensagem
            // 
            this.Mensagem.DataPropertyName = "Mensagem";
            this.Mensagem.HeaderText = "Mensagem";
            this.Mensagem.Name = "Mensagem";
            this.Mensagem.Width = 350;
            // 
            // Conflitos
            // 
            this.Conflitos.DataPropertyName = "Conflitos";
            this.Conflitos.HeaderText = "Conflitos";
            this.Conflitos.Name = "Conflitos";
            this.Conflitos.ReadOnly = true;
            this.Conflitos.Width = 60;
            // 
            // Finalizado
            // 
            this.Finalizado.DataPropertyName = "Finalizado";
            this.Finalizado.HeaderText = "Finalizado";
            this.Finalizado.Name = "Finalizado";
            this.Finalizado.ReadOnly = true;
            this.Finalizado.Width = 60;
            // 
            // frmMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 502);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.gridMerges);
            this.Name = "frmMerge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listagem de merges";
            ((System.ComponentModel.ISupportInitialize)(this.gridMerges)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridMerges;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdChangeSetInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdChangeSetFim;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mensagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conflitos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Finalizado;
    }
}