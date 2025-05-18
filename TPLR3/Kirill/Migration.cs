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
