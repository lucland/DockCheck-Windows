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
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.guna2Shapes1 = new Guna.UI2.WinForms.Guna2Shapes();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBoxRFID);
            this.panel2.Location = new System.Drawing.Point(101, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(391, 43);
            this.panel2.TabIndex = 40;
            // 
            // textBoxRFID
            // 
            this.textBoxRFID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxRFID.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRFID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxRFID.Location = new System.Drawing.Point(10, 3);
            this.textBoxRFID.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxRFID.MaxLength = 24;
            this.textBoxRFID.Name = "textBoxRFID";
            this.textBoxRFID.Size = new System.Drawing.Size(374, 36);
            this.textBoxRFID.TabIndex = 0;
            // 
            // labelRFID
            // 
            this.labelRFID.AutoSize = true;
            this.labelRFID.BackColor = System.Drawing.SystemColors.Control;
            this.labelRFID.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRFID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelRFID.Location = new System.Drawing.Point(17, 97);
            this.labelRFID.Name = "labelRFID";
            this.labelRFID.Size = new System.Drawing.Size(77, 37);
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
            this.leriTagButton.Location = new System.Drawing.Point(515, 95);
            this.leriTagButton.Name = "leriTagButton";
            this.leriTagButton.Size = new System.Drawing.Size(49, 43);
            this.leriTagButton.TabIndex = 41;
            this.leriTagButton.Click += new System.EventHandler(this.leriTagButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label4.Location = new System.Drawing.Point(71, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 38);
            this.label4.TabIndex = 44;
            this.label4.Text = "!";
            // 
            // labelAvisoRFID
            // 
            this.labelAvisoRFID.AutoSize = true;
            this.labelAvisoRFID.BackColor = System.Drawing.SystemColors.Control;
            this.labelAvisoRFID.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAvisoRFID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelAvisoRFID.Location = new System.Drawing.Point(97, 28);
            this.labelAvisoRFID.Name = "labelAvisoRFID";
            this.labelAvisoRFID.Size = new System.Drawing.Size(418, 60);
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
            this.printButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.printButton.FillColor = System.Drawing.Color.White;
            this.printButton.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.printButton.ImageSize = new System.Drawing.Size(30, 30);
            this.printButton.Location = new System.Drawing.Point(0, 0);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(585, 66);
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
            this.guna2ButtonCancelar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2ButtonCancelar.FillColor = System.Drawing.Color.IndianRed;
            this.guna2ButtonCancelar.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ButtonCancelar.ForeColor = System.Drawing.Color.White;
            this.guna2ButtonCancelar.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2ButtonCancelar.Location = new System.Drawing.Point(0, 282);
            this.guna2ButtonCancelar.Name = "guna2ButtonCancelar";
            this.guna2ButtonCancelar.Size = new System.Drawing.Size(585, 55);
            this.guna2ButtonCancelar.TabIndex = 46;
            this.guna2ButtonCancelar.Text = "Cancelar";
            this.guna2ButtonCancelar.Click += new System.EventHandler(this.guna2ButtonCancelar_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 3;
            this.guna2Button1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.guna2Button1.CustomBorderThickness = new System.Windows.Forms.Padding(3);
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.guna2Button1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2Button1.Location = new System.Drawing.Point(0, 65);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(585, 66);
            this.guna2Button1.TabIndex = 47;
            this.guna2Button1.Text = "Vincular Beacon";
            this.guna2Button1.Click += new System.EventHandler(this.lerTagButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.guna2Button1);
            this.panel1.Controls.Add(this.printButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 131);
            this.panel1.TabIndex = 48;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 151);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(585, 131);
            this.panel3.TabIndex = 49;
            // 
            // guna2Shapes1
            // 
            this.guna2Shapes1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Shapes1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.guna2Shapes1.BorderThickness = 8;
            this.guna2Shapes1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Shapes1.Location = new System.Drawing.Point(-74, -39);
            this.guna2Shapes1.Name = "guna2Shapes1";
            this.guna2Shapes1.PolygonSides = 4;
            this.guna2Shapes1.PolygonSkip = 1;
            this.guna2Shapes1.Rotate = 0F;
            this.guna2Shapes1.Shape = Guna.UI2.WinForms.Enums.ShapeType.Rectangle;
            this.guna2Shapes1.Size = new System.Drawing.Size(732, 388);
            this.guna2Shapes1.TabIndex = 50;
            this.guna2Shapes1.Text = "guna2Shapes1";
            this.guna2Shapes1.Zoom = 80;
            // 
            // UC_Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.guna2ButtonCancelar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelRFID);
            this.Controls.Add(this.leriTagButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelAvisoRFID);
            this.Controls.Add(this.guna2Shapes1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UC_Employee";
            this.Size = new System.Drawing.Size(585, 337);
            this.Load += new System.EventHandler(this.UC_Employee_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
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
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Shapes guna2Shapes1;
    }
}
