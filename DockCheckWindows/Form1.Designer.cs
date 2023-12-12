namespace DockCheckWindows
{
    partial class Form1
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxRecebendo = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelUser = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.fecharButton = new Guna.UI2.WinForms.Guna2Button();
            this.cameraButton = new Guna.UI2.WinForms.Guna2Button();
            this.bancoButton = new Guna.UI2.WinForms.Guna2Button();
            this.dashboardButton = new Guna.UI2.WinForms.Guna2Button();
            this.cadastroButton = new Guna.UI2.WinForms.Guna2Button();
            this.homeButton = new Guna.UI2.WinForms.Guna2Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelContainer = new System.Windows.Forms.Panel();
            this.vesselLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRecebendo)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel1.Controls.Add(this.vesselLabel);
            this.panel1.Controls.Add(this.pictureBoxRecebendo);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1904, 70);
            this.panel1.TabIndex = 0;
            // 
            // pictureBoxRecebendo
            // 
            this.pictureBoxRecebendo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.pictureBoxRecebendo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxRecebendo.Image")));
            this.pictureBoxRecebendo.Location = new System.Drawing.Point(1567, -14);
            this.pictureBoxRecebendo.Name = "pictureBoxRecebendo";
            this.pictureBoxRecebendo.Size = new System.Drawing.Size(107, 88);
            this.pictureBoxRecebendo.TabIndex = 5;
            this.pictureBoxRecebendo.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.panel4.Controls.Add(this.labelUser);
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Location = new System.Drawing.Point(1666, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(258, 70);
            this.panel4.TabIndex = 4;
            // 
            // labelUser
            // 
            this.labelUser.AutoEllipsis = true;
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelUser.ForeColor = System.Drawing.Color.White;
            this.labelUser.Location = new System.Drawing.Point(93, 21);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(78, 25);
            this.labelUser.TabIndex = 1;
            this.labelUser.Text = "admin";
            this.labelUser.Click += new System.EventHandler(this.labelUser_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(36, 9);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(250, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-93, -86);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(427, 252);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.fecharButton);
            this.panel2.Controls.Add(this.cameraButton);
            this.panel2.Controls.Add(this.bancoButton);
            this.panel2.Controls.Add(this.dashboardButton);
            this.panel2.Controls.Add(this.cadastroButton);
            this.panel2.Controls.Add(this.homeButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1904, 65);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.panel3.Location = new System.Drawing.Point(0, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1920, 13);
            this.panel3.TabIndex = 6;
            // 
            // fecharButton
            // 
            this.fecharButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.fecharButton.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.fecharButton.CheckedState.FillColor = System.Drawing.Color.White;
            this.fecharButton.CustomBorderColor = System.Drawing.Color.White;
            this.fecharButton.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.fecharButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.fecharButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.fecharButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.fecharButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.fecharButton.FillColor = System.Drawing.Color.White;
            this.fecharButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecharButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.fecharButton.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.fecharButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.fecharButton.HoverState.ForeColor = System.Drawing.Color.White;
            this.fecharButton.Location = new System.Drawing.Point(1731, 0);
            this.fecharButton.Name = "fecharButton";
            this.fecharButton.Size = new System.Drawing.Size(189, 54);
            this.fecharButton.TabIndex = 5;
            this.fecharButton.TabStop = false;
            this.fecharButton.Text = "FECHAR";
            this.fecharButton.Click += new System.EventHandler(this.fecharButton_Click);
            // 
            // cameraButton
            // 
            this.cameraButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.cameraButton.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.cameraButton.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.cameraButton.CheckedState.ForeColor = System.Drawing.Color.White;
            this.cameraButton.CustomBorderColor = System.Drawing.Color.White;
            this.cameraButton.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.cameraButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.cameraButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.cameraButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.cameraButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.cameraButton.FillColor = System.Drawing.Color.White;
            this.cameraButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cameraButton.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(247)))));
            this.cameraButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(247)))));
            this.cameraButton.HoverState.ForeColor = System.Drawing.Color.White;
            this.cameraButton.Location = new System.Drawing.Point(780, 0);
            this.cameraButton.Name = "cameraButton";
            this.cameraButton.Size = new System.Drawing.Size(189, 54);
            this.cameraButton.TabIndex = 4;
            this.cameraButton.TabStop = false;
            this.cameraButton.Text = "Câmeras";
            this.cameraButton.Visible = false;
            this.cameraButton.Click += new System.EventHandler(this.cameraButton_Click);
            // 
            // bancoButton
            // 
            this.bancoButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.bancoButton.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.bancoButton.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.bancoButton.CheckedState.ForeColor = System.Drawing.Color.White;
            this.bancoButton.CustomBorderColor = System.Drawing.Color.White;
            this.bancoButton.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.bancoButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bancoButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bancoButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bancoButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bancoButton.FillColor = System.Drawing.Color.White;
            this.bancoButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bancoButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bancoButton.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(247)))));
            this.bancoButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(247)))));
            this.bancoButton.HoverState.ForeColor = System.Drawing.Color.White;
            this.bancoButton.Location = new System.Drawing.Point(585, 0);
            this.bancoButton.Name = "bancoButton";
            this.bancoButton.Size = new System.Drawing.Size(189, 54);
            this.bancoButton.TabIndex = 3;
            this.bancoButton.TabStop = false;
            this.bancoButton.Text = "Dados";
            this.bancoButton.Click += new System.EventHandler(this.bancoButton_Click);
            // 
            // dashboardButton
            // 
            this.dashboardButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.dashboardButton.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.dashboardButton.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.dashboardButton.CheckedState.ForeColor = System.Drawing.Color.White;
            this.dashboardButton.CustomBorderColor = System.Drawing.Color.White;
            this.dashboardButton.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.dashboardButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.dashboardButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.dashboardButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.dashboardButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dashboardButton.FillColor = System.Drawing.Color.White;
            this.dashboardButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dashboardButton.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(247)))));
            this.dashboardButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(247)))));
            this.dashboardButton.HoverState.ForeColor = System.Drawing.Color.White;
            this.dashboardButton.Location = new System.Drawing.Point(390, 0);
            this.dashboardButton.Name = "dashboardButton";
            this.dashboardButton.Size = new System.Drawing.Size(189, 54);
            this.dashboardButton.TabIndex = 2;
            this.dashboardButton.TabStop = false;
            this.dashboardButton.Text = "Dashboard";
            this.dashboardButton.Click += new System.EventHandler(this.dashboardButton_Click);
            // 
            // cadastroButton
            // 
            this.cadastroButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.cadastroButton.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.cadastroButton.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.cadastroButton.CheckedState.ForeColor = System.Drawing.Color.White;
            this.cadastroButton.CustomBorderColor = System.Drawing.Color.White;
            this.cadastroButton.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.cadastroButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.cadastroButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.cadastroButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.cadastroButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.cadastroButton.FillColor = System.Drawing.Color.White;
            this.cadastroButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cadastroButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cadastroButton.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(247)))));
            this.cadastroButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(247)))));
            this.cadastroButton.HoverState.ForeColor = System.Drawing.Color.White;
            this.cadastroButton.Location = new System.Drawing.Point(195, 0);
            this.cadastroButton.Name = "cadastroButton";
            this.cadastroButton.Size = new System.Drawing.Size(189, 54);
            this.cadastroButton.TabIndex = 1;
            this.cadastroButton.TabStop = false;
            this.cadastroButton.Text = "Cadastrar";
            this.cadastroButton.Click += new System.EventHandler(this.cadastroButton_Click);
            // 
            // homeButton
            // 
            this.homeButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.homeButton.Checked = true;
            this.homeButton.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.homeButton.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.homeButton.CheckedState.ForeColor = System.Drawing.Color.White;
            this.homeButton.CustomBorderColor = System.Drawing.Color.White;
            this.homeButton.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.homeButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.homeButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.homeButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.homeButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.homeButton.FillColor = System.Drawing.Color.White;
            this.homeButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.homeButton.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(247)))));
            this.homeButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(247)))));
            this.homeButton.HoverState.ForeColor = System.Drawing.Color.White;
            this.homeButton.Location = new System.Drawing.Point(0, 0);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(189, 54);
            this.homeButton.TabIndex = 0;
            this.homeButton.TabStop = false;
            this.homeButton.Text = "Home";
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 135);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1904, 906);
            this.panelContainer.TabIndex = 2;
            this.panelContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContainer_Paint);
            // 
            // vesselLabel
            // 
            this.vesselLabel.AutoEllipsis = true;
            this.vesselLabel.AutoSize = true;
            this.vesselLabel.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold);
            this.vesselLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.vesselLabel.Location = new System.Drawing.Point(1250, 21);
            this.vesselLabel.Name = "vesselLabel";
            this.vesselLabel.Size = new System.Drawing.Size(78, 25);
            this.vesselLabel.TabIndex = 2;
            this.vesselLabel.Text = "admin";
            this.vesselLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.vesselLabel.Click += new System.EventHandler(this.vesselLabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "t";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRecebendo)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panelContainer;
        private Guna.UI2.WinForms.Guna2Button homeButton;
        private Guna.UI2.WinForms.Guna2Button fecharButton;
        private Guna.UI2.WinForms.Guna2Button cameraButton;
        private Guna.UI2.WinForms.Guna2Button bancoButton;
        private Guna.UI2.WinForms.Guna2Button dashboardButton;
        private Guna.UI2.WinForms.Guna2Button cadastroButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBoxRecebendo;
        private System.Windows.Forms.Label vesselLabel;
    }
}

