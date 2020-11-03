using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace ClassLibraryControlInvisible
{
    public partial class ComponentWordReport : Component
    {
        public ComponentWordReport()
        {
            InitializeComponent();
        }

        public ComponentWordReport(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void AddTable<T>(List<T> list, string header, string fileName)
        {
            var fields = typeof(T).GetFields();

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            var winword = new Microsoft.Office.Interop.Word.Application();
            try
            {
                object missing = System.Reflection.Missing.Value;

                //создаем документ
                Microsoft.Office.Interop.Word.Document document =
                    winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                //создаем таблицу
                var paragraphTable = document.Paragraphs.Add(Type.Missing);
                var rangeTable = paragraphTable.Range;
                var table = document.Tables.Add(rangeTable, list.Count + 2, fields.Length, ref missing, ref missing);
                var font = table.Range.Font;
                font.Size = 14;
                font.Name = "Times New Roman";

                //задаем границы таблицы
                table.Borders.InsideLineStyle = WdLineStyle.wdLineStyleInset;
                table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                var paragraphTableFormat = table.Range.ParagraphFormat;
                paragraphTableFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphTableFormat.SpaceAfter = 0;
                paragraphTableFormat.SpaceBefore = 0;

                table.Rows[1].Cells[1].Merge(table.Rows[1].Cells[fields.Length]);
                table.Rows[1].Cells[1].Range.Text = header;
                table.Rows[1].Cells[1].Range.Italic = 1;
                table.Rows[1].Cells[1].Range.Shading.BackgroundPatternColor = WdColor.wdColorYellow;
                table.Rows[1].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                int r = 1;
                foreach (var field in fields)
                {
                    table.Cell(2, r).Range.Text = field.Name;
                    table.Cell(2, r).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    table.Cell(2, r).Range.Bold = 1;
                    r++;
                }

                int i = 2;
                foreach (var element in list)
                {
                    int j = 1;
                    foreach (var field in fields)
                    {
                        table.Cell(i + 1, j).Range.Text = element.GetType().GetField(field.Name).GetValue(element).ToString();
                        j++;
                    }
                    i++;
                }

                //сохраняем
                object fileFormat = WdSaveFormat.wdFormatXMLDocument;
                document.SaveAs(fileName, ref fileFormat, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing);
                document.Close(ref missing, ref missing, ref missing);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                winword.Quit();
            }
        }
    }
}
