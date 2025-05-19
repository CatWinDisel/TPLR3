using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLR3.Kirill
{
    //Основной класс для решения задания 6 варианта
    public class Migration
    {
        //Эммигранты
        public List<float> Emigrants;

        //Иммигранты
        public List<float> Immigrants;

        //Список дат (годов)
        public List<DateTime> dateTimes;

        //Изменение в населении с учетом мигрантов и эммигрантов (в сравнении с предыдущем годом)
        public List<float> Difference;

        //Процент изменения иммиграции (список процентов по годам)
        public List<float> Migration_Procent_Change;

        //Рассчет статистики (может использоваться для вывода исходной статистики, полученной из файла)
        public void ComputeChange()
        {
            //Обновляем списки
            Difference.Clear();
            Migration_Procent_Change.Clear();

            //Подсчитываем количество дат для составления статистики
            int max_index = dateTimes.Count;

            if (dateTimes.Count > 0)
            {
                //Задаем начальные данные по умолчанию (проверяем не null ли они)
                //тыс.чел
                float average_immigrants = Immigrants != null && Immigrants.Any() ? Immigrants.Average() : 0f;
                float average_emigrants = Emigrants != null && Emigrants.Any() ? Emigrants.Average() : 0f;

                //Высчитываем разность
                Difference.Add(Immigrants[0] - Emigrants[0]);

                Migration_Procent_Change.Add(100 * (Difference[0] - (average_immigrants - average_emigrants)) / (average_immigrants - average_emigrants));
            }
            else
            {
                return;
            }

            //Начинаем заполнение с индекса 1, чтобы учесть миграционный процент для 1 года (он рассчитывается значением по умолчанию)
            for (int i = 1; i < max_index; i++)
            {
                //Считаем разницу в эмигрантах и иммигрантах
                Difference.Add(Immigrants[i] - Emigrants[i]);

                //Высчитываем процент изменения миграции за год (на основании прошлого года)
                Migration_Procent_Change.Add(100 * (Difference[i] - Difference[i - 1]) / Difference[i - 1]);
            }
        }
        //Метод для возврацения максимального изменения миграции за год (по модулю)
        public float ReturnMax()
        {
            return Migration_Procent_Change.Max(x => Math.Abs(x));
        }

        //Задать число просчетов статистики скользящим методом (на последующие N (yearsAhead) лет)
        public void Year_MovingAverageForecast(int yearsAhead, int windowSize)
        {
            for (int i = 0; i < yearsAhead; i++)
                Year_MovingAverageMethod(windowSize);
        }

        //Метод скользящей средней (для статического прогнозирования)
        public void Year_MovingAverageMethod(int windowSize)
        {
            //Просчитываем на основе скольки предыдущих лет делать статистику
            var first_index = dateTimes.Count - windowSize;
            var last_index = dateTimes.Count;

            var avg_immigrants = 0f;
            var avg_emigrants = 0f;

            //Вычисляем сумму всех значений в заданные года
            for (int i = first_index; i < last_index; i++)
            {
                avg_immigrants += Immigrants[i];
                avg_emigrants += Emigrants[i];
            }

            //Считаем средние значения
            avg_immigrants /= (windowSize);
            avg_emigrants /= (windowSize);

            //Считаем следующую дату (год) по последнему записанному
            DateTime NextDate = dateTimes[last_index - 1].AddYears(1);

            //Считаем значения для нового экземпляра (записи) статистики
            var difference = avg_immigrants - avg_emigrants;
            var percent = 100 * (difference - Difference[last_index - 1]) / Difference[last_index - 1];

            //Добавляем статистические данные в списки
            Immigrants.Add(avg_immigrants);
            Emigrants.Add(avg_emigrants);

            Difference.Add(difference);
            dateTimes.Add(NextDate);
            Migration_Procent_Change.Add(percent);
        }

        public Migration()
        {
            //Создаем списки
            Emigrants = new List<float>();
            Immigrants = new List<float>();
            dateTimes = new List<DateTime>();
            Difference = new List<float>();
            Migration_Procent_Change = new List<float>();

        }
    }
}
