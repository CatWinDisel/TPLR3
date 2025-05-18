using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TPLR3.Sasha
{
    public abstract class StatisticData
    {
        protected List<DateTime> dates; // Список дат
        protected List<SpecificData> datas; // Список столбцов с типизированной информацией
        public StatisticData()
        {
            dates = new List<DateTime>();
            datas = new List<SpecificData>();
        }
        public Tuple<List<DateTime>, List<SpecificData>> GetAllData()
        {
            return new Tuple<List<DateTime>, List<SpecificData>>(dates, datas);
        }
        public abstract void CreateStatisticData();
        public abstract StatisticData GetPrediction(int size, int length);
        public StatisticData CreatePrediction(StatisticData predictionData, List<SpecificData> slideWindowList, List<float> sum, int size, int length)
        {
            predictionData.CreateStatisticData();
            // Определения шага времени в данных
            TimeSpan timeStep = dates[1] - dates[0];
            int count = dates.Count - 1;
            // Добавление в прогноз последние достоверные данные
            predictionData.GetAllData().Item1.Add(dates[count]);
            int k = 0;
            foreach (SpecificData specificData in datas)
            {
                predictionData.GetAllData().Item2[k].AddToSpecificlist(specificData.GetListOfSpecificData()[count]);
                k++;
            }
            DateTime lastDate = (DateTime)dates[count]; // Последняя дата
            // Заполнение скользящего окна
            for (int j = 0; j < slideWindowList.Count; j++)
            {
                float onesum = 0;
                for (int i = 0; i < size; i++)
                {
                    slideWindowList[j].AddToSpecificlist(datas[j].GetListOfSpecificData()[count - size + 1 + i]);
                    onesum += float.Parse(datas[j].GetListOfSpecificData()[count + 1 - size + i].ToString());
                }
                // Нахождение суммы в скользящем окне
                sum.Add(onesum);
            }
            // Расчёт прогноза
            for (int i = 0; i < length; i++)
            {
                lastDate = NextDate(lastDate, timeStep); // Вычисление новой даты

                predictionData.dates.Add(lastDate);
                for (int j = 0; j < datas.Count; j++)
                {
                    // Добавление в таблицу прогноза новых значений
                    predictionData.datas[j].AddToSpecificlist(sum[j] / size); 
                    // Добавление в скользящее окно новое значение
                    slideWindowList[j].AddToSpecificlist(sum[j] / size); 
                    // Высчитываение новой суммы
                    sum[j] += (sum[j] / size - float.Parse(slideWindowList[j].GetListOfSpecificData()[0].ToString())); 
                    // Удаление из скользящего окна первого значения
                    slideWindowList[j].RemoveAt(0); 
                }
                
            }
            return predictionData;
        }
        public DateTime NextDate(DateTime date, TimeSpan timeStep)
        { // Функция для определения промежутка времени
            if (timeStep.Days == 1) // Если день один, то это день
                return date.AddDays(1);
            else if (timeStep.Days >= 28 & timeStep.Days <= 31) // Если дней >28 или <31, то это месяц
                return date.AddMonths(1);
            else return date.AddYears(1); // В остальных случаях год
        }
    }
    public class InflationData : StatisticData
    {
        public override void CreateStatisticData()
        {
            datas.Add(new FloatData("Inflation"));
        }
        public override StatisticData GetPrediction(int size, int length)
        {
            InflationData temp = new InflationData();
            temp.CreateStatisticData();
            return this.CreatePrediction(new InflationData(), temp.GetAllData().Item2, new List<float>(), size, length);
        }
    }
}
