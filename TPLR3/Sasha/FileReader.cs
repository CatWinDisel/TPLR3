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
                pathNow = pathNow.Remove(pathNow.Length - 16);
                openFileDialog.InitialDirectory = pathNow;
                openFileDialog.Filter = "Excel Files|*.xls;*xlsx;*.xlsm";
                openFileDialog.RestoreDirectory = true;
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
                
                // Нахождение необходимых Date(даты) и Specification(характеристик) в файле
                List<int> excelColumnList = Enumerable.Range(1, columnCount).ToList();
                Dictionary<string, int> columns = new Dictionary<string, int>();
                foreach (SpecificData specificData in data.GetAllData().Item2)
                {
                    int dataColumn = columns.Count;
                    //MessageBox.Show("dataColumn = " + excelColumnList.Count);
                    for (int i = 0; i < excelColumnList.Count; i++)
                    { // Проходим про всем колонкам в файле и Если совпадение - сохраняем номер колонки
                        if (worksheet.Cell(1, excelColumnList[i]).Value.ToString() == "Date")
                        {
                            columns.Add("Date", excelColumnList[i]);
                            excelColumnList.RemoveAt(i);
                        }
                        if (specificData.name == worksheet.Cell(1, excelColumnList[i]).Value.ToString())
                        {
                            columns.Add(specificData.name, excelColumnList[i]);
                            excelColumnList.RemoveAt(i);
                            break;
                        }
                    }
                    if (dataColumn == columns.Count)
                        throw new Exception("Файл Excel записан не верно!");
                }

                bool endcheck = false;
                //MessageBox.Show(rowCount)
                for (int row = 2; row <= rowCount; row++)
                { // Идём построчно и добавляем необходимые данные в списки
                    // Проверка значений строк на null
                    foreach (string i in columns.Keys)
                    {
                        if (worksheet.Cell(row, columns[i]).Value.ToString() == "")
                            endcheck = true;
                    }
                    // Если какая-то ячейка в строке пустая, то чтение файла завершается
                    if (endcheck)
                    { MessageBox.Show("Строка " + row + " имеет пустое значение\nСчитываение файла прекращено"); break; }
                    // Занесение данных в экземляр класса StatisticData
                    data.GetAllData().Item1.Add((DateTime)worksheet.Cell(row, columns["Date"]).Value);
                    foreach (SpecificData specificData in data.GetAllData().Item2)
                    {
                        specificData.AddToSpecificlist(worksheet.Cell(row, columns[specificData.name]).Value);
                    }
                }
            }
        }
    }
}
