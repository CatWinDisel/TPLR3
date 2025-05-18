using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TPLR3.Kirill;

namespace TPLR3
{
    public partial class Form1 : Form
    {
        TPLR3.Sasha.Facade SashaCode;
        public Form1()
        {
            InitializeComponent();
        }

        //Вкладка Sasha:
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

        //Хранеие данных миграции
        Migration migration = new Migration();

        //Вкладка Kirill: Кнопка для считывания файлов из Excel файла и их записи в свойства (листы) класса
        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = GetFilePath();
            if (filePath != null)
            {
                string[] arr = { "Immigrants", "Emigrants" };
                string columnName1 = arr[0];
                string columnName2 = arr[1];
                string dateColumnName = "Date";
                ExcelImporter.ImportTwoFloatAndDateColumnsByName(filePath, columnName1, columnName2, dateColumnName, out List<float> list1, out List<float> list2, out List<DateTime> dateList);
                
                //Заносим данные в списки у основного класса
                migration.Immigrants = list1;
                migration.Emigrants = list2;
                migration.dateTimes = dateList;

                //Настраиваем ограничение на максимальный размер окна (по количеству дат)
                numericUpDown2.Maximum = migration.dateTimes.Count;

                //Настраиваем таблицу на форме
                dataGridView2.DataSource = BuildDataTable(migration.dateTimes, migration.Immigrants, migration.Emigrants);

                //Разблокируем 2 кнопку (в случае, когда надо обновить данные)
                button2.Enabled = true;
            }
            else
            {
                MessageBox.Show("Вы не выбрали нужный файл");
            }
        }

        //Вкладка Kirill: Метод для получения пути к файлу
        public string GetFilePath()
        { 
            //Функция, определяющая путь до выбранного файла
            string filePath = null;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string pathNow = Directory.GetCurrentDirectory();
                pathNow = pathNow.Remove(pathNow.Length - 29);
                openFileDialog.InitialDirectory = pathNow;

                openFileDialog.Filter = "Excel Files|*.xls;*xlsx;*.xlsm";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }
            return filePath;
        }

        //Вкладка Kirill: Метод для создания таблицы с данными о миграции
        public static DataTable BuildDataTable(List<DateTime> dates, List<float> values1, List<float> values2)
        {
            //Создаем объект таблицы и добавляем колонки с нужными типами данных
            var table = new DataTable();
            table.Columns.Add("Дата", typeof(DateTime));
            table.Columns.Add("Immigrants", typeof(float));
            table.Columns.Add("Emigrants", typeof(float));

            int count = Math.Min(dates.Count, Math.Min(values1.Count, values2.Count));
            for (int i = 0; i < count; i++)
            {
                //Добавляем строки с данными
                table.Rows.Add(dates[i], values1[i], values2[i]);
            }
            return table;
        }

        //Вкладка Kirill: Кнопка для построения графика на основании полученных данных (записанных в экземпляре класса Migration)
        private void button2_Click(object sender, EventArgs e)
        {
            if (migration.dateTimes.Count > 1)
            {
                //Строим график (начальный)
                DrawTwoLineCharts(chart1, migration.dateTimes, migration.Immigrants, migration.Emigrants);
                //Высчитываем максимальный процент изменения миграции за год
                migration.ComputeChange();
            }
            else
            {
                MessageBox.Show("Полученных данных недостаточно для построения графика"); 
            }
        }

        //Вкладка Kirill: Метод для построения графиков миграции
        public void DrawTwoLineCharts(Chart chart, List<DateTime> xValues, List<float> yValues1, List<float> yValues2)
        {
            //Очистить старые серии
            chart.Series.Clear();

            //Создать первый график (по иммигрантам)
            var series1 = new Series("Immigrants")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                XValueType = ChartValueType.DateTime
            };

            //Создать второй график (по эмигрантам)
            var series2 = new Series("Emigrants")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                XValueType = ChartValueType.DateTime
            };

            int count = Math.Min(xValues.Count, Math.Min(yValues1.Count, yValues2.Count));
            
            //Добавляем точки для графиков
            for (int i = 0; i < count; i++)
            {
                series1.Points.AddXY(xValues[i], yValues1[i]);
                series2.Points.AddXY(xValues[i], yValues2[i]);
            }

            //Добавляем составленные графики в элемент Chart
            chart.Series.Add(series1);
            chart.Series.Add(series2);

            //Оформление осей
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "dd.MM.yyyy";
            chart.ChartAreas[0].RecalculateAxesScale();
        }

        //Вкладка Kirill: Кнопка для построения графика по прогнозу
        private void button3_Click(object sender, EventArgs e)
        {
            //Блокируем 2 кнопку
            button2.Enabled = false;

            //Построение графика по прогнозу с параметрами N лет прогноза и размера окна windowSize
            migration.Year_MovingAverageForecast((int)numericUpDown1.Value, (int)numericUpDown2.Value);

            //Отрисовка графика
            DrawTwoLineCharts(chart2, migration.dateTimes, migration.Immigrants, migration.Emigrants);
        }

        //Вкладка Kirill: Кнопка для подсчета максимального процента миграции (по модулю)
        private void button4_Click(object sender, EventArgs e)
        {
            //Высчитываем максимальный процент изменения миграции за год и выводим его в форму
            migration.ComputeChange();
            textBox1.Text = migration.ReturnMax().ToString();
        }
    }
}
