using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace TPLR3.Kirill
{
    public static class ExcelImporter
    {
        //Метод импортирует два столбца float и один столбец DateTime из Excel по названиям заголовков для считывания данных из файлов Excel
        public static void ImportTwoFloatAndDateColumnsByName(string filePath, string columnName1, string columnName2, string dateColumnName, out List<float> list1, 
            out List<float> list2, out List<DateTime> dateList)
        {
            list1 = new List<float>();
            list2 = new List<float>();
            dateList = new List<DateTime>();

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet("MigrationData");
                int lastRow = worksheet.LastRowUsed().RowNumber();

                //Поиск индексов столбцов по названиям в первой строке
                int colIndex1 = 0, colIndex2 = 0, dateColIndex = 0;
                foreach (var cell in worksheet.Row(1).CellsUsed())
                {
                    if (cell.GetString() == columnName1) colIndex1 = cell.Address.ColumnNumber;
                    if (cell.GetString() == columnName2) colIndex2 = cell.Address.ColumnNumber;
                    if (cell.GetString() == dateColumnName) dateColIndex = cell.Address.ColumnNumber;
                }

                if (colIndex1 == 0 || colIndex2 == 0 || dateColIndex == 0)
                    throw new Exception("Один или несколько столбцов не найдены!");

                //Импорт значений из найденных столбцов
                for (int row = 2; row <= lastRow; row++)
                {
                    //Импорт float
                    if (float.TryParse(worksheet.Cell(row, colIndex1).GetString().Replace(',', '.'),
                        NumberStyles.Any, CultureInfo.InvariantCulture, out float val1))
                    {
                        list1.Add(val1);
                    }

                    if (float.TryParse(worksheet.Cell(row, colIndex2).GetString().Replace(',', '.'),
                        NumberStyles.Any, CultureInfo.InvariantCulture, out float val2))
                    {
                        list2.Add(val2);
                    }

                    //Импорт DateTime (универсальный способ)
                    var cell = worksheet.Cell(row, dateColIndex);
                    DateTime dateVal;
                    bool parsed = false;
                    try
                    {
                        dateVal = cell.GetDateTime();
                        parsed = true;
                    }
                    catch
                    {
                        parsed = DateTime.TryParse(
                            cell.GetString().Replace(',', '.'),
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out dateVal);
                    }
                    if (parsed)
                        dateList.Add(dateVal);
                }
            }
        }
    }
}
