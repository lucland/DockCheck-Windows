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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartOnBoarded = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartOnBoarded)).BeginInit();
            this.SuspendLayout();
            // 
            // chartOnBoarded
            // 
            this.chartOnBoarded.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.chartOnBoarded.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            chartArea2.Name = "ChartArea1";
            this.chartOnBoarded.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartOnBoarded.Legends.Add(legend2);
            this.chartOnBoarded.Location = new System.Drawing.Point(124, 626);
            this.chartOnBoarded.Name = "chartOnBoarded";
            this.chartOnBoarded.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartOnBoarded.Series.Add(series2);
            this.chartOnBoarded.Size = new System.Drawing.Size(1777, 277);
            this.chartOnBoarded.TabIndex = 0;
            this.chartOnBoarded.Text = "onBoarded";
            this.chartOnBoarded.Click += new System.EventHandler(this.chartOnBoarded_Click);
            // 
            // UC_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartOnBoarded);
            this.Name = "UC_Dashboard";
            this.Size = new System.Drawing.Size(1904, 906);
            ((System.ComponentModel.ISupportInitialize)(this.chartOnBoarded)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartOnBoarded;
    }
}
