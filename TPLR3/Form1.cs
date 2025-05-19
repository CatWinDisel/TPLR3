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
        ComputeClassVar2 computeVar2;
        CurrencyStatistics currencyStatistics;
        ImportClassVar2 importClassVar2 = new ImportClassVar2();
        TPLR3.Sasha.Facade SashaCode;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void buttonGrafVar2_Click(object sender, EventArgs e)
        {
            if (currencyStatistics != null)
            {
                chartVar2.Series.Clear();
                var seriesUSD = new Series("Курс USD");
                var seriesEU = new Series("Курс Euro");
                var predictionSereisUSD = new Series("Прогноз курса USD");
                var predictionSereisEU = new Series("Прогноз курса EU");
                seriesUSD.ChartType = SeriesChartType.Line; // Линейный график
                seriesEU.ChartType = SeriesChartType.Line;
                predictionSereisUSD.ChartType = SeriesChartType.Line;
                predictionSereisEU.ChartType = SeriesChartType.Line;
                var last_index = currencyStatistics.dateTimes.Count - 1;

                // Добавляем точки графика
                for (int i = 0; i < currencyStatistics.dateTimes.Count; i++)
                {
                    seriesUSD.Points.AddXY(currencyStatistics.dateTimes[i], currencyStatistics.Rub_To_USD_Сourse[i]);
                    seriesEU.Points.AddXY(currencyStatistics.dateTimes[i], currencyStatistics.Rub_To_EU_Сourse[i]);
                }
                predictionSereisUSD.Points.AddXY(currencyStatistics.dateTimes[last_index], currencyStatistics.Rub_To_USD_Сourse[last_index]);
                predictionSereisEU.Points.AddXY(currencyStatistics.dateTimes[last_index], currencyStatistics.Rub_To_EU_Сourse[last_index]);

                chartVar2.Series.Add(seriesUSD);
                chartVar2.Series.Add(seriesEU);
                chartVar2.Series.Add(predictionSereisUSD);
                chartVar2.Series.Add(predictionSereisEU);

                // Форматируем ось X под даты
                chartVar2.ChartAreas[0].AxisY.Minimum = 82;
                chartVar2.ChartAreas[0].AxisY.Maximum = 110;
                chartVar2.ChartAreas[0].AxisX.LabelStyle.Format = "dd.MM.yyyy";
                chartVar2.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
                chartVar2.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
                chartVar2.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            }
        }

        private void buttonPredictionVar2_Click(object sender, EventArgs e)
        {
            int window_size = (int)numericUpDownWindowSizeVar2.Value;
            
            try
            {
                var usdChart = chartVar2.Series["Прогноз курса USD"];
                var euChart = chartVar2.Series["Прогноз курса EU"];

                computeVar2.MovingAverageMethod(window_size);
                int index = currencyStatistics.dateTimes.Count;

                usdChart.Points.AddXY(currencyStatistics.dateTimes[index - 1], currencyStatistics.Rub_To_USD_Сourse[index - 1]);
                euChart.Points.AddXY(currencyStatistics.dateTimes[index - 1], currencyStatistics.Rub_To_EU_Сourse[index - 1]);
            }
            catch { }
        }

        private void buttonVar2_Click(object sender, EventArgs e)
        {
            if (computeVar2 != null)
            {
                computeVar2.ComputeChange();
                computeVar2.GetMaxChanges();
                labelMaxDiffUSD.Text = computeVar2.change_statistics.Rub_To_USD_Changes[currencyStatistics.maxUsdIndex].ToString("F2");
                labelMaxDiffUSD.Text += " " + computeVar2.change_statistics.Dates[currencyStatistics.maxUsdIndex].ToString("yyyy-MM-dd");

                labelMaxDiffUSDmn.Text = computeVar2.change_statistics.Rub_To_USD_Changes[currencyStatistics.minUsdIndex].ToString("F2");
                labelMaxDiffUSDmn.Text += " " + computeVar2.change_statistics.Dates[currencyStatistics.minUsdIndex].ToString("yyyy-MM-dd");


                labelMaxDiffEU.Text = computeVar2.change_statistics.Rub_To_EU_Changes[currencyStatistics.maxEuIndex].ToString("F2");
                labelMaxDiffEU.Text += " " + computeVar2.change_statistics.Dates[currencyStatistics.maxEuIndex].ToString("yyyy-MM-dd");

                labelMaxDiffEUmn.Text = computeVar2.change_statistics.Rub_To_EU_Changes[currencyStatistics.minEuIndex].ToString("F2");
                labelMaxDiffEUmn.Text += " " + computeVar2.change_statistics.Dates[currencyStatistics.minEuIndex].ToString("yyyy-MM-dd");
            }
        }

        private void buttonOpenFileVar2_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
                openFileDialog.Filter = "Excel файлы (*.xlsx)|*.xlsx";
            }
            if (path != string.Empty)
            {
                List<DateTime> dates = new List<DateTime>();
                List<float> list1 = new List<float>();
                List<float> list2 = new List<float>();
                importClassVar2.ImportThreeFloatColumnsByName(path, "Date", "Currency_USD", "Currency_EUR", out dates, out list1, out list2);
                currencyStatistics = new CurrencyStatistics(dates, list1, list2);
                computeVar2 = new ComputeClassVar2(currencyStatistics);
            }
            else
            {
                MessageBox.Show("Ошибка чтения файла");
            }

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
