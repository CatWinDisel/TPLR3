using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPLR3
{
    public partial class Form1 : Form
    {
        TPLR3.Sasha.Facade SashaCode;
        public Form1()
        {
            InitializeComponent();
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    SashaCode = new Sasha.Facade();
                    dataGridView1.DataSource = SashaCode.CreateDataTable();
                    numericUpDown_Sasha_Size.Maximum = SashaCode.GetMaxSize();
                    panel_Sasha.Visible = true;
                    break;
            }
        }

        private void button_Sasha_Start_Click(object sender, EventArgs e)
        {
            SashaCode.DrawChart(chart_Sasha, (int)numericUpDown_Sasha_Size.Value, (int)numericUpDown_Sasha_Lenght.Value);
            panel_Sasha_PricePrediction.Visible = true;
            button_Sasha_PricePrediction.Text = "Make Price prediction for " + numericUpDown_Sasha_Lenght + " years";
        }

        private void button_Sasha_PricePrediction_Click(object sender, EventArgs e)
        {
            MessageBox.Show(SashaCode.GetPricePrediction(textBox_Sasha_ProductName.Text, (float)numericUpDown_Sasha_Price.Value));
        }
    }
}
