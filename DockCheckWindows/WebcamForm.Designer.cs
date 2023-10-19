namespace DockCheckWindows
{
    partial class WebcamForm
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
            this.pictureBoxWebcam = new System.Windows.Forms.PictureBox();
            this.buttonCapture = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CancelarButton = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWebcam)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxWebcam
            // 
            this.pictureBoxWebcam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBoxWebcam.Location = new System.Drawing.Point(35, 12);
            this.pictureBoxWebcam.Name = "pictureBoxWebcam";
            this.pictureBoxWebcam.Size = new System.Drawing.Size(729, 358);
            this.pictureBoxWebcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWebcam.TabIndex = 0;
            this.pictureBoxWebcam.TabStop = false;
            // 
            // buttonCapture
            // 
            this.buttonCapture.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonCapture.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonCapture.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonCapture.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonCapture.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(79)))), ((int)(((byte)(235)))));
            this.buttonCapture.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCapture.ForeColor = System.Drawing.Color.White;
            this.buttonCapture.Location = new System.Drawing.Point(426, 386);
            this.buttonCapture.Name = "buttonCapture";
            this.buttonCapture.Size = new System.Drawing.Size(180, 45);
            this.buttonCapture.TabIndex = 1;
            this.buttonCapture.Text = "CAPTURAR";
            this.buttonCapture.Click += new System.EventHandler(this.buttonCapture_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.pictureBoxWebcam);
            this.panel1.Controls.Add(this.CancelarButton);
            this.panel1.Controls.Add(this.buttonCapture);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 453);
            this.panel1.TabIndex = 2;
            // 
            // CancelarButton
            // 
            this.CancelarButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CancelarButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CancelarButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CancelarButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CancelarButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.CancelarButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelarButton.ForeColor = System.Drawing.Color.White;
            this.CancelarButton.Location = new System.Drawing.Point(214, 386);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(180, 45);
            this.CancelarButton.TabIndex = 1;
            this.CancelarButton.Text = "CANCELAR";
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // WebcamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WebcamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tirar foto";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWebcam)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxWebcam;
        private Guna.UI2.WinForms.Guna2Button buttonCapture;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button CancelarButton;
    }
}