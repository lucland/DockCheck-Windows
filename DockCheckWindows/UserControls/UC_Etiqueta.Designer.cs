﻿namespace DockCheckWindows.UserControls
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.labelEmpresa = new System.Windows.Forms.TextBox();
            this.labelCheckOut = new System.Windows.Forms.Label();
            this.labelIdentificacao = new System.Windows.Forms.TextBox();
            this.labelNome = new System.Windows.Forms.Label();
            this.labelCheckIn = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.labelEmbarcacao = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelFundo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFundo
            // 
            this.panelFundo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelFundo.BackColor = System.Drawing.Color.White;
            this.panelFundo.Controls.Add(this.label4);
            this.panelFundo.Controls.Add(this.label2);
            this.panelFundo.Controls.Add(this.label3);
            this.panelFundo.Controls.Add(this.label1);
            this.panelFundo.Controls.Add(this.pictureBox9);
            this.panelFundo.Controls.Add(this.labelEmpresa);
            this.panelFundo.Controls.Add(this.labelCheckOut);
            this.panelFundo.Controls.Add(this.labelIdentificacao);
            this.panelFundo.Controls.Add(this.labelNome);
            this.panelFundo.Controls.Add(this.labelCheckIn);
            this.panelFundo.Controls.Add(this.label30);
            this.panelFundo.Controls.Add(this.labelEmbarcacao);
            this.panelFundo.Controls.Add(this.panel10);
            this.panelFundo.Location = new System.Drawing.Point(0, 0);
            this.panelFundo.MaximumSize = new System.Drawing.Size(400, 400);
            this.panelFundo.Name = "panelFundo";
            this.panelFundo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panelFundo.Size = new System.Drawing.Size(308, 216);
            this.panelFundo.TabIndex = 81;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "-----------------------------------------------------------";
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.InitialImage = null;
            this.pictureBox9.Location = new System.Drawing.Point(5, 12);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(30, 205);
            this.pictureBox9.TabIndex = 9;
            this.pictureBox9.TabStop = false;
            // 
            // labelEmpresa
            // 
            this.labelEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmpresa.Location = new System.Drawing.Point(39, 194);
            this.labelEmpresa.MaxLength = 20;
            this.labelEmpresa.Name = "labelEmpresa";
            this.labelEmpresa.Size = new System.Drawing.Size(263, 19);
            this.labelEmpresa.TabIndex = 8;
            this.labelEmpresa.Text = "EMPRESA";
            this.labelEmpresa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelCheckOut
            // 
            this.labelCheckOut.AutoSize = true;
            this.labelCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCheckOut.Location = new System.Drawing.Point(40, 155);
            this.labelCheckOut.Name = "labelCheckOut";
            this.labelCheckOut.Size = new System.Drawing.Size(97, 16);
            this.labelCheckOut.TabIndex = 5;
            this.labelCheckOut.Text = "Até: 00/00/0000";
            // 
            // labelIdentificacao
            // 
            this.labelIdentificacao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelIdentificacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIdentificacao.Location = new System.Drawing.Point(208, 6);
            this.labelIdentificacao.Name = "labelIdentificacao";
            this.labelIdentificacao.Size = new System.Drawing.Size(94, 46);
            this.labelIdentificacao.TabIndex = 7;
            this.labelIdentificacao.Text = "3333";
            this.labelIdentificacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.labelIdentificacao.Visible = false;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome.Location = new System.Drawing.Point(35, 68);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(251, 20);
            this.labelNome.TabIndex = 2;
            this.labelNome.Text = "Nome nome nome nome nome";
            this.labelNome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCheckIn
            // 
            this.labelCheckIn.AutoSize = true;
            this.labelCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCheckIn.Location = new System.Drawing.Point(41, 131);
            this.labelCheckIn.Name = "labelCheckIn";
            this.labelCheckIn.Size = new System.Drawing.Size(95, 16);
            this.labelCheckIn.TabIndex = 5;
            this.labelCheckIn.Text = "De: 00/00/0000";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(36, 111);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(56, 16);
            this.label30.TabIndex = 5;
            this.label30.Text = "Estadia:";
            // 
            // labelEmbarcacao
            // 
            this.labelEmbarcacao.AutoSize = true;
            this.labelEmbarcacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmbarcacao.Location = new System.Drawing.Point(42, 88);
            this.labelEmbarcacao.Name = "labelEmbarcacao";
            this.labelEmbarcacao.Size = new System.Drawing.Size(133, 20);
            this.labelEmbarcacao.TabIndex = 4;
            this.labelEmbarcacao.Text = "SKANDI RECIFE";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel10.BackgroundImage")));
            this.panel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel10.Location = new System.Drawing.Point(39, 6);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(74, 46);
            this.panel10.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(177, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Casa de Máquinas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(165, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Acesso:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(236, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 29);
            this.label4.TabIndex = 13;
            this.label4.Text = "AB+";
            // 
            // UC_Etiqueta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelFundo);
            this.Name = "UC_Etiqueta";
            this.Size = new System.Drawing.Size(308, 216);
            this.Load += new System.EventHandler(this.UC_Etiqueta_Load);
            this.panelFundo.ResumeLayout(false);
            this.panelFundo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFundo;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.TextBox labelEmpresa;
        private System.Windows.Forms.Label labelCheckOut;
        private System.Windows.Forms.TextBox labelIdentificacao;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Label labelCheckIn;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label labelEmbarcacao;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
