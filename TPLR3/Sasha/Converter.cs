using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TPLR3.Sasha
{
    public class Converter
    {
        public DataTable ConvertToDataTable(StatisticData statisticData)
        { // Метод, который переписывает данные в таблицу
            DataTable dt = new DataTable();
            // Добавление столбцов
            dt.Columns.Add("Date");
            foreach (SpecificData data in statisticData.GetAllData().Item2)
                dt.Columns.Add(data.name);
            // Добавление строк
            int count = statisticData.GetAllData().Item2.Count; //MessageBox.Show(count.ToString());
            object[] arr = { };
            Array.Resize(ref arr, count + 1);
            for (int i = 0; i < statisticData.GetAllData().Item1.Count; i++)
            {
                arr[0] = statisticData.GetAllData().Item1[i].ToString("yyyy");
                for (int j = 1; j < count + 1; j++)
                    arr[j] = statisticData.GetAllData().Item2[j - 1].GetListOfSpecificData()[i];
                dt.Rows.Add(arr);
            }
            return dt;
        }
        public Chart ConvertToChart(StatisticData statisticData, Chart chart, string note = "")
        { // Метод, который рисует по данным графики
            int chartIndex;
            foreach (SpecificData specificData in statisticData.GetAllData().Item2)
            {
                chart.Series.Add(specificData.name + " "  + note); // Добавление нового графика
                chartIndex = chart.Series.Count - 1;
                chart.Series[chartIndex].ChartType = SeriesChartType.Line; // Вид графика
                chart.Series[chartIndex].BorderWidth = 5; // Толщина линии графика
                chart.Series[chartIndex].YValueType = ChartValueType.Single;
                //chart.Series[chartIndex].IsXValueIndexed = true;


                for (int i = 0; i < specificData.GetListOfSpecificData().Count; i++)
                { // Ризование графика для всех данных в классе
                    chart.Series[chartIndex].Points.AddXY(
                        statisticData.GetAllData().Item1[i].ToString("yyyy"), 
                        specificData.GetListOfSpecificData()[i]);
                }
            }
            return chart;
        }
    }
}
