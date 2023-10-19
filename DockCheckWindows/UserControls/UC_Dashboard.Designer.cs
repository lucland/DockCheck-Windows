namespace DockCheckWindows.UserControls
{
    partial class UC_Dashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Dashboard));
            this.chartOnBoardedToday = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartOnBoardedAll = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPieEmpresas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelEmpresas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCadastrar = new Guna.UI2.WinForms.Guna2Button();
            this.buttonRegistrar = new Guna.UI2.WinForms.Guna2Button();
            this.buttonSincronizar = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartOnBoardedToday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOnBoardedAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPieEmpresas)).BeginInit();
            this.SuspendLayout();
            // 
            // chartOnBoardedToday
            // 
            this.chartOnBoardedToday.BackColor = System.Drawing.Color.Transparent;
            this.chartOnBoardedToday.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            chartArea1.Name = "ChartArea1";
            this.chartOnBoardedToday.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.TitleFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartOnBoardedToday.Legends.Add(legend1);
            this.chartOnBoardedToday.Location = new System.Drawing.Point(1225, 25);
            this.chartOnBoardedToday.Name = "chartOnBoardedToday";
            this.chartOnBoardedToday.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BorderWidth = 5;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "A bordo";
            this.chartOnBoardedToday.Series.Add(series1);
            this.chartOnBoardedToday.Size = new System.Drawing.Size(674, 336);
            this.chartOnBoardedToday.TabIndex = 0;
            this.chartOnBoardedToday.Text = "onBoarded";
            title1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "25/09/2023";
            this.chartOnBoardedToday.Titles.Add(title1);
            // 
            // chartOnBoardedAll
            // 
            this.chartOnBoardedAll.BackColor = System.Drawing.Color.Transparent;
            this.chartOnBoardedAll.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.chartOnBoardedAll.BorderlineWidth = 0;
            this.chartOnBoardedAll.BorderSkin.BorderColor = System.Drawing.Color.Transparent;
            this.chartOnBoardedAll.BorderSkin.PageColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisX2.TitleFont = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY2.LineWidth = 0;
            chartArea2.AxisY2.TitleFont = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.Cross;
            chartArea2.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea2.BorderColor = System.Drawing.Color.Transparent;
            chartArea2.BorderWidth = 0;
            chartArea2.Name = "ChartArea1";
            this.chartOnBoardedAll.ChartAreas.Add(chartArea2);
            legend2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            legend2.TitleFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartOnBoardedAll.Legends.Add(legend2);
            this.chartOnBoardedAll.Location = new System.Drawing.Point(1225, 412);
            this.chartOnBoardedAll.Name = "chartOnBoardedAll";
            this.chartOnBoardedAll.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            this.chartOnBoardedAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series2.ChartArea = "ChartArea1";
            series2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "Legend1";
            series2.Name = "A bordo";
            this.chartOnBoardedAll.Series.Add(series2);
            this.chartOnBoardedAll.Size = new System.Drawing.Size(674, 340);
            this.chartOnBoardedAll.TabIndex = 1;
            this.chartOnBoardedAll.Text = "onBoarded";
            title2.Font = new System.Drawing.Font("Century Schoolbook", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "2023";
            this.chartOnBoardedAll.Titles.Add(title2);
            // 
            // chartPieEmpresas
            // 
            this.chartPieEmpresas.BackColor = System.Drawing.Color.Transparent;
            this.chartPieEmpresas.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.chartPieEmpresas.BorderlineWidth = 0;
            this.chartPieEmpresas.BorderSkin.BorderColor = System.Drawing.Color.Transparent;
            this.chartPieEmpresas.BorderSkin.PageColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            chartArea3.AxisX.TitleFont = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisX2.TitleFont = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisY.TitleFont = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisY2.LineWidth = 0;
            chartArea3.AxisY2.TitleFont = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.BackColor = System.Drawing.Color.White;
            chartArea3.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea3.BorderColor = System.Drawing.Color.Transparent;
            chartArea3.BorderWidth = 0;
            chartArea3.Name = "ChartArea1";
            this.chartPieEmpresas.ChartAreas.Add(chartArea3);
            legend3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            legend3.IsTextAutoFit = false;
            legend3.Name = "Legend1";
            legend3.TitleFont = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartPieEmpresas.Legends.Add(legend3);
            this.chartPieEmpresas.Location = new System.Drawing.Point(3, 25);
            this.chartPieEmpresas.Name = "chartPieEmpresas";
            this.chartPieEmpresas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.IsXValueIndexed = true;
            series3.LabelForeColor = System.Drawing.Color.White;
            series3.Legend = "Legend1";
            series3.Name = "Empresas";
            this.chartPieEmpresas.Series.Add(series3);
            this.chartPieEmpresas.Size = new System.Drawing.Size(1216, 808);
            this.chartPieEmpresas.TabIndex = 2;
            this.chartPieEmpresas.Text = "onBoarded";
            title3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.Name = "2023";
            this.chartPieEmpresas.Titles.Add(title3);
            // 
            // labelEmpresas
            // 
            this.labelEmpresas.AutoSize = true;
            this.labelEmpresas.BackColor = System.Drawing.Color.Transparent;
            this.labelEmpresas.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmpresas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEmpresas.Location = new System.Drawing.Point(21, 25);
            this.labelEmpresas.Name = "labelEmpresas";
            this.labelEmpresas.Size = new System.Drawing.Size(156, 37);
            this.labelEmpresas.TabIndex = 3;
            this.labelEmpresas.Text = "Empresas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(1229, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hoje";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(1229, 412);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 37);
            this.label2.TabIndex = 5;
            this.label2.Text = "Diário";
            // 
            // buttonCadastrar
            // 
            this.buttonCadastrar.BackColor = System.Drawing.Color.Transparent;
            this.buttonCadastrar.BorderRadius = 3;
            this.buttonCadastrar.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(79)))), ((int)(((byte)(235)))));
            this.buttonCadastrar.CustomBorderThickness = new System.Windows.Forms.Padding(5);
            this.buttonCadastrar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonCadastrar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonCadastrar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonCadastrar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonCadastrar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(79)))), ((int)(((byte)(235)))));
            this.buttonCadastrar.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCadastrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.buttonCadastrar.Image = ((System.Drawing.Image)(resources.GetObject("buttonCadastrar.Image")));
            this.buttonCadastrar.ImageSize = new System.Drawing.Size(30, 30);
            this.buttonCadastrar.Location = new System.Drawing.Point(1483, 796);
            this.buttonCadastrar.Name = "buttonCadastrar";
            this.buttonCadastrar.Size = new System.Drawing.Size(418, 63);
            this.buttonCadastrar.TabIndex = 6;
            this.buttonCadastrar.Text = "Gerar Formulário";
            // 
            // buttonRegistrar
            // 
            this.buttonRegistrar.BackColor = System.Drawing.Color.Transparent;
            this.buttonRegistrar.BorderRadius = 3;
            this.buttonRegistrar.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(70)))));
            this.buttonRegistrar.CustomBorderThickness = new System.Windows.Forms.Padding(5);
            this.buttonRegistrar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonRegistrar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonRegistrar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonRegistrar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonRegistrar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(70)))));
            this.buttonRegistrar.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegistrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.buttonRegistrar.Image = ((System.Drawing.Image)(resources.GetObject("buttonRegistrar.Image")));
            this.buttonRegistrar.ImageOffset = new System.Drawing.Point(0, 1);
            this.buttonRegistrar.ImageSize = new System.Drawing.Size(30, 30);
            this.buttonRegistrar.Location = new System.Drawing.Point(1483, 865);
            this.buttonRegistrar.Name = "buttonRegistrar";
            this.buttonRegistrar.Size = new System.Drawing.Size(418, 63);
            this.buttonRegistrar.TabIndex = 7;
            this.buttonRegistrar.Text = "Baixar PDF";
            // 
            // buttonSincronizar
            // 
            this.buttonSincronizar.BorderRadius = 3;
            this.buttonSincronizar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonSincronizar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonSincronizar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonSincronizar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonSincronizar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(79)))), ((int)(((byte)(235)))));
            this.buttonSincronizar.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSincronizar.ForeColor = System.Drawing.Color.White;
            this.buttonSincronizar.Image = ((System.Drawing.Image)(resources.GetObject("buttonSincronizar.Image")));
            this.buttonSincronizar.ImageSize = new System.Drawing.Size(30, 30);
            this.buttonSincronizar.Location = new System.Drawing.Point(1059, 865);
            this.buttonSincronizar.Name = "buttonSincronizar";
            this.buttonSincronizar.Size = new System.Drawing.Size(418, 63);
            this.buttonSincronizar.TabIndex = 8;
            this.buttonSincronizar.Text = "Sincronizar";
            // 
            // UC_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.buttonSincronizar);
            this.Controls.Add(this.buttonCadastrar);
            this.Controls.Add(this.buttonRegistrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelEmpresas);
            this.Controls.Add(this.chartPieEmpresas);
            this.Controls.Add(this.chartOnBoardedAll);
            this.Controls.Add(this.chartOnBoardedToday);
            this.Name = "UC_Dashboard";
            this.Size = new System.Drawing.Size(1904, 906);
            ((System.ComponentModel.ISupportInitialize)(this.chartOnBoardedToday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOnBoardedAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPieEmpresas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartOnBoardedToday;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOnBoardedAll;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPieEmpresas;
        private System.Windows.Forms.Label labelEmpresas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button buttonCadastrar;
        private Guna.UI2.WinForms.Guna2Button buttonRegistrar;
        private Guna.UI2.WinForms.Guna2Button buttonSincronizar;
    }
}
