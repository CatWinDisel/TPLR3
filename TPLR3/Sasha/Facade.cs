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
    public class Facade
    {
        public string path;
        private StatisticData statisticData;
        private StatisticData predictionData;
        private FileReader reader;
        private Converter converter;
        public Facade()
        {
            path = "";
            statisticData = new InflationData();
            statisticData.CreateStatisticData();
            reader = new FileReader();
            converter = new Converter();
        }
        public DataTable CreateDataTable ()
        {
            path = reader.GetFilePath();
            reader.ReadFromExcel(ref statisticData, path);
            return converter.ConvertToDataTable(statisticData);
        }
        public void DrawChart (Chart chart, int size, int lenght)
        {
            // Русуется изначальный график
            chart = converter.ConvertToChart(statisticData, chart); 
            // Русуется график прогноза
            predictionData = statisticData.GetPrediction(size, lenght);
            //chart = converter.ConvertToChart(predictionData, chart, "Prediction");
        }
        public int GetMaxSize()
        {
            return statisticData.GetAllData().Item1.Count;
        }
    }
}
