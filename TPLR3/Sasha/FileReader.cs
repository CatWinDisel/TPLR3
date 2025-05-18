using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TPLR3.Sasha
{
    public class FileReader
    {
        public string GetFilePath()
        { // Функция, определяющая путь до выбранного файла
            string filePath = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string pathNow = Directory.GetCurrentDirectory();
                //MessageBox.Show(pathNow.Remove(pathNow.Length - 16));
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
        public void ReadFromExcel(ref StatisticData data, string path)
        {
            using (var workbook = new XLWorkbook(path)) // Открыть Excel файл
            {
                // Выбор листа в соответствии с названием класса
                var worksheet = workbook.Worksheet(data.GetType().Name);
                // Размеры листа
                var range = worksheet.RangeUsed();
                int rowCount = range.RowCount(); // Количество строк в выбранном листе
                int columnCount = range.ColumnCount();
                // Нахождение необходимых Specification(характеристик) в файле
                Dictionary<string, int> columns = new Dictionary<string, int>();
                foreach (SpecificData specificData in data.GetAllData().Item2)
                {
                    int dataColumn = 0;
                    for (int column = 1; column <= columnCount; column++)
                    { // Проходим про всем колонкам в файле
                        if (specificData.name == worksheet.Cell(1, column).Value.ToString())
                        { // Если совпадение - сохраняем номер колонки
                            dataColumn = column;
                            break;
                        }
                    }
                    if (dataColumn != 0)
                        columns.Add(specificData.name, dataColumn);
                    else MessageBox.Show("Файл Excel записан не верно!");
                }
                for (int row = 2; row <= rowCount; row++)
                { // Идём построчно и добавляем необходимые данные в списки
                    bool endcheck = false;
                    /*foreach (int i in columns.Values)
                        if (worksheet.Cell(i, row).Value == )
                            endcheck = true;
                    if (endcheck)
                        break;*/
                    data.GetAllData().Item1.Add((DateTime)worksheet.Cell(row, 1).Value);
                    foreach (SpecificData specificData in data.GetAllData().Item2)
                    {
                        specificData.AddToSpecificlist(worksheet.Cell(row, columns[specificData.name]).Value);
                    }
                }
            }
        }
    }
}
