namespace DockCheckWindows.UserControls
{
    partial class UC_Etiqueta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Etiqueta));
            this.panelFundo = new System.Windows.Forms.Panel();
            this.labelEmpresa = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.labelIdentificacao = new System.Windows.Forms.TextBox();
            this.labelNome = new System.Windows.Forms.Label();
            this.labelEmbarcacao = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.excludeImageButton = new Guna.UI2.WinForms.Guna2Button();
            this.labelImprimir = new System.Windows.Forms.Label();
            this.panelFundo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFundo
            // 
            this.panelFundo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelFundo.BackColor = System.Drawing.Color.White;
            this.panelFundo.Controls.Add(this.labelEmpresa);
            this.panelFundo.Controls.Add(this.label4);
            this.panelFundo.Controls.Add(this.label1);
            this.panelFundo.Controls.Add(this.pictureBox9);
            this.panelFundo.Controls.Add(this.labelIdentificacao);
            this.panelFundo.Controls.Add(this.labelNome);
            this.panelFundo.Controls.Add(this.labelEmbarcacao);
            this.panelFundo.Controls.Add(this.panel10);
            this.panelFundo.Location = new System.Drawing.Point(29, 58);
            this.panelFundo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelFundo.MaximumSize = new System.Drawing.Size(533, 492);
            this.panelFundo.Name = "panelFundo";
            this.panelFundo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panelFundo.Size = new System.Drawing.Size(411, 266);
            this.panelFundo.TabIndex = 81;
            // 
            // labelEmpresa
            // 
            this.labelEmpresa.AutoSize = true;
            this.labelEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmpresa.Location = new System.Drawing.Point(47, 142);
            this.labelEmpresa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEmpresa.Name = "labelEmpresa";
            this.labelEmpresa.Size = new System.Drawing.Size(186, 25);
            this.labelEmpresa.TabIndex = 14;
            this.labelEmpresa.Text = "Empresa empresa";
            this.labelEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 167);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 36);
            this.label4.TabIndex = 13;
            this.label4.Text = "AB+";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "-----------------------------------------------------------";
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.InitialImage = null;
            this.pictureBox9.Location = new System.Drawing.Point(4, 14);
            this.pictureBox9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(40, 252);
            this.pictureBox9.TabIndex = 9;
            this.pictureBox9.TabStop = false;
            // 
            // labelIdentificacao
            // 
            this.labelIdentificacao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelIdentificacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIdentificacao.Location = new System.Drawing.Point(271, 7);
            this.labelIdentificacao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelIdentificacao.Name = "labelIdentificacao";
            this.labelIdentificacao.Size = new System.Drawing.Size(125, 57);
            this.labelIdentificacao.TabIndex = 7;
            this.labelIdentificacao.Text = "3333";
            this.labelIdentificacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.labelIdentificacao.TextChanged += new System.EventHandler(this.labelIdentificacao_TextChanged);
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome.Location = new System.Drawing.Point(47, 79);
            this.labelNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(304, 25);
            this.labelNome.TabIndex = 2;
            this.labelNome.Text = "Nome nome nome nome nome";
            this.labelNome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEmbarcacao
            // 
            this.labelEmbarcacao.AutoSize = true;
            this.labelEmbarcacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmbarcacao.Location = new System.Drawing.Point(47, 103);
            this.labelEmbarcacao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEmbarcacao.Name = "labelEmbarcacao";
            this.labelEmbarcacao.Size = new System.Drawing.Size(163, 25);
            this.labelEmbarcacao.TabIndex = 4;
            this.labelEmbarcacao.Text = "SKANDI RECIFE";
            this.labelEmbarcacao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel10.BackgroundImage")));
            this.panel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel10.Location = new System.Drawing.Point(52, 7);
            this.panel10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(99, 57);
            this.panel10.TabIndex = 3;
            // 
            // excludeImageButton
            // 
            this.excludeImageButton.BorderRadius = 15;
            this.excludeImageButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.excludeImageButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.excludeImageButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.excludeImageButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.excludeImageButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.excludeImageButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excludeImageButton.ForeColor = System.Drawing.Color.White;
            this.excludeImageButton.Location = new System.Drawing.Point(427, 6);
            this.excludeImageButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.excludeImageButton.Name = "excludeImageButton";
            this.excludeImageButton.Size = new System.Drawing.Size(37, 34);
            this.excludeImageButton.TabIndex = 82;
            this.excludeImageButton.Text = "x";
            this.excludeImageButton.TextOffset = new System.Drawing.Point(1, -2);
            this.excludeImageButton.Click += new System.EventHandler(this.excludeImageButton_Click);
            // 
            // labelImprimir
            // 
            this.labelImprimir.AutoSize = true;
            this.labelImprimir.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImprimir.ForeColor = System.Drawing.Color.White;
            this.labelImprimir.Location = new System.Drawing.Point(12, 12);
            this.labelImprimir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelImprimir.Name = "labelImprimir";
            this.labelImprimir.Size = new System.Drawing.Size(297, 28);
            this.labelImprimir.TabIndex = 83;
            this.labelImprimir.Text = "Impressão da etiqueta...";
            // 
            // UC_Etiqueta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.Controls.Add(this.labelImprimir);
            this.Controls.Add(this.excludeImageButton);
            this.Controls.Add(this.panelFundo);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UC_Etiqueta";
            this.Size = new System.Drawing.Size(471, 354);
            this.Load += new System.EventHandler(this.UC_Etiqueta_Load);
            this.panelFundo.ResumeLayout(false);
            this.panelFundo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelFundo;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.TextBox labelIdentificacao;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Label labelEmbarcacao;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button excludeImageButton;
        private System.Windows.Forms.Label labelImprimir;
        private System.Windows.Forms.Label labelEmpresa;
    }
}
