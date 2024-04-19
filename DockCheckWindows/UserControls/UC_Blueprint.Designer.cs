namespace DockCheckWindows.UserControls
{
    partial class UC_Blueprint
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
            this.guna2WinProgressIndicator1 = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            this.SuspendLayout();
            // 
            // guna2WinProgressIndicator1
            // 
            this.guna2WinProgressIndicator1.AutoStart = true;
            this.guna2WinProgressIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.guna2WinProgressIndicator1.Location = new System.Drawing.Point(1078, 477);
            this.guna2WinProgressIndicator1.Name = "guna2WinProgressIndicator1";
            this.guna2WinProgressIndicator1.NumberOfCircles = 16;
            this.guna2WinProgressIndicator1.ProgressColor = System.Drawing.SystemColors.WindowText;
            this.guna2WinProgressIndicator1.Size = new System.Drawing.Size(286, 274);
            this.guna2WinProgressIndicator1.TabIndex = 2;
            this.guna2WinProgressIndicator1.Visible = false;
            // 
            // UC_Blueprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2WinProgressIndicator1);
            this.Name = "UC_Blueprint";
            this.Size = new System.Drawing.Size(2539, 1115);
            this.Load += new System.EventHandler(this.UC_Blueprint_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2WinProgressIndicator guna2WinProgressIndicator1;
    }
}
