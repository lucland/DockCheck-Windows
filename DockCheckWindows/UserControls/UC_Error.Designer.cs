namespace DockCheckWindows.UserControls
{
    partial class UC_Error
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Error));
            this.retryButton = new Guna.UI2.WinForms.Guna2Button();
            this.cancelarButton = new Guna.UI2.WinForms.Guna2Button();
            this.labelError = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // retryButton
            // 
            this.retryButton.BorderRadius = 3;
            this.retryButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.retryButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.retryButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.retryButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.retryButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.retryButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retryButton.ForeColor = System.Drawing.Color.White;
            this.retryButton.Image = ((System.Drawing.Image)(resources.GetObject("retryButton.Image")));
            this.retryButton.ImageSize = new System.Drawing.Size(30, 30);
            this.retryButton.Location = new System.Drawing.Point(353, 291);
            this.retryButton.Name = "retryButton";
            this.retryButton.Size = new System.Drawing.Size(304, 71);
            this.retryButton.TabIndex = 7;
            this.retryButton.Text = "Tentar novamente";
            this.retryButton.Click += new System.EventHandler(this.retryButton_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.BorderRadius = 3;
            this.cancelarButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.cancelarButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.cancelarButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.cancelarButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.cancelarButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.cancelarButton.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarButton.ForeColor = System.Drawing.Color.White;
            this.cancelarButton.ImageSize = new System.Drawing.Size(30, 30);
            this.cancelarButton.Location = new System.Drawing.Point(25, 291);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(304, 71);
            this.cancelarButton.TabIndex = 8;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.BackColor = System.Drawing.Color.Transparent;
            this.labelError.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.labelError.Location = new System.Drawing.Point(53, 177);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(568, 66);
            this.labelError.TabIndex = 9;
            this.labelError.Text = "Erro ao tentar se conectar com o servidor.\r\nPor favor tente novamente.";
            this.labelError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelError.UseMnemonic = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 120F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label1.Location = new System.Drawing.Point(265, -25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 185);
            this.label1.TabIndex = 9;
            this.label1.Text = "x";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.UseMnemonic = false;
            // 
            // UC_Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.retryButton);
            this.Name = "UC_Error";
            this.Size = new System.Drawing.Size(683, 397);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button retryButton;
        private Guna.UI2.WinForms.Guna2Button cancelarButton;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label label1;
    }
}
