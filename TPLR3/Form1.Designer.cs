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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel_Sasha = new System.Windows.Forms.Panel();
            this.button_Sasha_Start = new System.Windows.Forms.Button();
            this.label_Sasha_Lenght = new System.Windows.Forms.Label();
            this.label_Sasha_Size = new System.Windows.Forms.Label();
            this.numericUpDown_Sasha_Lenght = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Sasha_Size = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chart_Sasha = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel_Sasha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Sasha_Lenght)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Sasha_Size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Sasha)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1463, 801);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1455, 772);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Michial";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1455, 772);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Kirill";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel_Sasha);
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Controls.Add(this.chart_Sasha);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1455, 772);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Sasha";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel_Sasha
            // 
            this.panel_Sasha.Controls.Add(this.button_Sasha_Start);
            this.panel_Sasha.Controls.Add(this.label_Sasha_Lenght);
            this.panel_Sasha.Controls.Add(this.label_Sasha_Size);
            this.panel_Sasha.Controls.Add(this.numericUpDown_Sasha_Lenght);
            this.panel_Sasha.Controls.Add(this.numericUpDown_Sasha_Size);
            this.panel_Sasha.Location = new System.Drawing.Point(423, 44);
            this.panel_Sasha.Name = "panel_Sasha";
            this.panel_Sasha.Size = new System.Drawing.Size(868, 74);
            this.panel_Sasha.TabIndex = 2;
            // 
            // button_Sasha_Start
            // 
            this.button_Sasha_Start.Location = new System.Drawing.Point(711, 12);
            this.button_Sasha_Start.Name = "button_Sasha_Start";
            this.button_Sasha_Start.Size = new System.Drawing.Size(126, 49);
            this.button_Sasha_Start.TabIndex = 3;
            this.button_Sasha_Start.Text = "Start";
            this.button_Sasha_Start.UseVisualStyleBackColor = true;
            this.button_Sasha_Start.Click += new System.EventHandler(this.button_Sasha_Start_Click);
            // 
            // label_Sasha_Lenght
            // 
            this.label_Sasha_Lenght.AutoSize = true;
            this.label_Sasha_Lenght.Location = new System.Drawing.Point(352, 30);
            this.label_Sasha_Lenght.Name = "label_Sasha_Lenght";
            this.label_Sasha_Lenght.Size = new System.Drawing.Size(112, 16);
            this.label_Sasha_Lenght.TabIndex = 3;
            this.label_Sasha_Lenght.Text = "Prediction lengtht:";
            // 
            // label_Sasha_Size
            // 
            this.label_Sasha_Size.AutoSize = true;
            this.label_Sasha_Size.Location = new System.Drawing.Point(30, 30);
            this.label_Sasha_Size.Name = "label_Sasha_Size";
            this.label_Sasha_Size.Size = new System.Drawing.Size(121, 16);
            this.label_Sasha_Size.TabIndex = 2;
            this.label_Sasha_Size.Text = "Slide Window Size:";
            // 
            // numericUpDown_Sasha_Lenght
            // 
            this.numericUpDown_Sasha_Lenght.Location = new System.Drawing.Point(470, 28);
            this.numericUpDown_Sasha_Lenght.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Sasha_Lenght.Name = "numericUpDown_Sasha_Lenght";
            this.numericUpDown_Sasha_Lenght.Size = new System.Drawing.Size(189, 22);
            this.numericUpDown_Sasha_Lenght.TabIndex = 1;
            this.numericUpDown_Sasha_Lenght.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_Sasha_Size
            // 
            this.numericUpDown_Sasha_Size.Location = new System.Drawing.Point(157, 26);
            this.numericUpDown_Sasha_Size.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_Sasha_Size.Name = "numericUpDown_Sasha_Size";
            this.numericUpDown_Sasha_Size.Size = new System.Drawing.Size(189, 22);
            this.numericUpDown_Sasha_Size.TabIndex = 0;
            this.numericUpDown_Sasha_Size.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 151);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(539, 614);
            this.dataGridView1.TabIndex = 1;
            // 
            // chart_Sasha
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_Sasha.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_Sasha.Legends.Add(legend1);
            this.chart_Sasha.Location = new System.Drawing.Point(552, 151);
            this.chart_Sasha.Name = "chart_Sasha";
            this.chart_Sasha.Size = new System.Drawing.Size(894, 470);
            this.chart_Sasha.TabIndex = 0;
            this.chart_Sasha.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 802);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel_Sasha.ResumeLayout(false);
            this.panel_Sasha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Sasha_Lenght)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Sasha_Size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Sasha)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button_Sasha_Start;
        private System.Windows.Forms.Panel panel_Sasha;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Sasha;
        private System.Windows.Forms.Label label_Sasha_Lenght;
        private System.Windows.Forms.Label label_Sasha_Size;
        private System.Windows.Forms.NumericUpDown numericUpDown_Sasha_Lenght;
        private System.Windows.Forms.NumericUpDown numericUpDown_Sasha_Size;
    }
}

