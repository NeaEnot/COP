using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;

namespace _2ndLabComponents
{
    public partial class PdfPieChartPainterKozlov : Component
    {
        private DataLabelType dataLabelType = DataLabelType.None;

        /// <summary>
        /// Конструктор
        /// </summary>
        public PdfPieChartPainterKozlov()
        {
            InitializeComponent();
        }

        public PdfPieChartPainterKozlov(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        /// <summary>
        /// Делегат для функции выборки
        /// </summary>
        /// <param name="arg">Объект класса</param>
        /// <returns>Значение, по которому производится выборка</returns>
        public delegate object Del(object arg);

        /// <summary>
        /// Функция выборки
        /// </summary>
        public Del SelectionFunction { get; set; }

        /// <summary>
        /// Создание круговой диаграммы из объекта
        /// </summary>
        /// <param name="obj"> Источник данных </param>
        /// <param name="fileName"> Имя выходного файла </param>
        public void MakePieChart<T>(List<T> list, string fileName)
        {
            var dict = CreateDataSet(list);

            Document document = new Document();

            Style style = document.Styles["Normal"];
            style.Font.Name = "Times New Roman";
            style.Font.Size = 14;
            style = document.Styles.AddStyle("NormalTitle", "Normal");
            style.Font.Bold = true;

            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph("");
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "NormalText";

            var chart = document.LastSection.AddChart(ChartType.Pie2D);
            chart.Left = 0;

            chart.Width = Unit.FromCentimeter(12);
            chart.Height = Unit.FromCentimeter(12);

            chart.DataLabel.Type = dataLabelType;

            Legend legend = chart.RightArea.AddLegend();

            Series series = chart.SeriesCollection.AddSeries();
            XSeries xseries = chart.XValues.AddXSeries();

            foreach (var key in dict.Keys)
            {
                series.Add(dict[key]);
                xseries.Add(key);
            }

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always) { Document = document };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(fileName);
        }

        private Dictionary<string, int> CreateDataSet<T>(List<T> list)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (var elem in list)
            {
                object value = SelectionFunction(elem);

                if (dict.ContainsKey(value.ToString()))
                {
                    dict[value.ToString()]++;
                }
                else
                {
                    dict.Add(value.ToString(), 1);
                }
            }

            return dict;
        }

        /// <summary>
        /// Устанавливает тип подписи к графику
        /// </summary>
        /// <param name="type"> 0 - нет, 1 - процент, 2 - значение </param>
        public void SetDataLabelType(int type)
        {
            dataLabelType = (DataLabelType)type;
        }
    }
}
