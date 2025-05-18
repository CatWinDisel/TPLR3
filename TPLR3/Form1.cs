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
                    break;
            }
        }

        private void button_Sasha_Start_Click(object sender, EventArgs e)
        {
            SashaCode.DrawChart(chart_Sasha, (int)numericUpDown_Sasha_Size.Value, (int)numericUpDown_Sasha_Lenght.Value);
        }
    }
}
