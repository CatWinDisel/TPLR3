using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TPLR3
{
    public partial class Form1 : Form
    {
        ComputeClassVar2 computeVar2;
        CurrencyStatistics currencyStatistics;
        ImportClassVar2 importClassVar2 = new ImportClassVar2();
        public List<DateTime> dates = new List<DateTime>();
        public List<float> list1 = new List<float>();
        public List<float> list2 = new List<float>();
        public Form1()
        {
            InitializeComponent();
            importClassVar2.ImportThreeFloatColumnsByName("C:/Users/erago/source/repos/TPLR3/Data.xlsx", "Date", "Currency_USD", "Currency_EUR", out dates, out list1, out list2);
            currencyStatistics = new CurrencyStatistics(dates, list1, list2);
            computeVar2 = new ComputeClassVar2(currencyStatistics);
        }

        private void buttonGrafVar2_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            var seriesUSD = new Series("Курс USD");
            var seriesEU = new Series("Курс Euro");
            var predictionSereisUSD = new Series("Прогноз курса USD");
            var predictionSereisEU = new Series("Прогноз курса EU");
            seriesUSD.ChartType = SeriesChartType.Line; // Линейный график
            seriesEU.ChartType = SeriesChartType.Line;
            predictionSereisUSD.ChartType = SeriesChartType.Line;
            predictionSereisEU.ChartType = SeriesChartType.Line;
            var last_index = currencyStatistics.dateTimes.Count - 1;

            // Добавляем точки
            for (int i = 0; i < currencyStatistics.dateTimes.Count; i++)
            {
                seriesUSD.Points.AddXY(currencyStatistics.dateTimes[i], currencyStatistics.Rub_To_USD_Сourse[i]);
                seriesEU.Points.AddXY(currencyStatistics.dateTimes[i], currencyStatistics.Rub_To_EU_Сourse[i]);
            }
            predictionSereisUSD.Points.AddXY(currencyStatistics.dateTimes[last_index], currencyStatistics.Rub_To_USD_Сourse[last_index]);
            predictionSereisEU.Points.AddXY(currencyStatistics.dateTimes[last_index], currencyStatistics.Rub_To_EU_Сourse[last_index]);
            
            chart1.Series.Add(seriesUSD);
            chart1.Series.Add(seriesEU);
            chart1.Series.Add(predictionSereisUSD);
            chart1.Series.Add(predictionSereisEU);

            // Форматируем ось X под даты (опционально)
            chart1.ChartAreas[0].AxisY.Minimum = 82;
            chart1.ChartAreas[0].AxisY.Maximum = 110;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd.MM.yyyy";
            chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
        }

        private void buttonPredictionVar2_Click(object sender, EventArgs e)
        {
            int window_size = (int)numericUpDownWindowSizeVar2.Value;
            computeVar2.MovingAverageMethod(window_size);
            var usdChart = chart1.Series["Прогноз курса USD"];
            var euChart = chart1.Series["Прогноз курса EU"];
            int index = currencyStatistics.dateTimes.Count;

            usdChart.Points.AddXY(currencyStatistics.dateTimes[index - 1], currencyStatistics.Rub_To_USD_Сourse[index - 1]);
            euChart.Points.AddXY(currencyStatistics.dateTimes[index - 1], currencyStatistics.Rub_To_EU_Сourse[index - 1]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            computeVar2.ComputeChange();
            computeVar2.GetMaxChanges();
            labelMaxDiffUSD.Text = computeVar2.change_statistics.Rub_To_USD_Changes[currencyStatistics.maxUsdIndex].ToString();
            labelMaxDiffUSDmn.Text = computeVar2.change_statistics.Rub_To_USD_Changes[currencyStatistics.minUsdIndex].ToString();
            labelMaxDiffEU.Text = computeVar2.change_statistics.Rub_To_EU_Changes[currencyStatistics.maxEuIndex].ToString();
            labelMaxDiffEUmn.Text = computeVar2.change_statistics.Rub_To_EU_Changes[currencyStatistics.minEuIndex].ToString();

        }
    }
}
