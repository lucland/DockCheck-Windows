namespace DockCheckWindows.UserControls
{
    partial class UC_Employee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Employee));
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxRFID = new System.Windows.Forms.TextBox();
            this.labelRFID = new System.Windows.Forms.Label();
            this.leriTagButton = new Guna.UI2.WinForms.Guna2Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelAvisoRFID = new System.Windows.Forms.Label();
            this.printButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ButtonCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBoxRFID);
            this.panel2.Location = new System.Drawing.Point(146, 110);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(571, 46);
            this.panel2.TabIndex = 40;
            // 
            // textBoxRFID
            // 
            this.textBoxRFID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxRFID.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRFID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxRFID.Location = new System.Drawing.Point(8, 5);
            this.textBoxRFID.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textBoxRFID.MaxLength = 24;
            this.textBoxRFID.Name = "textBoxRFID";
            this.textBoxRFID.Size = new System.Drawing.Size(537, 37);
            this.textBoxRFID.TabIndex = 0;
            // 
            // labelRFID
            // 
            this.labelRFID.AutoSize = true;
            this.labelRFID.BackColor = System.Drawing.SystemColors.Control;
            this.labelRFID.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRFID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelRFID.Location = new System.Drawing.Point(35, 112);
            this.labelRFID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRFID.Name = "labelRFID";
            this.labelRFID.Size = new System.Drawing.Size(92, 44);
            this.labelRFID.TabIndex = 42;
            this.labelRFID.Text = "iTag";
            // 
            // leriTagButton
            // 
            this.leriTagButton.BackColor = System.Drawing.Color.Transparent;
            this.leriTagButton.BorderRadius = 3;
            this.leriTagButton.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.leriTagButton.CustomBorderThickness = new System.Windows.Forms.Padding(5);
            this.leriTagButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.leriTagButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.leriTagButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.leriTagButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.leriTagButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.leriTagButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leriTagButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.leriTagButton.Image = ((System.Drawing.Image)(resources.GetObject("leriTagButton.Image")));
            this.leriTagButton.ImageOffset = new System.Drawing.Point(0, 1);
            this.leriTagButton.ImageSize = new System.Drawing.Size(30, 30);
            this.leriTagButton.Location = new System.Drawing.Point(726, 110);
            this.leriTagButton.Margin = new System.Windows.Forms.Padding(4);
            this.leriTagButton.Name = "leriTagButton";
            this.leriTagButton.Size = new System.Drawing.Size(59, 47);
            this.leriTagButton.TabIndex = 41;
            this.leriTagButton.Click += new System.EventHandler(this.leriTagButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label4.Location = new System.Drawing.Point(136, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 47);
            this.label4.TabIndex = 44;
            this.label4.Text = "!";
            // 
            // labelAvisoRFID
            // 
            this.labelAvisoRFID.AutoSize = true;
            this.labelAvisoRFID.BackColor = System.Drawing.SystemColors.Control;
            this.labelAvisoRFID.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAvisoRFID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelAvisoRFID.Location = new System.Drawing.Point(171, 16);
            this.labelAvisoRFID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAvisoRFID.Name = "labelAvisoRFID";
            this.labelAvisoRFID.Size = new System.Drawing.Size(521, 72);
            this.labelAvisoRFID.TabIndex = 43;
            this.labelAvisoRFID.Text = "ATENÇÃO! Não digitar no campo abaixo, apenas clique no campo\r\ne leia a iTag com o" +
    " leitor conectado. \r\nAssim que o código for incluso, não alterá-lo.";
            // 
            // printButton
            // 
            this.printButton.BackColor = System.Drawing.Color.Transparent;
            this.printButton.BorderRadius = 3;
            this.printButton.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.printButton.CustomBorderThickness = new System.Windows.Forms.Padding(3);
            this.printButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.printButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.printButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.printButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.printButton.FillColor = System.Drawing.Color.White;
            this.printButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.printButton.ImageSize = new System.Drawing.Size(30, 30);
            this.printButton.Location = new System.Drawing.Point(43, 186);
            this.printButton.Margin = new System.Windows.Forms.Padding(4);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(742, 81);
            this.printButton.TabIndex = 45;
            this.printButton.Text = "Imprimir etiqueta";
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // guna2ButtonCancelar
            // 
            this.guna2ButtonCancelar.BackColor = System.Drawing.Color.Transparent;
            this.guna2ButtonCancelar.BorderRadius = 3;
            this.guna2ButtonCancelar.CustomBorderColor = System.Drawing.Color.IndianRed;
            this.guna2ButtonCancelar.CustomBorderThickness = new System.Windows.Forms.Padding(3);
            this.guna2ButtonCancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2ButtonCancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2ButtonCancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2ButtonCancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2ButtonCancelar.FillColor = System.Drawing.Color.IndianRed;
            this.guna2ButtonCancelar.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ButtonCancelar.ForeColor = System.Drawing.Color.White;
            this.guna2ButtonCancelar.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2ButtonCancelar.Location = new System.Drawing.Point(43, 288);
            this.guna2ButtonCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ButtonCancelar.Name = "guna2ButtonCancelar";
            this.guna2ButtonCancelar.Size = new System.Drawing.Size(742, 81);
            this.guna2ButtonCancelar.TabIndex = 46;
            this.guna2ButtonCancelar.Text = "Cancelar";
            this.guna2ButtonCancelar.Click += new System.EventHandler(this.guna2ButtonCancelar_Click);
            // 
            // UC_Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2ButtonCancelar);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelRFID);
            this.Controls.Add(this.leriTagButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelAvisoRFID);
            this.Name = "UC_Employee";
            this.Size = new System.Drawing.Size(835, 406);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxRFID;
        private System.Windows.Forms.Label labelRFID;
        private Guna.UI2.WinForms.Guna2Button leriTagButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelAvisoRFID;
        private Guna.UI2.WinForms.Guna2Button printButton;
        private Guna.UI2.WinForms.Guna2Button guna2ButtonCancelar;
    }
}
