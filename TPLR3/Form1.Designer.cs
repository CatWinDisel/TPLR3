namespace TPLR3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1Var2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelMaxDiffEUmn = new System.Windows.Forms.Label();
            this.labelMaxDiffEU = new System.Windows.Forms.Label();
            this.labelMaxDiffUSDmn = new System.Windows.Forms.Label();
            this.labelMaxDiffUSD = new System.Windows.Forms.Label();
            this.numericUpDownWindowSizeVar2 = new System.Windows.Forms.NumericUpDown();
            this.buttonPredictionVar2 = new System.Windows.Forms.Button();
            this.buttonGrafVar2 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowSizeVar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1097, 651);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1Var2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.numericUpDownWindowSizeVar2);
            this.tabPage1.Controls.Add(this.buttonPredictionVar2);
            this.tabPage1.Controls.Add(this.buttonGrafVar2);
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1089, 625);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Michial";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1Var2
            // 
            this.label1Var2.AutoSize = true;
            this.label1Var2.Location = new System.Drawing.Point(8, 105);
            this.label1Var2.Name = "label1Var2";
            this.label1Var2.Size = new System.Drawing.Size(73, 13);
            this.label1Var2.TabIndex = 7;
            this.label1Var2.Text = "Размер окна";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "Max/Min Изменения курса";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelMaxDiffEUmn);
            this.panel1.Controls.Add(this.labelMaxDiffEU);
            this.panel1.Controls.Add(this.labelMaxDiffUSDmn);
            this.panel1.Controls.Add(this.labelMaxDiffUSD);
            this.panel1.Location = new System.Drawing.Point(8, 254);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 127);
            this.panel1.TabIndex = 5;
            // 
            // labelMaxDiffEUmn
            // 
            this.labelMaxDiffEUmn.AutoSize = true;
            this.labelMaxDiffEUmn.Location = new System.Drawing.Point(4, 42);
            this.labelMaxDiffEUmn.Name = "labelMaxDiffEUmn";
            this.labelMaxDiffEUmn.Size = new System.Drawing.Size(91, 13);
            this.labelMaxDiffEUmn.TabIndex = 3;
            this.labelMaxDiffEUmn.Text = "МакспадениеEU";
            // 
            // labelMaxDiffEU
            // 
            this.labelMaxDiffEU.AutoSize = true;
            this.labelMaxDiffEU.Location = new System.Drawing.Point(4, 29);
            this.labelMaxDiffEU.Name = "labelMaxDiffEU";
            this.labelMaxDiffEU.Size = new System.Drawing.Size(90, 13);
            this.labelMaxDiffEU.TabIndex = 2;
            this.labelMaxDiffEU.Text = "МаксПодъемEU";
            // 
            // labelMaxDiffUSDmn
            // 
            this.labelMaxDiffUSDmn.AutoSize = true;
            this.labelMaxDiffUSDmn.Location = new System.Drawing.Point(4, 16);
            this.labelMaxDiffUSDmn.Name = "labelMaxDiffUSDmn";
            this.labelMaxDiffUSDmn.Size = new System.Drawing.Size(101, 13);
            this.labelMaxDiffUSDmn.TabIndex = 1;
            this.labelMaxDiffUSDmn.Text = "МаксПадениеUSD";
            // 
            // labelMaxDiffUSD
            // 
            this.labelMaxDiffUSD.AutoSize = true;
            this.labelMaxDiffUSD.Location = new System.Drawing.Point(3, 3);
            this.labelMaxDiffUSD.Name = "labelMaxDiffUSD";
            this.labelMaxDiffUSD.Size = new System.Drawing.Size(98, 13);
            this.labelMaxDiffUSD.TabIndex = 0;
            this.labelMaxDiffUSD.Text = "МаксПодъемUSD";
            // 
            // numericUpDownWindowSizeVar2
            // 
            this.numericUpDownWindowSizeVar2.Location = new System.Drawing.Point(7, 124);
            this.numericUpDownWindowSizeVar2.Name = "numericUpDownWindowSizeVar2";
            this.numericUpDownWindowSizeVar2.Size = new System.Drawing.Size(142, 20);
            this.numericUpDownWindowSizeVar2.TabIndex = 4;
            // 
            // buttonPredictionVar2
            // 
            this.buttonPredictionVar2.Location = new System.Drawing.Point(7, 150);
            this.buttonPredictionVar2.Name = "buttonPredictionVar2";
            this.buttonPredictionVar2.Size = new System.Drawing.Size(142, 65);
            this.buttonPredictionVar2.TabIndex = 3;
            this.buttonPredictionVar2.Text = "Сделать прогноз";
            this.buttonPredictionVar2.UseVisualStyleBackColor = true;
            this.buttonPredictionVar2.Click += new System.EventHandler(this.buttonPredictionVar2_Click);
            // 
            // buttonGrafVar2
            // 
            this.buttonGrafVar2.Location = new System.Drawing.Point(7, 6);
            this.buttonGrafVar2.Name = "buttonGrafVar2";
            this.buttonGrafVar2.Size = new System.Drawing.Size(146, 65);
            this.buttonGrafVar2.TabIndex = 1;
            this.buttonGrafVar2.Text = "Построить График";
            this.buttonGrafVar2.UseVisualStyleBackColor = true;
            this.buttonGrafVar2.Click += new System.EventHandler(this.buttonGrafVar2_Click);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(217, 6);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(863, 613);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1089, 625);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Kirill";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1089, 625);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Sasha";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 652);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowSizeVar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button buttonGrafVar2;
        private System.Windows.Forms.Button buttonPredictionVar2;
        private System.Windows.Forms.NumericUpDown numericUpDownWindowSizeVar2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelMaxDiffUSD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelMaxDiffUSDmn;
        private System.Windows.Forms.Label labelMaxDiffEUmn;
        private System.Windows.Forms.Label labelMaxDiffEU;
        private System.Windows.Forms.Label label1Var2;
    }
}

