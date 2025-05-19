using System;
using System.Collections.Generic;
using System.Linq;

namespace TPLR3
{
    public class ChangeStatistics
    {
        public List<DateTime> Dates = new List<DateTime>();
        public List<float> Rub_To_USD_Changes = new List<float>();
        public List<float> Rub_To_EU_Changes = new List<float>();

        public void Add(float usdChange, float euChange, DateTime date)
        {
            Rub_To_USD_Changes.Add(usdChange);
            Rub_To_EU_Changes.Add(euChange);
            Dates.Add(date);
        }
    }

    public class CurrencyStatistics
    {
        public int maxUsdIndex;
        public int maxEuIndex;
        public int minUsdIndex;
        public int minEuIndex;

        public List<DateTime> dateTimes;
        public List<float> Rub_To_USD_Сourse;
        public List<float> Rub_To_EU_Сourse;

        public CurrencyStatistics(List<DateTime> dateTimes, List<float> rubToUsdCourse, List<float> rubToEuCourse)
        {
            this.dateTimes = dateTimes;
            Rub_To_USD_Сourse = rubToUsdCourse;
            Rub_To_EU_Сourse = rubToEuCourse;
        }
    }

    public class ComputeClassVar2
    {

        public ChangeStatistics change_statistics;
        public CurrencyStatistics stat;

        public ComputeClassVar2(CurrencyStatistics stat)
        {
            this.stat = stat;
            change_statistics = new ChangeStatistics();
        }

        public void ComputeChange()
        {
            // Начальные изменения 0
            change_statistics.Add(0f, 0f, stat.dateTimes[0]);

            int max_index = stat.dateTimes.Count;
            for (int i = 1; i < max_index; i++)
            {
                float usd_change = stat.Rub_To_USD_Сourse[i] - stat.Rub_To_USD_Сourse[i - 1];
                float eu_change = stat.Rub_To_EU_Сourse[i] - stat.Rub_To_EU_Сourse[i - 1];
                DateTime date = stat.dateTimes[i];
                change_statistics.Add(usd_change, eu_change, date);
            }
        }

        public void MovingAverageForecast(int monthsAhead, int windowSize)
        {
            for (int i = 0; i < monthsAhead; i++)
                MovingAverageMethod(windowSize);
        }

        public void MovingAverageMethod(int windowSize)
        {
            int first_index = stat.Rub_To_USD_Сourse.Count - windowSize;
            int last_index = stat.Rub_To_USD_Сourse.Count;

            DateTime NextDate = stat.dateTimes[stat.dateTimes.Count - 1].Date.AddDays(1);
            float avg_USD = 0f;
            float avg_EU = 0f;

            for (int i = first_index; i < last_index; i++)
            {
                avg_USD += stat.Rub_To_USD_Сourse[i];
                avg_EU += stat.Rub_To_EU_Сourse[i];
            }

            avg_USD /= windowSize;
            avg_EU /= windowSize;

            stat.Rub_To_USD_Сourse.Add(avg_USD);
            stat.Rub_To_EU_Сourse.Add(avg_EU);
            stat.dateTimes.Add(NextDate);

            var usd_change = stat.Rub_To_USD_Сourse[last_index] - stat.Rub_To_USD_Сourse[last_index - 1];
            var eu_change = stat.Rub_To_EU_Сourse[last_index] - stat.Rub_To_EU_Сourse[last_index - 1];

            change_statistics.Add(usd_change, eu_change, NextDate);
        }

        public void GetMaxChanges()
        {
            stat.maxUsdIndex = change_statistics.Rub_To_USD_Changes
                .Select((v, i) => new { Value = v, Index = i })
                .OrderByDescending(x => x.Value)
                .First().Index;

            stat.minUsdIndex = change_statistics.Rub_To_USD_Changes
                .Select((v, i) => new { Value = v, Index = i })
                .OrderBy(x => x.Value)
                .First().Index;

            stat.maxEuIndex = change_statistics.Rub_To_EU_Changes
                .Select((v, i) => new { Value = v, Index = i })
                .OrderByDescending(x => x.Value)
                .First().Index;

            stat.minEuIndex = change_statistics.Rub_To_EU_Changes
                .Select((v, i) => new { Value = v, Index = i })
                .OrderBy(x => x.Value)
                .First().Index;

        }

    }
}
