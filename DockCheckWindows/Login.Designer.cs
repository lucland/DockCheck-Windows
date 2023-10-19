namespace DockCheckWindows
{
    partial class Login
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
            this.labelUsuario = new System.Windows.Forms.Label();
            this.textBoxSenha = new System.Windows.Forms.TextBox();
            this.labelSenha = new System.Windows.Forms.Label();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.buttonLogin = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.BackColor = System.Drawing.Color.Gray;
            this.labelUsuario.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.ForeColor = System.Drawing.Color.White;
            this.labelUsuario.Location = new System.Drawing.Point(38, 32);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(123, 37);
            this.labelUsuario.TabIndex = 1;
            this.labelUsuario.Text = "Usuário";
            // 
            // textBoxSenha
            // 
            this.textBoxSenha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSenha.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxSenha.Location = new System.Drawing.Point(171, 96);
            this.textBoxSenha.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxSenha.Name = "textBoxSenha";
            this.textBoxSenha.Size = new System.Drawing.Size(419, 30);
            this.textBoxSenha.TabIndex = 2;
            this.textBoxSenha.UseSystemPasswordChar = true;
            // 
            // labelSenha
            // 
            this.labelSenha.AutoSize = true;
            this.labelSenha.BackColor = System.Drawing.Color.Gray;
            this.labelSenha.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSenha.ForeColor = System.Drawing.Color.White;
            this.labelSenha.Location = new System.Drawing.Point(38, 91);
            this.labelSenha.Name = "labelSenha";
            this.labelSenha.Size = new System.Drawing.Size(108, 37);
            this.labelSenha.TabIndex = 3;
            this.labelSenha.Text = "Senha";
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUsuario.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxUsuario.Location = new System.Drawing.Point(171, 37);
            this.textBoxUsuario.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(419, 30);
            this.textBoxUsuario.TabIndex = 4;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonCancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonCancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonCancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonCancelar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.buttonCancelar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.ForeColor = System.Drawing.Color.White;
            this.buttonCancelar.Location = new System.Drawing.Point(148, 176);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(180, 45);
            this.buttonCancelar.TabIndex = 5;
            this.buttonCancelar.Text = "CANCELAR";
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(79)))), ((int)(((byte)(235)))));
            this.buttonLogin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(355, 176);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(180, 45);
            this.buttonLogin.TabIndex = 6;
            this.buttonLogin.Text = "LOGIN";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(668, 268);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.textBoxSenha);
            this.Controls.Add(this.labelSenha);
            this.Controls.Add(this.textBoxUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.TextBox textBoxSenha;
        private System.Windows.Forms.Label labelSenha;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private Guna.UI2.WinForms.Guna2Button buttonCancelar;
        private Guna.UI2.WinForms.Guna2Button buttonLogin;
    }
}