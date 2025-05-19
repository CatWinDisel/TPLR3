using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Globalization;

public class ImportClassVar2
{
    public void ImportThreeFloatColumnsByName(string filePath, string columnName1, string columnName2, string columnName3, out List<DateTime> list1, out List<float> list2, out List<float> list3)
    {
        list1 = new List<DateTime>();
        list2 = new List<float>();
        list3 = new List<float>();

        var workbook = new XLWorkbook(filePath);
        var worksheet = workbook.Worksheet("SheetData");
        int lastRow = worksheet.LastRowUsed().RowNumber();

        // Поиск индексов столбцов по названиям в первой строке
        int colIndex1 = 0, colIndex2 = 0, colIndex3 = 0;
        foreach (var cell in worksheet.Row(1).CellsUsed())
        {
            if (cell.GetString() == columnName1) colIndex1 = cell.Address.ColumnNumber;
            if (cell.GetString() == columnName2) colIndex2 = cell.Address.ColumnNumber;
            if (cell.GetString() == columnName3) colIndex3 = cell.Address.ColumnNumber;
        }

        // Импорт значений из найденных столбцов
        for (int row = 2; row <= lastRow; row++)
        {
            var dateStr = worksheet.Cell(row, colIndex1).GetString().Trim();
            var usdStr = worksheet.Cell(row, colIndex2).GetString().Trim();
            var eurStr = worksheet.Cell(row, colIndex3).GetString().Trim();

            // Даты
            if (DateTime.TryParse(dateStr, out DateTime val1))
                list1.Add(val1);

            // Курс USD
            if (float.TryParse(usdStr, NumberStyles.Any, CultureInfo.GetCultureInfo("ru-RU"), out float val2))
                list2.Add(val2);

            // Курс EUR
            if (float.TryParse(eurStr, NumberStyles.Any, CultureInfo.GetCultureInfo("ru-RU"), out float val3))
                list3.Add(val3);

        }
    }
}
