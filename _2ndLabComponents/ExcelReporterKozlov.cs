using System;
using System.ComponentModel;
using System.Reflection;
using _2ndLabComponents.Enums;
using Microsoft.Office.Interop.Excel;

namespace _2ndLabComponents
{
    public partial class ExcelReporterKozlov : Component
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ExcelReporterKozlov()
        {
            InitializeComponent();
        }

        public ExcelReporterKozlov(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        /// <summary>
        /// Создание отчёта
        /// </summary>
        /// <param name="obj"> Источник отчёта </param>
        /// <param name="path"> Путь к файлу </param>
        /// <param name="headerType"> Расположение шапки: сверху или сбоку </param>
        public void CreateReport(object obj, string path, HeaderType headerType = HeaderType.Horizontal)
        {
            //Объявляем приложение
            Application ex = new Application();
            //Отобразить Excel
            ex.Visible = false;
            //Количество листов в рабочей книге
            ex.SheetsInNewWorkbook = 1;
            //Добавить рабочую книгу
            Workbook workBook = ex.Workbooks.Add(Type.Missing);
            //Отключить отображение окон с сообщениями
            ex.DisplayAlerts = false;
            //Получаем первый лист документа (счет начинается с 1)
            Worksheet sheet = (Worksheet)ex.Worksheets.get_Item(1);
            //Название листа (вкладки снизу)
            sheet.Name = $"Отчет за {DateTime.Now.ToString("dd.MM.yyyy")}";

            var props = obj.GetType().GetProperties();

            for (int i = 1; i <= props.Length; i++)
            {
                PropertyInfo prop = props[i - 1];
                if (headerType == HeaderType.Horizontal)
                {
                    sheet.Cells[1, i] = prop.Name;
                    sheet.Cells[2, i] = prop.GetValue(obj).ToString();
                }
                if (headerType == HeaderType.Vertical)
                {
                    sheet.Cells[i, 1] = prop.Name;
                    sheet.Cells[i, 2] = prop.GetValue(obj).ToString();
                }
            }

            ex.Application.ActiveWorkbook.SaveAs(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        }
    }
}
