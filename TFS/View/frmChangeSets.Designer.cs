namespace TFS
{
    partial class frmChangeSets
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
            TFS.CheckBoxProperties checkBoxProperties1 = new TFS.CheckBoxProperties();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Selecionado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRecarregaChangesets = new System.Windows.Forms.Button();
            this.btnMarcaTodos = new System.Windows.Forms.Button();
            this.groupConfig = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBranchOrigem = new System.Windows.Forms.Label();
            this.tbCaminhoTfExe = new System.Windows.Forms.TextBox();
            this.tbBranchOrigem = new System.Windows.Forms.TextBox();
            this.tbBranchDestino = new System.Windows.Forms.TextBox();
            this.cbWorkspace = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCollection = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbUsuario = new TFS.CheckBoxComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(822, 576);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Mescla selecionados";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selecionado,
            this.Id,
            this.Data,
            this.CodigoUsuario,
            this.NomeUsuario,
            this.Comentario});
            this.dataGridView1.Location = new System.Drawing.Point(13, 161);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(954, 409);
            this.dataGridView1.TabIndex = 1;
            // 
            // Selecionado
            // 
            this.Selecionado.DataPropertyName = "Selecionado";
            this.Selecionado.HeaderText = "Sel";
            this.Selecionado.Name = "Selecionado";
            this.Selecionado.Width = 60;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Id.Width = 60;
            // 
            // Data
            // 
            this.Data.DataPropertyName = "Data";
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.Width = 130;
            // 
            // CodigoUsuario
            // 
            this.CodigoUsuario.DataPropertyName = "CodigoUsuario";
            this.CodigoUsuario.HeaderText = "Desenvolvedor";
            this.CodigoUsuario.Name = "CodigoUsuario";
            this.CodigoUsuario.Width = 130;
            // 
            // NomeUsuario
            // 
            this.NomeUsuario.DataPropertyName = "NomeUsuario";
            this.NomeUsuario.HeaderText = "Nome";
            this.NomeUsuario.Name = "NomeUsuario";
            this.NomeUsuario.Width = 250;
            // 
            // Comentario
            // 
            this.Comentario.DataPropertyName = "Comentario";
            this.Comentario.HeaderText = "Comentario";
            this.Comentario.Name = "Comentario";
            this.Comentario.Width = 250;
            // 
            // btnRecarregaChangesets
            // 
            this.btnRecarregaChangesets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecarregaChangesets.Location = new System.Drawing.Point(840, 134);
            this.btnRecarregaChangesets.Name = "btnRecarregaChangesets";
            this.btnRecarregaChangesets.Size = new System.Drawing.Size(127, 23);
            this.btnRecarregaChangesets.TabIndex = 4;
            this.btnRecarregaChangesets.Text = "Carrega changesets";
            this.btnRecarregaChangesets.UseVisualStyleBackColor = true;
            this.btnRecarregaChangesets.Click += new System.EventHandler(this.btnRecarregaChangesets_Click);
            // 
            // btnMarcaTodos
            // 
            this.btnMarcaTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMarcaTodos.Location = new System.Drawing.Point(13, 576);
            this.btnMarcaTodos.Name = "btnMarcaTodos";
            this.btnMarcaTodos.Size = new System.Drawing.Size(97, 23);
            this.btnMarcaTodos.TabIndex = 5;
            this.btnMarcaTodos.Text = "Marca Todos";
            this.btnMarcaTodos.UseVisualStyleBackColor = true;
            this.btnMarcaTodos.Click += new System.EventHandler(this.btnMarcaTodos_Click);
            // 
            // groupConfig
            // 
            this.groupConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupConfig.Controls.Add(this.label4);
            this.groupConfig.Controls.Add(this.label5);
            this.groupConfig.Controls.Add(this.lblBranchOrigem);
            this.groupConfig.Controls.Add(this.tbCaminhoTfExe);
            this.groupConfig.Controls.Add(this.tbBranchOrigem);
            this.groupConfig.Controls.Add(this.tbBranchDestino);
            this.groupConfig.Controls.Add(this.cbWorkspace);
            this.groupConfig.Controls.Add(this.label3);
            this.groupConfig.Controls.Add(this.tbCollection);
            this.groupConfig.Controls.Add(this.label2);
            this.groupConfig.Controls.Add(this.tbUsuario);
            this.groupConfig.Controls.Add(this.label1);
            this.groupConfig.Location = new System.Drawing.Point(13, 12);
            this.groupConfig.Name = "groupConfig";
            this.groupConfig.Size = new System.Drawing.Size(954, 116);
            this.groupConfig.TabIndex = 6;
            this.groupConfig.TabStop = false;
            this.groupConfig.Text = "Configurações";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(470, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Caminho tf.exe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(470, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Branch destino";
            // 
            // lblBranchOrigem
            // 
            this.lblBranchOrigem.AutoSize = true;
            this.lblBranchOrigem.Location = new System.Drawing.Point(470, 28);
            this.lblBranchOrigem.Name = "lblBranchOrigem";
            this.lblBranchOrigem.Size = new System.Drawing.Size(75, 13);
            this.lblBranchOrigem.TabIndex = 9;
            this.lblBranchOrigem.Text = "Branch origem";
            // 
            // tbCaminhoTfExe
            // 
            this.tbCaminhoTfExe.Location = new System.Drawing.Point(551, 78);
            this.tbCaminhoTfExe.Name = "tbCaminhoTfExe";
            this.tbCaminhoTfExe.Size = new System.Drawing.Size(377, 20);
            this.tbCaminhoTfExe.TabIndex = 8;
            this.tbCaminhoTfExe.Validated += new System.EventHandler(this.tbCaminhoTfExe_Validated);
            // 
            // tbBranchOrigem
            // 
            this.tbBranchOrigem.Location = new System.Drawing.Point(551, 25);
            this.tbBranchOrigem.Name = "tbBranchOrigem";
            this.tbBranchOrigem.Size = new System.Drawing.Size(377, 20);
            this.tbBranchOrigem.TabIndex = 7;
            this.tbBranchOrigem.Validated += new System.EventHandler(this.tbBranchOrigem_Validated);
            // 
            // tbBranchDestino
            // 
            this.tbBranchDestino.Location = new System.Drawing.Point(551, 51);
            this.tbBranchDestino.Name = "tbBranchDestino";
            this.tbBranchDestino.Size = new System.Drawing.Size(377, 20);
            this.tbBranchDestino.TabIndex = 6;
            this.tbBranchDestino.Validated += new System.EventHandler(this.tbBranchDestino_Validated);
            // 
            // cbWorkspace
            // 
            this.cbWorkspace.FormattingEnabled = true;
            this.cbWorkspace.Location = new System.Drawing.Point(78, 78);
            this.cbWorkspace.Name = "cbWorkspace";
            this.cbWorkspace.Size = new System.Drawing.Size(263, 21);
            this.cbWorkspace.TabIndex = 5;
            this.cbWorkspace.Validated += new System.EventHandler(this.cbWorkspace_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Workspace";
            // 
            // tbCollection
            // 
            this.tbCollection.Location = new System.Drawing.Point(78, 51);
            this.tbCollection.Name = "tbCollection";
            this.tbCollection.Size = new System.Drawing.Size(377, 20);
            this.tbCollection.TabIndex = 3;
            this.tbCollection.Validated += new System.EventHandler(this.tbCollection_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Collection";
            // 
            // tbUsuario
            // 
            this.tbUsuario.Location = new System.Drawing.Point(78, 25);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(160, 20);
            this.tbUsuario.TabIndex = 1;
            this.tbUsuario.Validated += new System.EventHandler(this.tbUsuario_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuário TFS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Filtro usuário";
            // 
            // cbUsuario
            // 
            this.cbUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbUsuario.CheckBoxProperties = checkBoxProperties1;
            this.cbUsuario.DisplayMemberSingleItem = "";
            this.cbUsuario.FormattingEnabled = true;
            this.cbUsuario.Location = new System.Drawing.Point(84, 135);
            this.cbUsuario.Name = "cbUsuario";
            this.cbUsuario.Size = new System.Drawing.Size(750, 21);
            this.cbUsuario.TabIndex = 2;
            this.cbUsuario.Leave += new System.EventHandler(this.cbUsuario_Leave);
            // 
            // frmChangeSets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 611);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupConfig);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnMarcaTodos);
            this.Controls.Add(this.btnRecarregaChangesets);
            this.Controls.Add(this.cbUsuario);
            this.Controls.Add(this.button1);
            this.Name = "frmChangeSets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tfs Merge Admin";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupConfig.ResumeLayout(false);
            this.groupConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private CheckBoxComboBox cbUsuario;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selecionado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comentario;
        private System.Windows.Forms.Button btnRecarregaChangesets;
        private System.Windows.Forms.Button btnMarcaTodos;
        private System.Windows.Forms.GroupBox groupConfig;
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCollection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbWorkspace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBranchOrigem;
        private System.Windows.Forms.TextBox tbCaminhoTfExe;
        private System.Windows.Forms.TextBox tbBranchOrigem;
        private System.Windows.Forms.TextBox tbBranchDestino;
        private System.Windows.Forms.Label label6;
    }
}

