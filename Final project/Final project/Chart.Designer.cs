namespace Final_project
{
    partial class Chart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.StockChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBox_Pattern = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.StockChart)).BeginInit();
            this.SuspendLayout();
            // 
            // StockChart
            // 
            chartArea1.Name = "OHLC";
            this.StockChart.ChartAreas.Add(chartArea1);
            this.StockChart.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.StockChart.Legends.Add(legend1);
            this.StockChart.Location = new System.Drawing.Point(0, 0);
            this.StockChart.Name = "StockChart";
            series1.ChartArea = "OHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Legend = "Legend1";
            series1.Name = "OHLC";
            series1.YValuesPerPoint = 4;
            this.StockChart.Series.Add(series1);
            this.StockChart.Size = new System.Drawing.Size(800, 340);
            this.StockChart.TabIndex = 0;
            this.StockChart.Click += new System.EventHandler(this.StockChart_Click);
            // 
            // comboBox_Pattern
            // 
            this.comboBox_Pattern.FormattingEnabled = true;
            this.comboBox_Pattern.Location = new System.Drawing.Point(288, 346);
            this.comboBox_Pattern.Name = "comboBox_Pattern";
            this.comboBox_Pattern.Size = new System.Drawing.Size(203, 24);
            this.comboBox_Pattern.TabIndex = 1;
            this.comboBox_Pattern.SelectedIndexChanged += new System.EventHandler(this.comboBox_Pattern_SelectedIndexChanged);
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox_Pattern);
            this.Controls.Add(this.StockChart);
            this.Name = "Chart";
            this.Text = "ACandlestickReader";
            this.Load += new System.EventHandler(this.Chart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StockChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart StockChart;
        private System.Windows.Forms.ComboBox comboBox_Pattern;
    }
}