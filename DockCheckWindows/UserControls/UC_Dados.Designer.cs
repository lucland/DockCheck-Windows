namespace DockCheckWindows.UserControls
{
    partial class UC_Dados
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Dados));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonBaixar = new Guna.UI2.WinForms.Guna2Button();
            this.cadastrosDataGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ordenarLabel = new System.Windows.Forms.Label();
            this.comboBoxOrdenar = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.textBoxFiltrar = new System.Windows.Forms.TextBox();
            this.crescenteDecrescente = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.cadastrosDataGrid)).BeginInit();
            this.panel13.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBaixar
            // 
            this.buttonBaixar.BackColor = System.Drawing.Color.Transparent;
            this.buttonBaixar.BorderRadius = 3;
            this.buttonBaixar.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.buttonBaixar.CustomBorderThickness = new System.Windows.Forms.Padding(5);
            this.buttonBaixar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonBaixar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonBaixar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonBaixar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonBaixar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.buttonBaixar.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBaixar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.buttonBaixar.Image = ((System.Drawing.Image)(resources.GetObject("buttonBaixar.Image")));
            this.buttonBaixar.ImageSize = new System.Drawing.Size(30, 30);
            this.buttonBaixar.Location = new System.Drawing.Point(1423, 840);
            this.buttonBaixar.Name = "buttonBaixar";
            this.buttonBaixar.Size = new System.Drawing.Size(418, 63);
            this.buttonBaixar.TabIndex = 1;
            this.buttonBaixar.Text = "Baixar lista atual";
            this.buttonBaixar.Click += new System.EventHandler(this.buttonBaixar_Click);
            // 
            // cadastrosDataGrid
            // 
            this.cadastrosDataGrid.AllowUserToAddRows = false;
            this.cadastrosDataGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.cadastrosDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.cadastrosDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cadastrosDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cadastrosDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.cadastrosDataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.cadastrosDataGrid.Location = new System.Drawing.Point(89, 108);
            this.cadastrosDataGrid.Name = "cadastrosDataGrid";
            this.cadastrosDataGrid.ReadOnly = true;
            this.cadastrosDataGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cadastrosDataGrid.RowHeadersVisible = false;
            this.cadastrosDataGrid.Size = new System.Drawing.Size(1752, 709);
            this.cadastrosDataGrid.TabIndex = 2;
            this.cadastrosDataGrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.cadastrosDataGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.cadastrosDataGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.cadastrosDataGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.cadastrosDataGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.cadastrosDataGrid.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.cadastrosDataGrid.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.cadastrosDataGrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(59)))));
            this.cadastrosDataGrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.cadastrosDataGrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cadastrosDataGrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.cadastrosDataGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.cadastrosDataGrid.ThemeStyle.HeaderStyle.Height = 23;
            this.cadastrosDataGrid.ThemeStyle.ReadOnly = true;
            this.cadastrosDataGrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.cadastrosDataGrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.cadastrosDataGrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cadastrosDataGrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.cadastrosDataGrid.ThemeStyle.RowsStyle.Height = 22;
            this.cadastrosDataGrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.cadastrosDataGrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.cadastrosDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cadastrosDataGrid_CellContentClick);
            this.cadastrosDataGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cadastrosDataGrid_CellContentDoubleClick);
            this.cadastrosDataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cadastrosDataGrid_CellContentClick);
            // 
            // ordenarLabel
            // 
            this.ordenarLabel.AutoSize = true;
            this.ordenarLabel.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ordenarLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ordenarLabel.Location = new System.Drawing.Point(83, 51);
            this.ordenarLabel.Name = "ordenarLabel";
            this.ordenarLabel.Size = new System.Drawing.Size(194, 36);
            this.ordenarLabel.TabIndex = 3;
            this.ordenarLabel.Text = "Ordenar por:";
            // 
            // comboBoxOrdenar
            // 
            this.comboBoxOrdenar.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxOrdenar.BorderColor = System.Drawing.Color.White;
            this.comboBoxOrdenar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxOrdenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOrdenar.FocusedColor = System.Drawing.Color.White;
            this.comboBoxOrdenar.FocusedState.BorderColor = System.Drawing.Color.White;
            this.comboBoxOrdenar.Font = new System.Drawing.Font("Century Gothic", 18F);
            this.comboBoxOrdenar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBoxOrdenar.ItemHeight = 30;
            this.comboBoxOrdenar.Location = new System.Drawing.Point(283, 51);
            this.comboBoxOrdenar.MaxDropDownItems = 10;
            this.comboBoxOrdenar.Name = "comboBoxOrdenar";
            this.comboBoxOrdenar.Size = new System.Drawing.Size(429, 36);
            this.comboBoxOrdenar.TabIndex = 4;
            this.comboBoxOrdenar.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrdenar_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(795, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 36);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filtrar:";
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.White;
            this.panel13.Controls.Add(this.textBoxFiltrar);
            this.panel13.Location = new System.Drawing.Point(895, 51);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(429, 38);
            this.panel13.TabIndex = 6;
            // 
            // textBoxFiltrar
            // 
            this.textBoxFiltrar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFiltrar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxFiltrar.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFiltrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxFiltrar.Location = new System.Drawing.Point(5, 6);
            this.textBoxFiltrar.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxFiltrar.Name = "textBoxFiltrar";
            this.textBoxFiltrar.Size = new System.Drawing.Size(419, 30);
            this.textBoxFiltrar.TabIndex = 0;
            this.textBoxFiltrar.TextChanged += new System.EventHandler(this.textBoxFiltrar_TextChanged);
            // 
            // crescenteDecrescente
            // 
            this.crescenteDecrescente.BackColor = System.Drawing.Color.Transparent;
            this.crescenteDecrescente.BorderColor = System.Drawing.Color.White;
            this.crescenteDecrescente.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.crescenteDecrescente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.crescenteDecrescente.FocusedColor = System.Drawing.Color.White;
            this.crescenteDecrescente.FocusedState.BorderColor = System.Drawing.Color.White;
            this.crescenteDecrescente.Font = new System.Drawing.Font("Century Gothic", 18F);
            this.crescenteDecrescente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.crescenteDecrescente.ItemHeight = 30;
            this.crescenteDecrescente.Items.AddRange(new object[] {
            "CRESCENTE",
            "DECRESCENTE"});
            this.crescenteDecrescente.Location = new System.Drawing.Point(1412, 51);
            this.crescenteDecrescente.MaxDropDownItems = 10;
            this.crescenteDecrescente.Name = "crescenteDecrescente";
            this.crescenteDecrescente.Size = new System.Drawing.Size(429, 36);
            this.crescenteDecrescente.StartIndex = 1;
            this.crescenteDecrescente.TabIndex = 8;
            this.crescenteDecrescente.SelectedIndexChanged += new System.EventHandler(this.crescenteDecrescente_SelectedIndexChanged);
            // 
            // UC_Dados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.crescenteDecrescente);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxOrdenar);
            this.Controls.Add(this.ordenarLabel);
            this.Controls.Add(this.cadastrosDataGrid);
            this.Controls.Add(this.buttonBaixar);
            this.Name = "UC_Dados";
            this.Size = new System.Drawing.Size(1904, 906);
            ((System.ComponentModel.ISupportInitialize)(this.cadastrosDataGrid)).EndInit();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button buttonBaixar;
        private Guna.UI2.WinForms.Guna2DataGridView cadastrosDataGrid;
        private System.Windows.Forms.Label ordenarLabel;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxOrdenar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TextBox textBoxFiltrar;
        private Guna.UI2.WinForms.Guna2ComboBox crescenteDecrescente;
    }
}
